using UnityEngine;

public class TriggeredSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int amountToSpawn;

    public void Spawn()
    {
        if (amountToSpawn <= 0)
            return;
        amountToSpawn--;
        var instance = Instantiate(prefab);
        instance.transform.position = transform.position;
    }
}
