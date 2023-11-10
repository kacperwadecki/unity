using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;

    public GameObject block;
    public Material[] materials; 
    public int numberOfObjects = 10; 

    public float platformSize = 20.0f;

    void Start()
    {
        for(int i=0; i<numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(-platformSize / 2, platformSize / 2);
            float randomZ = UnityEngine.Random.Range(-platformSize / 2, platformSize / 2);
            positions.Add(new Vector3(randomX, 5, randomZ));
        }


        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        foreach(Vector3 pos in positions)
        {
            var createdBlock = Instantiate(this.block, pos, Quaternion.identity);
            
            if(materials.Length > 0)
            {
                var randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                createdBlock.GetComponent<Renderer>().material = randomMaterial;
            }
            
            yield return new WaitForSeconds(this.delay);
        }
    }
}
