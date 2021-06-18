using System;
using System.Collections;
using EventBroker;
using EventBroker.Events;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDestructible {
    public float speed = 5;
    [SerializeField] private PauseMenu pauseMenuPrefab;
    [SerializeField] private PlayerStamina playerStamina;
    [SerializeField] private float maxVelocity;
    [SerializeField] private GameObject destroyedCanPrefab;
    [SerializeField] private GameObject toDeactivate;
    [SerializeField] private GameObject staminaBar;
    private Rigidbody2D rigidbody2D;
    private bool playerHasControl = true;
    private AudioSource spaceBarSfx;

    private void Start() {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        MessageHandler.Instance().SubscribeMessage<EventPlayerDeath>(OnDeath);
        spaceBarSfx = GetComponent<AudioSource>();
    }

    private void Update() {
        if (playerHasControl)
            CheckInput();
        if (Input.GetKey(KeyCode.R))
            ResetGame();
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        var pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu == null)
        {
            pauseMenu = Instantiate(pauseMenuPrefab);
            pauseMenu.Setup();
        }
        else
            pauseMenu.Disable();
    }

    void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable() {
        MessageHandler.Instance().UnsubscribeMessage<EventPlayerDeath>(OnDeath);
    }

    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.Space) && playerStamina.IsNotEmpty) {
            spaceBarSfx.Play();
        }
        
        if (Input.GetKey(KeyCode.Space) && playerStamina.IsNotEmpty) {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Up));
            playerStamina.Decrease();
        } else {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Down));
            playerStamina.BeginRegen();
        }

        if (Input.GetKey(KeyCode.D)) {
            rigidbody2D.AddForce(new Vector2(speed, 0) * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, maxVelocity * -1, maxVelocity), rigidbody2D.velocity.y);
        } else if (Input.GetKey(KeyCode.A)) {
            rigidbody2D.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, maxVelocity * -1, maxVelocity), rigidbody2D.velocity.y);
        }
    }

    void OnDeath(EventPlayerDeath eventPlayerDeath) {
        playerHasControl = false;
        toDeactivate.SetActive(false);
        staminaBar.SetActive(false);
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Instantiate(destroyedCanPrefab, this.transform.position, quaternion.identity);
        StartCoroutine(ShowMenuAfterSeconds(6f));
    }

    IEnumerator ShowMenuAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        var pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu == null)
        {
            pauseMenu = Instantiate(pauseMenuPrefab);
            pauseMenu.Setup();
        }
    }

    public void Die() {
        MessageHandler.Instance().SendMessage(new EventPlayerDeath());
    }
}