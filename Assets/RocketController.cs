using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField]
 private float rocketRotationSpeed;
    [SerializeField]
    private float rocketThrustSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveRocketUp();
    }

    private void MoveRocketUp()
    {
        RocketThrust();
        RocketRotate();







        /* Assignment: use left and Right and up arrows to control the movement of the rocket.*/
    }

    private void RocketRotate()
    {
        //rb.freezeRotation = false;
        float speed = 100f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rocketRotationSpeed = speed* Time.deltaTime;
            transform.Rotate(Vector3.forward*rocketRotationSpeed);
            Debug.Log("Forward Rotation");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rocketRotationSpeed = speed* Time.deltaTime;
            transform.Rotate(Vector3.back*rocketRotationSpeed);
            Debug.Log("Backward Rotation");
        }
    }

    private void RocketThrust()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           float thrust=100f;
            rocketThrustSpeed = thrust * Time.deltaTime;
            rb.AddRelativeForce(Vector3.up*rocketThrustSpeed);

            Debug.Log("Going Up");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "WallCollision")
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }

}


