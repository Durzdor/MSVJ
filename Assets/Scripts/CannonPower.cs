using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPower : MonoBehaviour
{
    [SerializeField] private int dmgBoost;
    [SerializeField] private float buffDuration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.CannonBall(dmgBoost, buffDuration);
        }
    }
}
