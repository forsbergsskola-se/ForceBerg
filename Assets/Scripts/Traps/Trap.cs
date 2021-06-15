using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            Debug.Log("Player collided with Trap : " +this.name);
            //On Player Death
        }
    }
}
