using System;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class Flipable : MonoBehaviour
{
    public Direction direction;

    private void Start() =>
        MessageHandler.Instance().SubscribeMessage<EventGravityChanged>(SetGravity);
    

    private void OnDisable() =>
        MessageHandler.Instance().UnsubscribeMessage<EventGravityChanged>(SetGravity);
    

    public Direction Direction
    {
        get => direction;
        private set
        {
            direction = value;
            
            Physics2D.gravity = Physics.gravity =direction switch //also sets the 3d gravity, it affects particles
            {
                Direction.Up => new Vector2(0, 9.81f),
                Direction.Left => new Vector2(-9.81f, 0),
                Direction.Right => new Vector2(9.81f, 0),
                Direction.Down => new Vector2(0, -9.81f),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }

    public void SetGravity(EventGravityChanged e)
    {
        Direction = e.Direction;
    }
}

public enum Direction
{
    Up,
    Left,
    Right,
    Down
}