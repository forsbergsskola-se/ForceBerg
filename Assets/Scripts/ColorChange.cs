using UnityEngine;

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
                playerSprite.color = Color.white;
            } else {
                playerSprite.color = Color.black;
            }
        }
}
    