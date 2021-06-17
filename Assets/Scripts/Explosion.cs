
using UnityEngine;
public class Explosion : MonoBehaviour { 
    private void OnEnable() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,10), this.transform.position.x + Random.Range(15, 35)), ForceMode2D.Impulse);
    }
}
