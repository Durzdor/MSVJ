using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    #region Variables
    public Vector3 direction = Vector3.zero; //Vector3.up + Vector3.right;
    public float speed;
    public int dmg;
    public bool isStopped = false;
    private Vector2 collisionNormal;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    [HideInInspector] public bool slowBallOn;
    [HideInInspector] public float slowBallDuration;
    [HideInInspector] public float slowBallMultiplier;
    [HideInInspector] public bool fastBallOn;
    [HideInInspector] public float fastBallDuration;
    [HideInInspector] public float fastBallMultiplier;
    [HideInInspector] public bool damageBallOn;
    [HideInInspector] public float damageBallDuration;
    [HideInInspector] public int damageBallPower;
    [HideInInspector] public bool cannonBallOn;
    [HideInInspector] public float cannonBallDuration;
    [HideInInspector] public int cannonBallPower;
    public AudioSource blockHitSound;
    public AudioSource playerHitSound;
    #endregion

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.Instance.BallAdd(this);
        direction = Vector3.zero;
    }
    private void Update()
    {
        //Lo que pasa si la pelota está frenada
        if (isStopped)
        {
            //sigo al player
            transform.position = new Vector2(GameObject.Find("MainPlayer").transform.position.x, transform.position.y);
        }
        //Lo que pasa si tengo el FastPowerup
        if (fastBallOn)
        {
            fastBallDuration -= Time.deltaTime;
            if (fastBallDuration <= 0)
            {
                speed -= fastBallMultiplier;
                fastBallOn = false;
            }
        }
        //Lo que pasa si tengo el SlowPowerup
        if (slowBallOn)
        {
            slowBallDuration -= Time.deltaTime;
            if (slowBallDuration <= 0)
            {
                speed += slowBallMultiplier;
                slowBallOn = false;
            }
        }
        //Lo que pasa si tengo el DamagePowerup
        if (damageBallOn)
        {
            damageBallDuration -= Time.deltaTime;
            spriteRenderer.color = Color.red;
            if (damageBallDuration <= 0)
            {
                damageBallOn = false;
                dmg -= damageBallPower;
                spriteRenderer.color = Color.white;
            }
        }
        //Lo que pasa si tengo el CannonPowerup
        if (cannonBallOn)
        {
            cannonBallDuration -= Time.deltaTime;
            spriteRenderer.color = Color.green;
            if (cannonBallDuration <= 0)
            {
                cannonBallOn = false;
                dmg -= cannonBallPower - 1;
                spriteRenderer.color = Color.white;
            }
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;  
    }
    //Hace un reflejo para conseguir nueva direccion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionNormal = collision.contacts[0].normal;
        
        direction = Vector2.Reflect(direction, collisionNormal).normalized;

        if (collision.transform.CompareTag("Block"))
        {
            blockHitSound.Play();
        }
        if (collision.transform.CompareTag("Player"))
        {
            playerHitSound.Play();
        }
    }

    //pone la duracion del buff de Fastball
    public void FastBallSpeedReset(float buffDuration, float buffPower)
    {
        fastBallDuration = buffDuration;
        fastBallMultiplier = buffPower;
    }
    //pone la duracion del buff de Slowball
    public void SlowBallSpeedReset(float buffDuration, float buffPower)
    {
        slowBallDuration = buffDuration;
        slowBallMultiplier = buffPower;
    }
    //pone la duracion del buff de DamageBall
    public void DamageBallDmgReset(float buffDuration, int buffPower)
    {
        damageBallDuration = buffDuration;
        damageBallPower = buffPower;
    }
    //pone la duracion del buff de CannonBall
    public void CannonBallDmgReset(float buffDuration, int buffPower)
    {
        cannonBallDuration = buffDuration;
        cannonBallPower = buffPower;
    }
}
