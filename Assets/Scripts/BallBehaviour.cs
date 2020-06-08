using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Vector3 direction = Vector3.down;
    public float speed;
    [SerializeField] private float normalSpeed;
    public int dmg;
    [SerializeField] private int baseDmg;
    private Vector2 collisionNormal;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    public bool slowBallOn;
    public float slowBallDuration;
    public bool fastBallOn;
    public float fastBallDuration;
    public bool damageBallOn;
    public float damageBallDuration;
    public bool cannonBallOn;
    public float cannonBallDuration;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (fastBallOn)
        {
            fastBallDuration -= Time.deltaTime;
            if (fastBallDuration <= 0)
            {
                speed = normalSpeed;
                fastBallOn = false;
            }
        }
        if (slowBallOn)
        {
            slowBallDuration -= Time.deltaTime;
            if (slowBallDuration <= 0)
            {
                speed = normalSpeed;
                slowBallOn = false;
            }
        }
        if (damageBallOn)
        {
            damageBallDuration -= Time.deltaTime;
            if (damageBallDuration <= 0)
            {
                dmg = baseDmg;
                damageBallOn = false;
                spriteRenderer.color = Color.white;
            }
        }
        if (cannonBallOn)
        {
            cannonBallDuration -= Time.deltaTime;
            circleCollider2D.enabled = true;

            if (cannonBallDuration <= 0)
            {
                dmg = baseDmg;
                cannonBallOn = false;
                spriteRenderer.color = Color.white;
                circleCollider2D.enabled = false;
            }
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;
    }

    //Cuando colisiona se fija la normal del objeto colisionado
    //Hace un reflejo para conseguir nueva direccion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionNormal = collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, collisionNormal);
    }

    //CannonBall Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }

    //pone la duracion del buff de Fastball
    public void FastBallSpeedReset(float buffDuration)
    {
        fastBallDuration = buffDuration;
    }

    //pone la duracion del buff de Slowball
    public void SlowBallSpeedReset(float buffDuration)
    {
        slowBallDuration = buffDuration;
    }

    //pone la duracion del buff de DamageBall
    public void DamageBallDmgReset(float buffDuration)
    {
        damageBallDuration = buffDuration;
    }

    //pone la duracion del buff de CannonBall
    public void CannonBallDmgReset(float buffDuration)
    {
        cannonBallDuration = buffDuration;
    }
}
