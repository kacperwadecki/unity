using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
     public List<Vector3> waypoints;
    public int currentWaypointIndex = 0;
    public float speed = 2.0f;
    private bool movingForward = true;

    void Update()
    {
        if (waypoints.Count == 0) return;

        Vector3 targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

        if (transform.position == targetWaypoint)
        {
            if (movingForward)
            {
                if (currentWaypointIndex + 1 < waypoints.Count)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    movingForward = false;
                    currentWaypointIndex--;
                }
            }
            else
            {
                if (currentWaypointIndex - 1 >= 0)
                {
                    currentWaypointIndex--;
                }
                else
                {
                    movingForward = true;
                    currentWaypointIndex++;
                }
            }
        }
    }
}
