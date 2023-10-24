using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float lerpTime = 0.5f;
    private float yVelocity = 0.0f;

    void Update()
    {
        // SmoothDampChase();
        LerpChase();
    }

    void SmoothDampChase()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }

    void LerpChase()
    {
        float newPosition = Mathf.Lerp(transform.position.y, target.position.y, lerpTime * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}
