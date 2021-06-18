using Unity.Mathematics;
using UnityEngine;
public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    [SerializeField] private Transform model;
    [SerializeField] private float startTimeBtwSpawns;
    [SerializeField] private GameObject echo;
    void Update() {
        if (!(this.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f)) return;
        if (timeBtwSpawns <= 0) {
            GameObject instance = Instantiate(echo, this.transform.position, quaternion.identity);
            //instance.transform.GetChild(0).localScale = model.localScale;
            Destroy(instance, 0.8f);
            timeBtwSpawns = startTimeBtwSpawns;
        } else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
