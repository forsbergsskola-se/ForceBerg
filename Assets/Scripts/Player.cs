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
    [SerializeField] private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private bool playerHasControl = true;
    private AudioSource spaceBarSfx;

    private void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
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

    void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CheckInput() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && playerStamina.IsNotEmpty) {
            spaceBarSfx.Play();
        }
        
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && playerStamina.IsNotEmpty) {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Up));
            playerStamina.Decrease();
        } else {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Down));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(new Vector2(speed, 0) * Time.deltaTime);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, maxVelocity * -1, maxVelocity), rb.velocity.y);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, maxVelocity * -1, maxVelocity), rb.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.F))
        {
            playerHealth.Increase();
        }
    }

    void OnDeath() {
        playerHasControl = false;
        toDeactivate.SetActive(false);
        staminaBar.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
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
        OnDeath();
        MessageHandler.Instance().SendMessage(new EventPlayerDeath());
    }
}