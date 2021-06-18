using UnityEngine;

public class CanSpriteDrop : MonoBehaviour {
    
    RectTransform canvas;
    RectTransform canSprite;
    Vector3 startingPosition;
    public float speed;
 
    void Start()
    {
        canSprite = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = canSprite.anchoredPosition;
    }
 
    void Update ()
    {
        canSprite.anchoredPosition += new Vector2(0, speed * Time.deltaTime);
        var totalHeight = canSprite.anchoredPosition.y + canSprite.rect.height;
        if (totalHeight < 0.0f)
            canSprite.anchoredPosition = new Vector3(startingPosition.x, canvas.rect.height + canSprite.rect.height, startingPosition.z);
    }
}
