using UnityEngine;

public class SwitchTextColor : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TextMesh textMesh))
        {
            textMesh.color = Color.white;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TextMesh textMesh))
        {
            textMesh.color = Color.black;
        }
    }
}
