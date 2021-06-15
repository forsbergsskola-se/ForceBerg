using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Blade : Trap
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform blades;
    void Update()
    {
        blades.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));        
    }
}
