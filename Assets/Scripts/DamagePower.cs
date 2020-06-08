using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePower : MonoBehaviour
{
    [SerializeField] private int dmgBoost;
    [SerializeField] private float buffDuration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.DamageBall(dmgBoost, buffDuration);
        }
    }
}
