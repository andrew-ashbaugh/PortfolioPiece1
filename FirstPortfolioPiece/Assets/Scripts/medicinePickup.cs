using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medicinePickup : MonoBehaviour
{
    public GameObject cratePrefab;
    public Vector3 sled;
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
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            sled = GameObject.FindGameObjectWithTag("Sled").transform.GetChild(2).position;
            sled = new Vector3(sled.x + Random.Range(-0.3f, 0.8f), sled.y + 1, sled.z);
            Instantiate(cratePrefab, sled, Quaternion.identity);
        }
    }
}
