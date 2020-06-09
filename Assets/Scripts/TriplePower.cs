using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplePower : MonoBehaviour
{
    [SerializeField] private int ballAmount;
    [SerializeField] private int extraLifes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TripleBall(ballAmount, extraLifes);
        }
    }
}
