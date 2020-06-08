using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePower : MonoBehaviour
{
    [SerializeField] private Sprite largePlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Guarda componentes para utilizarlos despues
            var hitPlayer = collision.gameObject.GetComponent<MainController>();
            var spritePlayer = collision.gameObject.GetComponent<SpriteRenderer>();
            var collisionboxPlayer = collision.gameObject.GetComponent<CapsuleCollider2D>();
            
            //Edita los componentes que guardo antes para achicar al jugador
            hitPlayer.large = true;
            spritePlayer.sprite = largePlayer;
            collisionboxPlayer.size = new Vector2(1.386f, 0.256f);
            hitPlayer.Resize();
        }
    }
}
