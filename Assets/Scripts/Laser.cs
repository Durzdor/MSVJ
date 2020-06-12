using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserRenderer;
    [SerializeField] private int laserDistance = 100;
    [SerializeField] private int numberReflectMax = 5;
    private Vector3 pos = new Vector3();
    private Vector3 directLaser = new Vector3();
    private bool loopActive = true;
    public LayerMask layersToHit;
    private void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
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
        pos = transform.position;
        //direccion de posicion al mouse
        directLaser = Camera.main.ScreenToWorldPoint(Input.mousePosition) - pos;
        //mandar directLaser a ball como direccion;
        laserRenderer.positionCount = countLaser;
        laserRenderer.SetPosition(0, pos);

        laserRenderer.startWidth = 0.025f;
        laserRenderer.endWidth = 0.025f;
        laserRenderer.startColor = Color.red;
        laserRenderer.endColor = Color.red;

        while (loopActive)
        {
            // rayo desde posicion inicial en direccion al mouse, con largo y restriccion
            RaycastHit2D hit = Physics2D.Raycast(pos, directLaser, laserDistance, layersToHit);
            // si existe el golpe
            if (hit)
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                directLaser = Vector3.Reflect(directLaser, hit.normal);
                pos = (Vector2)directLaser.normalized + hit.point;
                laserRenderer.SetPosition(countLaser -1, hit.point);
            }
            else
            {
                countLaser++;
                laserRenderer.positionCount = countLaser;
                laserRenderer.SetPosition(countLaser - 1, pos + (directLaser.normalized * laserDistance));
                loopActive = false;
            }
            if (countLaser > numberReflectMax)
            {
                loopActive = false;
            }
        }

    }
}


