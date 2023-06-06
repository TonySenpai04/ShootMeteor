using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControllerUI.Instance.isOver == false)
        {
            Move();
        }
    }
    public void Move()
    {
        var move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * Speed, rb.velocity.y);
    }
}
