using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Conveyor : MonoBehaviour
{
    public float force;
    public Vector2 direction;
    [FormerlySerializedAs("speedMultiplier"),SerializeField] private float animationSpeedMultiplier;
    
    private Animator animator;
    private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(SpeedMultiplier, animationSpeedMultiplier);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<ConveyorForce>(out var conveyorForce))
        {
            conveyorForce.conveyors.Add(this);
            return;
        }

        var newConveyorForce = other.gameObject.AddComponent<ConveyorForce>();
        newConveyorForce.conveyors.Add(this);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<ConveyorForce>(out var conveyorForce))
        {
            conveyorForce.conveyors.Remove(this);
        }
    }
}
