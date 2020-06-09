using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPower : MonoBehaviour
{
    [SerializeField] private float buffDuration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.MagnetPlayer(buffDuration);
        }
    }
}
