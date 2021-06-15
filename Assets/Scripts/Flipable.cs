using System;
using UnityEngine;

public class Flipable : MonoBehaviour
{
    public Direction direction;

    public Direction Direction
    {
        get => direction;
        private set
        {
            direction = value;
            Physics2D.gravity = direction switch
            {
                Direction.Up => new Vector2(0, 9.81f),
                Direction.Left => new Vector2(-9.81f, 0),
                Direction.Right => new Vector2(9.81f, 0),
                Direction.Down => new Vector2(0, -9.81f),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }

    private void Update()
    {
        Physics2D.gravity = direction switch
        {
            Direction.Up => new Vector2(0, 9.81f),
            Direction.Left => new Vector2(-9.81f, 0),
            Direction.Right => new Vector2(9.81f, 0),
            Direction.Down => new Vector2(0, -9.81f),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    private void SetGravity(Direction direction)
    {
        Direction = direction;
    }
}

public enum Direction
{
    Up,
    Left,
    Right,
    Down
}