using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRespawnScript : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public GameObject[] gapPrefabs;
    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            if(Random.Range(0,5) >3) // 25% change to spawn gap
            {
                Instantiate(gapPrefabs[Random.Range(0, gapPrefabs.Length)],spawnLocation.position,Quaternion.identity);
            }
            else
            {
                Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Length)], spawnLocation.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
        }
    }

}
