using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserRenderer;
    [SerializeField] private int laserDistance = 100;
    [SerializeField] private int numberReflectMax = 5;
    public Camera mainCamera;
    public GameObject ballObject;
    private BallBehaviour ballController;
    private Vector2 directLaser = new Vector2();
    private bool loopActive = true;
    public LayerMask layersToHit;
    private void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
        ballController = ballObject.GetComponent<BallBehaviour>();
    }

    private void Update()
    {
        DrawLaser();
    }

    public void DrawLaser()
    {
        loopActive = true;
        int countLaser = 1;

        //posicion inicial
        Transform spawnLocation = transform.Find("StartPoint");
        Vector2 spawnPosition = spawnLocation.position;
        
        //direccion de posicion al mouse
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        directLaser = mouseWorldPosition - spawnPosition;
        var initialPos = directLaser.normalized;

        //mandar directLaser a ball como direccion;
        laserRenderer.positionCount = countLaser;
        laserRenderer.SetPosition(0, spawnPosition);
        
        laserRenderer.startWidth = 0.03f;
        laserRenderer.endWidth = 0.03f;
        laserRenderer.startColor = Color.red;
        laserRenderer.endColor = Color.red;

        while (loopActive)
        {
            // rayo desde posicion inicial en direccion al mouse, con largo y restriccion
            RaycastHit2D hit = Physics2D.Raycast(spawnPosition, directLaser, laserDistance, layersToHit);
            // si existe el golpe
            if (hit)
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                directLaser = Vector2.Reflect(directLaser, hit.normal);
                spawnPosition = (Vector2)directLaser.normalized + hit.point;
                laserRenderer.SetPosition(countLaser -1, hit.point);
            }
            else
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                laserRenderer.SetPosition(countLaser - 1, spawnPosition + (directLaser.normalized * laserDistance));
                loopActive = false;
            }
            if (countLaser > numberReflectMax)
            {
                loopActive = false;
            }
        }

        if (!ballController.isStopped) return;

        if (Input.GetMouseButton(0))
        {
            GameManager.Instance.Shoot(initialPos);
            laserRenderer.enabled = false;
        }
    }
}


