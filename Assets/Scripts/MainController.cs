using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int lives = 3;
    public bool small;
    public bool normal;
    public bool large;
    private CapsuleCollider2D capsuleCollider2D;
    private Vector2 normalSize;
    [SerializeField] private float sizeDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite normalSprite;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalSize = new Vector2(0.97f, 0.256f);
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;
    }

    //Movimiento
    private void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    }
    
    //Timer para volver a tamaño normal
    public void Resize()
    {
        Invoke("NormalSize", sizeDuration);
    }
   
    //Cambio el tamaño a normal y pongo las variables en falso
    private void NormalSize()
    {
        capsuleCollider2D.size = normalSize;
        spriteRenderer.sprite = normalSprite;
        small = false;
        large = false;
    }
}
