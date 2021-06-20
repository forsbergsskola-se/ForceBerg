using System.Collections.Generic;
using UnityEngine;

public class ConveyorForce : MonoBehaviour
{
    public List<ConveyorBelt> conveyors = new List<ConveyorBelt>();
    private Rigidbody2D rb2D;
    private List<int> list;

    private void FixedUpdate()
    {
        if (conveyors.Count > 0)
        {
            var conveyor = conveyors[conveyors.Count - 1];
            rb2D ??= GetComponent<Rigidbody2D>();
            rb2D.AddForce(conveyor.direction * (conveyor.force * Time.fixedDeltaTime));
        }
    }
}
