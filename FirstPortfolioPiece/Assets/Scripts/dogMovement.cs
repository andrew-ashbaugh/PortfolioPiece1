using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask sledLayer;
    public Transform endCast;
    public ScrollSpeed ss;
    public GameObject snowParts;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
      //  anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D coll = Physics2D.Linecast(transform.position, endCast.position, sledLayer);

        if(coll.collider == null)
        {
            anim.speed = 0;

        }
        else
        {
            if (timer >= 0.5f/(ss.speed/2))
            {
                Instantiate(snowParts, coll.point, Quaternion.identity);
                timer = 0;
            }
            if (ss.speed/10>0)
            {
                anim.speed = 1 + ss.speed / 10;
            }
            else
            {
                anim.speed = 1;
            }
         
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
}
