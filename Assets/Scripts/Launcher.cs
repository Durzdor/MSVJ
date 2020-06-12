using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //largo del rayo
    [SerializeField] private float rayLength = 10f;

    //Layer con las que collisiona
    [SerializeField] private LayerMask layersToHit;

    //componente line renderer
    [SerializeField] private LineRenderer lineRenderer;

    //cantidad de puntos que tiene la linea
    [SerializeField] private int pointsAmount;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        //cantidad de puntos maximos que tiene el render
        lineRenderer.positionCount = pointsAmount;
    }

    private void Update()
    {

        // Vector3 pos = transform.position;
        // RaycastHit2D hit2D = Physics2D.Raycast(pos, transform.right, rayLength, layersToHit);
        // if (hit2D)
        // {
        //     Debug.DrawLine(pos, pos + transform.right * rayLength, Color.red);
        //     var dir1 = pos - new Vector3(hit2D.point.x,hit2D.point.y,0); 
        //     lineRenderer.positionCount += 1;
        //     lineRenderer.SetPosition(0, pos);
        //     lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit2D.point);
        //     RaycastHit2D hit2D2 = Physics2D.Raycast(hit2D.point, Vector2.Reflect(dir1, hit2D.normal).normalized,
        //         rayLength, layersToHit);
        //     if (hit2D2)
        //     {
        //         Debug.DrawLine(hit2D.point, hit2D2.point * rayLength, Color.red);
        //         lineRenderer.positionCount += 1;
        //         lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit2D2.point);
        //     }
        // }
        // else
        // {
        //     lineRenderer.positionCount = 0;           
        //     Debug.DrawLine(pos, pos + transform.right * rayLength, Color.green);

    }
}
            
            


 
           
