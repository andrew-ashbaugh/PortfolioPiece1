using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject sled;
    public LayerMask sledLayer;
    public Transform endCast;
    public int jumpForce;
    public ScrollSpeed gameManager;
    private Vector3 scale;
    public Animator anim;
    public GameObject prompt1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        scale = transform.localScale;
      
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D coll = Physics2D.Linecast(transform.position, endCast.position, sledLayer).collider; // used for balancing the character
        speed = Input.GetAxis("Horizontal") * 5f;
        if (coll != null)
        {
            transform.up += coll.transform.up * Time.deltaTime * 5;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(speed, rb.velocity.y); // player movement
            //  rb.velocity = sled.GetComponent<Rigidbody2D>().velocity;
            anim.SetBool("inAir", false);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x + -0.001f* gameManager.speed, rb.velocity.y);
            rb.velocity = new Vector2(speed/2, rb.velocity.y); // player movement
            rb.constraints = RigidbodyConstraints2D.None;
            anim.SetBool("inAir", true);
        }


        if(speed == 0)
        {
            anim.SetBool("isWalk", false);
        }
        else
        {
            prompt1.GetComponent<Animator>().SetBool("FadeOut", true);
            if (coll!=null)
            {
                anim.SetBool("isWalk", true);
            }
        }

        if (coll == null)
        {
            anim.SetBool("isWalk", false);
        }

      
            if (speed > 0.1f)
            {

                transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            }
            else if (speed < -0.1f)
            {

                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);

            }
        
      

        if(Input.GetButtonDown("Fire1") && coll!=null) // jumping
        {
            rb.AddForce(Vector3.up * jumpForce);
        }


       
    }
}
