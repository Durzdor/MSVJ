using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private int hitpoints;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public Sprite[] spriteArray;
    private int currentSprite;

    //Guarda su componente SpriteRenderer y pone su sprite de acuerdo a su vida
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteChange();
    }
    
    //Cuando collisiona se fija si es alguna "Ball" y le resta la cantidad de daño que tenga
    //Si llega la vida a 0 se destruye
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var dmg = collision.gameObject.GetComponent<BallBehaviour>().dmg;
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitpoints -= dmg;
            SpriteChange();
        }
        if(hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    //Cambia el sprite que se muestra segun la cantidad de vida que tiene
    private void SpriteChange()
    {
        if(hitpoints <= 0)
        {
            hitpoints = 0;
        }
        currentSprite = hitpoints;
        _spriteRenderer.sprite = spriteArray[currentSprite];
    }
}
