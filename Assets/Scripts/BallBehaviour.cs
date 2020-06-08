using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 direction = Vector3.down;
    [SerializeField] private float speed;
    public int dmg;
    private Vector2 collisionNormal;
    
    private void Update()
    {
        Movement();
    }
    
    //Movimiento
    private void Movement()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    //Cuando colisiona se fija la normal del objeto colisionado
    //Hace un reflejo para conseguir nueva direccion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionNormal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, collisionNormal);
    }
}
