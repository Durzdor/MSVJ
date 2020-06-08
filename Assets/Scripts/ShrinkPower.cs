using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPower : MonoBehaviour
{
    [SerializeField] private Sprite smallPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //Guarda componentes para utilizarlos despues
            var hitPlayer = collision.gameObject.GetComponent<MainController>();
            var spritePlayer = collision.gameObject.GetComponent<SpriteRenderer>();
            var collisionboxPlayer = collision.gameObject.GetComponent<CapsuleCollider2D>();
            
            //Edita los componentes que guardo antes para achicar al jugador
            hitPlayer.small = true;
            spritePlayer.sprite = smallPlayer;
            collisionboxPlayer.size = new Vector2(0.46f, 0.256f);
            hitPlayer.Resize();
        }
    }
}
