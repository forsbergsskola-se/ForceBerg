using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public int attraction;
    private List<IMagnetic> attractees = new List<IMagnetic>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.TryGetComponent<IMagnetic>(out var component))
            attractees.Add(component);
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent<IMagnetic>(out var component))
            attractees.Remove(component);
    }

    private void FixedUpdate()
    {
        foreach (var magnetic in attractees)
        {
            magnetic.Attract(this);
        }
    }
}
