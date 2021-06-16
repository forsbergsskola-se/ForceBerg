using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

public class ColorChange : MonoBehaviour {

        Color colorOfPlayer;
        Player player;
        SpriteRenderer playerSprite;

        public void Start() {
            player = GetComponent<Player>();
            playerSprite = player.GetComponentInChildren<SpriteRenderer>();
            // default all levels are black, as the player. after you touch the ball every color inverts.
            // the level are then in white instead. if the player again touches the ball - it should revert it again.
            ChangeColor();
        }
        
        public Color CheckPlayerColor() {
            return colorOfPlayer;
        }

        void ChangeColor() {
            if (playerSprite.color == Color.black) {
                Debug.Log("color is black, changing to white");
                playerSprite.color = Color.white;
            } else {
                Debug.Log("color is white, changing to black");
                playerSprite.color = Color.black;
            }
        }
}
    