using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
  public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float planeSize = 10f;

    private HashSet<Vector3> usedPositions = new HashSet<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnCubesOverTime());
    }

    IEnumerator SpawnCubesOverTime()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            SpawnCube();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnCube()
    {
        Vector3 randomPosition;

        do
        {
            randomPosition = new Vector3(
                Random.Range(-planeSize / 2, planeSize / 2),
                0.5f,  
                Random.Range(-planeSize / 2, planeSize / 2)
            );
        } 
        while (usedPositions.Contains(randomPosition));

        usedPositions.Add(randomPosition);
        Instantiate(cubePrefab, randomPosition, Quaternion.identity);
    }
}
