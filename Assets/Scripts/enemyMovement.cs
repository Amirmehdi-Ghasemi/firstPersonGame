using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 200f;

    void FixedUpdate()
    {
        rb.position += transform.forward * speed * Time.deltaTime;

    }
}
