using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(playerController))]
[RequireComponent(typeof(gunController))]
public class player : MonoBehaviour
{
    public float moveSpeed = 5;
    playerController controller;
    gunController gunController;
    
    Camera viewCamera;
    void Start()
    {
        controller = GetComponent<playerController>();
        gunController = GetComponent<gunController>();

        viewCamera = Camera.main;
    }


    void Update()
    {
        //mouvement du joueur
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 inputVelocity = input.normalized * moveSpeed;
        controller.Move (inputVelocity);

        //visée du joueur
        Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast (ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);

            controller.LookAt(point);
        }
        //arme du joueur
        if (Input.GetMouseButton(0))
        {
            gunController.shoot();
        }
    }
}   
