using UnityEngine;

namespace Spawners
{
    public class ContinuousSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnObject;
        [SerializeField] private int quantity;
        [SerializeField] private float repeat = 1f;
        [SerializeField] private float delayBeforeStart;

        private int counter = 0;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), delayBeforeStart, repeat);
        }

        void Spawn()
        {
            Instantiate(spawnObject, transform);
            counter++;
            if(counter >= quantity)
                CancelInvoke(nameof(Spawn));
        }
    }
}
