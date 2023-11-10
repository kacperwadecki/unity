using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;

    private float pitch = 0f; // Dodano zmienną do śledzenia kąta nachylenia

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove);

        pitch -= mouseYMove; // Aktualizacja kąta nachylenia
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Ograniczenie kąta nachylenia do zakresu -90 do +90 stopni

        // Obrót kamery z zastosowaniem ograniczonego kąta nachylenia
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
