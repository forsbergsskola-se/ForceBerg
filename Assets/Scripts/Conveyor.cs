using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Conveyor : MonoBehaviour
{
    public float force;
    public Vector2 direction;
    [SerializeField] private float speedMultiplier;
    
    private Animator animator;
    private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(SpeedMultiplier, speedMultiplier);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        other.rigidbody.AddForce(direction * force * Time.fixedDeltaTime);
    }

    
}
