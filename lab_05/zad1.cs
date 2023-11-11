using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 1.0f;

    private Vector3 startPosition;
    private bool isActivated = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isActivated)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        if (transform.position == targetPosition.position)
        {
            Vector3 temp = targetPosition.position;
            targetPosition.position = startPosition;
            startPosition = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = true;
        }
    }
}
