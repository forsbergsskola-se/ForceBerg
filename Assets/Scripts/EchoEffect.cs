using Unity.Mathematics;
using UnityEngine;
public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns;
    [SerializeField] private GameObject echo;
    void Update() {
        if (!(this.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f)) return;
        if (timeBtwSpawns <= 0) {
            GameObject instance = Instantiate(echo, this.transform.position, quaternion.identity);
            Destroy(instance, 0.8f);
            timeBtwSpawns = startTimeBtwSpawns;
        } else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
