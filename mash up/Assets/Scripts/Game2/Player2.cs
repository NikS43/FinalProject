using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
        moveVector.x = Convert.ToInt32(Input.GetKey(KeyCode.L)) - Convert.ToInt32(Input.GetKey(KeyCode.J));
        moveVector.z = Convert.ToInt32(Input.GetKey(KeyCode.I)) - Convert.ToInt32(Input.GetKey(KeyCode.K));
        moveVector.y = 0;

        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }

}
