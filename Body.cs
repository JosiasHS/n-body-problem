using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Rigidbody rb;
    public float v0x, v0y, v0z;

    private float G = 7;
    private void Start()
    {
        rb.AddForce(new Vector3(v0x, v0y, v0z), ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        Body[] Bodies = FindObjectsOfType<Body>();

        foreach (Body bodyToAttract in Bodies)
        {
            if (bodyToAttract != this)
            {
                GravityField(bodyToAttract);
            }
        }
    }
    void GravityField(Body p1)
    {
        Rigidbody rbP1 = p1.GetComponent<Rigidbody>();
        Vector3 r = rb.position - rbP1.position;
        float distance = r.magnitude;

        float forceMagnitude = rb.mass * rbP1.mass * G / Mathf.Pow(distance, 2);
        Vector3 force = r.normalized * forceMagnitude;

        rbP1.AddForce(force);
    }
}
