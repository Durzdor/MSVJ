using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    //Se mueve para abajo lentamente
    private void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }

    //Chocan y se activa Destruction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destruction();
        }
    }

    //Se destruye a si mismo
    private void Destruction()
    {
        Destroy(gameObject);
    }
}
