using System;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class Player : MonoBehaviour, IDestructible
{
    public float speed = 5;
    [SerializeField] private PlayerStamina playerStamina;
    [SerializeField] private float maxVelocity;
    private Rigidbody2D rigidbody2D;
    private bool playerHasControl = true;
    private AudioSource spaceBarSfx;

    private void Start()
    {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        MessageHandler.Instance().SubscribeMessage<EventPlayerDeath>(OnDeath);
        spaceBarSfx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(playerHasControl)
            CheckInput();
    }

    private void OnDisable()
    {
        MessageHandler.Instance().UnsubscribeMessage<EventPlayerDeath>(OnDeath);
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space) && playerStamina.IsNotEmpty)
        {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Up));
            playerStamina.Decrease();
            spaceBarSfx.Play();
        }
        else
        {
            MessageHandler.Instance().SendMessage(new EventGravityChanged(Direction.Down));
            playerStamina.BeginRegen();
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(new Vector2(speed, 0) * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, maxVelocity * -1, maxVelocity), rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, maxVelocity * -1, maxVelocity), rigidbody2D.velocity.y);
        }
    }

    void OnDeath(EventPlayerDeath eventPlayerDeath)
    {
        playerHasControl = false;
        Debug.Log("Player died."); 
    }

    public void Die()
    {
        MessageHandler.Instance().SendMessage(new EventPlayerDeath());
    }
}