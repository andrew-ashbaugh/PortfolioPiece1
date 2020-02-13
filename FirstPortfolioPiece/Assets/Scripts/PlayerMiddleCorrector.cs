using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiddleCorrector : MonoBehaviour
{
    public Transform middlePoint;
    public Transform sled;
    public Transform dog;
    private Rigidbody2D sledRb;
    private Rigidbody2D dogRb;
    public float dogDist;
    // Start is called before the first frame update
    void Start()
    {
        sledRb = sled.GetComponent<Rigidbody2D>();
        dogRb = dog.GetComponent<Rigidbody2D>();
        dogDist = Vector3.Distance(dog.transform.position, sled.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sled.transform.position.x <middlePoint.position.x)
        {
            sledRb.velocity += new Vector2(0.1f,0); // speeds sled up if not close to middle
        }

        if(Vector3.Distance(dog.position,sled.position) > dogDist)
        {
            dogRb.velocity -= new Vector2(0.15f, 0); // speeds sled up if not close to middle
        }
        if(Vector3.Distance(dog.position, sled.position) < dogDist)
        {
            dogRb.velocity += new Vector2(0.15f, 0); // speeds sled up if not close to middle
        }
    }
}
