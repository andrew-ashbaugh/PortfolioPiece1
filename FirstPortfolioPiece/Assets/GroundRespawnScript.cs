using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRespawnScript : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public GameObject[] gapPrefabs;
    public Transform spawnLocation;
    public ScrollSpeed gameManager;
    public GameObject midGroundPrefab;
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
        if (other.gameObject.tag == "Ground")
        {
            if (Random.Range(0, 5) > 3) // 25% change to spawn gap
            {
                GameObject tempGround = (GameObject)Instantiate(gapPrefabs[Random.Range(0, gapPrefabs.Length)], spawnLocation.position, Quaternion.identity);
                gameManager.grounds.Add(tempGround.GetComponent<GroundMovement>());
            }
            else
            {
                GameObject tempGround = (GameObject)Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Length)], spawnLocation.position, Quaternion.identity);
                gameManager.grounds.Add(tempGround.GetComponent<GroundMovement>());
            }

            gameManager.grounds.Remove(other.gameObject.GetComponent<GroundMovement>());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "MidGround")
        {
            GameObject tempGround = Instantiate(midGroundPrefab, spawnLocation.position, Quaternion.identity);
            gameManager.grounds.Add(tempGround.GetComponent<GroundMovement>());
            Destroy(other.gameObject);
        }
    }

}
