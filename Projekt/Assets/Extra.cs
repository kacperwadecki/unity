using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Extra : MonoBehaviour
{
    public BoxCollider2D extraSpawn;
    public float checkRadius = 1.0f; 

    private void Start() {
        StartCoroutine(SpawnObstacleRoutine());
    }

    private void Update() {
        
    }

    private IEnumerator SpawnObstacleRoutine() {
        while (true) {  
            RandomPose();
            yield return new WaitForSeconds(5f);  
        }
    }

    private void RandomPose(){
        Bounds bounds = this.extraSpawn.bounds;
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
