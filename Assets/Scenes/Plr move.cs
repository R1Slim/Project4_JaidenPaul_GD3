using UnityEngine;
using NUnit.Framework;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;
public class WASD : MonoBehaviour
{
    public Vector2 desired;
    public Vector2 movedir = Vector2.right; //default is right so that we can dodge right without moving
    public float smoothness = 0.0025f;
    public float speed = 5f;
    public Rigidbody2D rb;
    public BoxCollider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EasedDirection();
    }
    void EasedDirection()
    {
        desired = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("up");
            desired.y = speed;

        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("down");
            desired.y = -speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            desired.x = speed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("left");
            desired.x = -speed;
        }
        if (desired == Vector2.zero && rb.linearVelocity != Vector2.zero)
        {
            desired = -rb.linearVelocity * .5f;
        }
        Vector2 vel = Vector2.Lerp(rb.linearVelocity, desired, smoothness);
        rb.linearVelocity = vel;
    }

}