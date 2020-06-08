using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPower : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float buffDuration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SlowBall(speedMultiplier, buffDuration);
        }
    }
}
