using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacles : MonoBehaviour
{
    public BoxCollider2D obstacleSpawn;
    public float checkRadius = 1.0f;

    public void Start() {
        RandomPose();
    }

    private void Update() {
        
    }

    private void RandomPose(){
        Bounds bounds = this.obstacleSpawn.bounds;
        bool isPositionValid;
        Vector3 potentialPosition;

        do {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            potentialPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

            isPositionValid = Physics2D.OverlapCircle(potentialPosition, checkRadius, LayerMask.GetMask("Food")) == null;
        } while (!isPositionValid);

        this.transform.position = potentialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            RandomPose();
        }
    }
}
