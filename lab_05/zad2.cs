using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
   public Transform doorTransform;
    public Transform openPosition;
    public float speed = 2.0f;
    public float activationDistance = 3.0f;

    private Vector3 closedPosition;

    void Start()
    {
        closedPosition = doorTransform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(doorTransform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (distanceToPlayer < activationDistance)
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, openPosition.position, speed * Time.deltaTime);
        }
        else
        {
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, closedPosition, speed * Time.deltaTime);
        }
    }
}
