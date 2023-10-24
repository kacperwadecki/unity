using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float speed = 1.0f; 
    private float initialPositionX; 
    private float targetPositionX; 
    private bool movingForward = true; 

    private void Start()
    {
        initialPositionX = transform.position.x;
        targetPositionX = initialPositionX + 10;
    }

    private void Update()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPositionX, transform.position.y, transform.position.z), speed * Time.deltaTime);
            
            if (transform.position.x >= targetPositionX)
                movingForward = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialPositionX, transform.position.y, transform.position.z), speed * Time.deltaTime);

            if (transform.position.x <= initialPositionX)
                movingForward = true;
        }
    }}
