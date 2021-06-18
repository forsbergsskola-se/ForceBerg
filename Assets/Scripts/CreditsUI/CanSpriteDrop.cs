using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CanSpriteDrop : MonoBehaviour {
    
    private RectTransform canvas;
    private RectTransform canSprite;
    private Vector3 startingPosition;
    public float speed;
 
    void Start()
    {
        canSprite = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        speed = -5.0f;
    }
 
    void Update () 
    {
        transform.Translate(0f, speed, 0f);
        if (canSprite.position.y < - canSprite.rect.height)
            transform.position = new Vector3(startingPosition.x, canvas.rect.height + canSprite.rect.height, startingPosition.z);
    }
}
