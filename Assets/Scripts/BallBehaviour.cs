using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    #region Variables
    private Vector3 direction = Vector3.down;
    public float speed;
    public int dmg;
    private Vector2 collisionNormal;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    public bool slowBallOn;
    public float slowBallDuration;
    public float slowBallMultiplier;
    public bool fastBallOn;
    public float fastBallDuration;
    public float fastBallMultiplier;
    public bool damageBallOn;
    public float damageBallDuration;
    public int damageBallPower;
    public bool cannonBallOn;
    public float cannonBallDuration;
    public int cannonBallPower;
    #endregion

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
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
        direction = Vector2.Reflect(direction, collisionNormal);
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
