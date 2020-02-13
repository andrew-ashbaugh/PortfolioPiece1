using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMedicine : MonoBehaviour
{
    public Transform[] medicineSpawnPoints;
    public GameObject medicinePrefab;
    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0,101) <=10) // 10% to spawn medicine per ground 
        {
           Transform tempSpawn = medicineSpawnPoints[Random.Range(0, medicineSpawnPoints.Length)];
           GameObject meds = (GameObject)Instantiate(medicinePrefab,tempSpawn.position,Quaternion.identity); // pick a random spawn, and spawn the meds
           meds.transform.parent = tempSpawn;
        }

        if(Random.Range(0,101) <=75) // 75% chance to spawn a tree
        {
            int randomAmount = Random.Range(1, 8);
           
            for (int i = 0; i < randomAmount; i++)
            {
                Transform tempSpawn = new GameObject("TreeHolder").transform;
             
                tempSpawn.position = new Vector3(transform.position.x + Random.Range(3f, 10f), transform.position.y, transform.position.z);
                tempSpawn.transform.parent = gameObject.transform;
                GameObject tree = (GameObject)Instantiate(trees[Random.Range(0,trees.Length)], tempSpawn.position, Quaternion.identity);
                tree.transform.parent = tempSpawn;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
