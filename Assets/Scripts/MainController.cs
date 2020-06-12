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
    public Camera mainCamera;
    private LineRenderer lineRenderer;
    public Transform laserHit;
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
}
