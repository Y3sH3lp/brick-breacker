using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlecontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 _position;
    public float speed = 30f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _position =  Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _position =  Vector2.right;
        }
        else
        {
            _position =  Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (_position == Vector2.zero){
            return;
        }
        rb.AddForce(_position * speed);
    }
}
