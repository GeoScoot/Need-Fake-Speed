using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var inputSteer = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * steeringSpeed * inputSteer * Time.deltaTime;


        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        var camPosition = cam.transform.position;
        camPosition.y = transform.position.y;
        cam.transform.position = camPosition;
    }
}
