using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public float speed = 1.0f; 

    private Vector3 initialPosition;
    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        initialPosition = transform.position;

        waypoints = new Vector3[4]
        {
            initialPosition,
            initialPosition + new Vector3(10, 0, 0),
            initialPosition + new Vector3(10, 0, 10),
            initialPosition + new Vector3(0, 0, 10)
        };
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            transform.Rotate(0, 90, 0);

            currentWaypointIndex = (currentWaypointIndex + 1) % 4;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);
    }
}
