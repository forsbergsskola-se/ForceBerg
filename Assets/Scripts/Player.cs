using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FindObjectOfType<Flipable>().SetGravity(Direction.Up);
            Physics.gravity = new Vector3(0, 9.81f);
        }
        // else if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     FindObjectOfType<Flipable>().SetGravity(Direction.Right);
        // }
        // else if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     FindObjectOfType<Flipable>().SetGravity(Direction.Left);
        // }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<Flipable>().SetGravity(Direction.Down);
            Physics.gravity = new Vector3(0, -9.81f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(new Vector2(speed, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(new Vector2(-speed, 0) * Time.deltaTime);
        }
    }
}
