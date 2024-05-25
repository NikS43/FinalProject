using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer2 : MonoBehaviour
{
    private int gameStatus;
    private GameObject cam;
    private Rigidbody rb;
    private float speed = 7.0f;
    private Vector3 moveVector;

    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        gameStatus = cam.GetComponent<Game>().gameStatus;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        gameStatus = cam.GetComponent<Game>().gameStatus;
        if ( gameStatus == 1 )
        {
            moveVector.x = Convert.ToInt32(Input.GetKey(KeyCode.L)) - Convert.ToInt32(Input.GetKey(KeyCode.J));
            moveVector.z = Convert.ToInt32(Input.GetKey(KeyCode.I)) - Convert.ToInt32(Input.GetKey(KeyCode.K));
            moveVector.y = 0;

            rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

            if (transform.position.y < -2)
            {
                gameObject.SetActive(false);
            }
        }
       
    }

}
