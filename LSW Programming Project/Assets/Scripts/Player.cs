using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Vector2 moveVec = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        moveVec.Normalize();
        gameObject.transform.Translate(moveVec*.01f*Speed);
    }
}
