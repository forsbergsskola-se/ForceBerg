using System;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rigidbody2D;
    private bool playerHasControl = true;

    private void Start()
    {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        MessageHandler.Instance().SubscribeMessage<EventPlayerDeath>(OnDeath);
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
        if (Input.GetKeyDown(KeyCode.W))
            MessageHandler.Instance().SendMessage(new EventDirectionChanged(Direction.Up));
        else if (Input.GetKeyDown(KeyCode.S))
            MessageHandler.Instance().SendMessage(new EventDirectionChanged(Direction.Down));

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(new Vector2(speed, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
        }
    }

    void OnDeath(EventPlayerDeath eventPlayerDeath)
    {
        playerHasControl = false;
        Debug.Log("Player died."); 
    }
}