using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer1 : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 7.0f;
    private Vector3 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveVector.x = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        moveVector.z = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        moveVector.y = 0;

        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }

}