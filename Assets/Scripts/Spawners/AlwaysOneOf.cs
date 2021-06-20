using System.Collections;
using UnityEngine;

public class AlwaysOneOf : MonoBehaviour
{
    [SerializeField] private GameObject itemToSpawn;
    [SerializeField] private Vector2 birthOffset;
    [SerializeField] private float birthTime = 2f;
    [SerializeField] private float birthDelay = 3f;
    [SerializeField] private float repeatEveryHowManySecAfterBirth = 3f;

    private GameObject spawnedItem;

    private void Start() =>
        InvokeRepeating(nameof(SpawnItem), birthDelay, repeatEveryHowManySecAfterBirth);

    public void SpawnItem()
    {
        if (spawnedItem != null) 
            return;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float elapsed = 0f;
        Vector2 positionStartedAt = transform.position;
        spawnedItem = Instantiate(itemToSpawn, positionStartedAt, Quaternion.identity);
        spawnedItem.GetComponent<Rigidbody2D>().gravityScale = 0;
        spawnedItem.GetComponent<Collider2D>().enabled = false;
        while (elapsed/birthTime <= 1)
        {
            spawnedItem.transform.position = Vector3.Lerp(positionStartedAt, positionStartedAt + birthOffset, elapsed/birthTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        spawnedItem.GetComponent<Rigidbody2D>().gravityScale = 1;
        spawnedItem.GetComponent<Collider2D>().enabled = true;
    }
}
