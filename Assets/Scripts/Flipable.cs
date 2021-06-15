using System;
using EventBroker;
using EventBroker.Events;
using UnityEngine;

public class Flipable : MonoBehaviour
{
    public Direction direction;

    private void Start() =>
        MessageHandler.Instance().SubscribeMessage<EventDirectionChanged>(SetGravity);
    

    private void OnDestroy() =>
        MessageHandler.Instance().UnsubscribeMessage<EventDirectionChanged>(SetGravity);
    

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

    public void SetGravity(EventDirectionChanged e)
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