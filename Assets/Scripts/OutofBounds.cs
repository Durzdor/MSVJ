using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    public AudioSource ballDeathSound;
    //Destruye todo lo que toca
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.transform.CompareTag("Ball"))
        { 
            ballDeathSound.Play();
        }
        Destroy(collision.gameObject);
    }
}
