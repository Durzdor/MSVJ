using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed = 10f;
    public bool smallPowerOn;
    public float smallPowerDuration;
    public bool largePowerOn;
    public float largePowerDuration;
    private Rigidbody2D rb2D;

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
                GameManager.Instance.NormalPlayer();
            }
        }
        //lo que pasa si esta EnlargePowerup
        if (largePowerOn)
        {
            largePowerDuration -= Time.deltaTime;

            if (largePowerDuration <= 0)
            {
                largePowerOn = false;
                GameManager.Instance.NormalPlayer();
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
    public void ShrinkPlayerReset(float buffDuration)
    {
        smallPowerDuration = buffDuration;
    }
    //propiedades de EnlargePowerup
    public void EnlargePlayerReset(float buffDuration)
    {
        largePowerDuration = buffDuration;
    }
}
