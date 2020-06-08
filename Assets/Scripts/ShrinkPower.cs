using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPower : MonoBehaviour
{
    [SerializeField] private float buffDuration;
    [SerializeField] private float sizeMultiplier;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ShrinkPlayer(buffDuration, sizeMultiplier);
        }
    }
}
