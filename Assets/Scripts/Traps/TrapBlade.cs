using UnityEngine;

namespace Traps
{
    public class TrapBlade : Trap
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Transform blades;
        void Update()
        {
            blades.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));        
        }
    }
}
