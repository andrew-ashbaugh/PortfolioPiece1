using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBalancer : MonoBehaviour
{
    public GameObject sled;
    public LayerMask sledLayer;
    public Transform endCast;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D coll = Physics2D.Linecast(transform.position, endCast.position, sledLayer).collider;
        if(coll!= null)
        {
            transform.up += sled.transform.up * Time.deltaTime;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
          //  rb.velocity = sled.GetComponent<Rigidbody2D>().velocity;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
      
       
    }
}
