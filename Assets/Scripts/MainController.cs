using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class MainController : MonoBehaviour
{
    #region Variables
    private Vector3 direction;
    [SerializeField] private float speed = 10f;
    [HideInInspector] public bool smallPowerOn;
    [HideInInspector] public float smallPowerDuration;
    [HideInInspector] public float smallPowerMultiplier;
    [HideInInspector] public bool largePowerOn;
    [HideInInspector] public float largePowerDuration;
    [HideInInspector] public float largePowerMultiplier;
    private Rigidbody2D rb2D;
    [HideInInspector] public bool magnetPowerOn;
    [HideInInspector] public float magnetPowerDuration;
    public Camera mainCamera;
    private LineRenderer lineRenderer;
    public Transform LaserHit;
    #endregion

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
        FollowMouse();
        //lo que pasa si esta ShrinkPowerup
        if (smallPowerOn)
        {
            smallPowerDuration -= Time.deltaTime;

            if (smallPowerDuration <= 0)
            {
                smallPowerOn = false;
                GameManager.Instance.NormalPlayer(smallPowerMultiplier);
            }
        }
        //lo que pasa si esta EnlargePowerup
        if (largePowerOn)
        {
            largePowerDuration -= Time.deltaTime;

            if (largePowerDuration <= 0)
            {
                largePowerOn = false;
                GameManager.Instance.NormalPlayer(largePowerMultiplier);
            }
        }
        //lo que pasa si esta MagnetPowerup
        if (magnetPowerOn)
        {
            magnetPowerDuration -= Time.deltaTime;

            if (magnetPowerDuration <= 0)
            {
                magnetPowerOn = false;
            }
        }
    }
    private void FixedUpdate()
    {
        rb2D.velocity = direction * speed;
    }
    //Magnet Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && magnetPowerOn)
        {
            Vector2 freeze = Vector2.zero;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = freeze;
            collision.gameObject.GetComponent<BallBehaviour>().direction = freeze;
        }
    }
    //Movimiento
    private void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    }
    //propiedades de ShrinkPowerup
    public void ShrinkPlayerReset(float buffDuration, float sizeMultiplier)
    {
        smallPowerDuration = buffDuration;
        smallPowerMultiplier = sizeMultiplier;
    }
    //propiedades de EnlargePowerup
    public void EnlargePlayerReset(float buffDuration, float sizeMultiplier)
    {
        largePowerDuration = buffDuration;
        largePowerMultiplier = sizeMultiplier;
    }
    //propiedades de MagnetPowerup
    public void MagnetPlayerReset(float buffDuration)
    {
        magnetPowerDuration = buffDuration;
    }

    public void FollowMouse()
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Transform spawnLocation = transform.Find("StartPoint");
        Vector2 spawnPosition = spawnLocation.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);
        LaserHit.position = hit.point;
        lineRenderer.SetPosition(0, spawnPosition);
        lineRenderer.SetPosition(1, mouseWorldPosition);
    }
}
