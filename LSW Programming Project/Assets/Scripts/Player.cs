using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Rigidbody2D rb;
    private Vector2 moveVec = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Quitting");
        PlayerPrefs.DeleteAll();
    }

    private void FixedUpdate()
    {
        moveVec.Normalize();
        rb.MovePosition(rb.position + moveVec*.01f*Speed);
    }
}
