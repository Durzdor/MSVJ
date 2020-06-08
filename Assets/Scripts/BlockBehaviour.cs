using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private int hitpoints;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int currentSprite;

    //Guarda su componente SpriteRenderer y pone su sprite de acuerdo a su vida
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteSelector();
    }
    
    //Cuando collisiona se fija si es alguna "Ball" y le resta la cantidad de daño que tenga
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var dmg = collision.gameObject.GetComponent<BallBehaviour>().dmg;
            TakeDamage(dmg);
        }
    }
    //Hace los calculos de daño
    public void TakeDamage(int dmg)
    {
        hitpoints -= dmg;
        GameManager.Instance.ScoreCounter(dmg);
        SpriteSelector();
        NoHitPoints();
    }

    //Destruye el objeto cuando sus hitpoints son menores a 0
    private void NoHitPoints()
    {
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Muestra el sprite correspondiente a la vida actual
    private void SpriteSelector()
    {
        if (hitpoints <= 0)
        {
            hitpoints = 0;
        }
        currentSprite = hitpoints;
        spriteRenderer.sprite = spriteArray[currentSprite];
    }
}
