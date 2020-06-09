using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePower : MonoBehaviour
{
    [SerializeField] private int bonusPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ScoreBonus(bonusPoints);
        }
    }
}
