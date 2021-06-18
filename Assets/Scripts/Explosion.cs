using UnityEngine;
using Random = UnityEngine.Random;

public class Explosion : MonoBehaviour { 
    private void OnEnable() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-35, 35), this.transform.position.y + Random.Range(-35, 35)), ForceMode2D.Impulse);
        Destroy(this.gameObject, 1.2f);
    }
    private void Update() {
        if (this.GetComponent<SpriteRenderer>().color.a <= 0) return;
        Color color = this.GetComponent<SpriteRenderer>().color;
        color.a -= 0.002f;
        this.GetComponent<SpriteRenderer>().color = color;
    }
}