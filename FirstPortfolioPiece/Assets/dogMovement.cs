using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public ScrollSpeed gameManager;
    public GameObject player;
    public float maxDist;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < maxDist)
        {
            rb.velocity = new Vector2(4f * gameManager.speed *2, rb.velocity.y);
            Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        }
  
    }
}
