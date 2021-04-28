

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float offcetToCamera;
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;
    public bool gameOver = false;

    Camera cam;
    Vector3 acceleration;
    float rotationRad;
    float dx, dy;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {

        if (gameOver)
        {
            return;
        }
        var inputSteer = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, steeringSpeed * inputSteer * Time.deltaTime * -1);
        CalcRotation();

        CalcMovement(inputY);
        Move();


       
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.HandleCollision(other.gameObject);
    }


    void CalcRotation()
    {
        var rotation = transform.rotation.eulerAngles.z;
        rotationRad = rotation / 360 * 2 * Mathf.PI;
    }

    void CalcMovement(float inputY)
    {
        dx = -Mathf.Sin(rotationRad);
        dy = Mathf.Cos(rotationRad);
        acceleration = new Vector3(dx, dy) * accBrakeSpeed * inputY;
        offcetToCamera -= acceleration.y;
    }

    void Move()
    {
        transform.position += new Vector3(dx, dy) * moveSpeed * Time.deltaTime + acceleration;

        var camPosition = cam.transform.position;
        camPosition.y = transform.position.y + offcetToCamera;
        cam.transform.position = camPosition;

        //var camPosition = new Vector3(cam.transform.position.x, transform.position.y + offcetToCamera) ;
        //cam.transform.position = camPosition;
    }
}
