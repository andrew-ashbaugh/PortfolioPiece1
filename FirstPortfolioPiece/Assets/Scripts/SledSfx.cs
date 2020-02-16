using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledSfx : MonoBehaviour
{
    public AudioSource aud;
    public Transform startCast;
    public Transform endCast;
    public LayerMask groundLayer;
    public GameObject snowParts;
    public ScrollSpeed ss;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D coll = Physics2D.Linecast(startCast.position, endCast.position, groundLayer); // used for balancing the character

        if(coll.collider!= null)
        {
            if(aud.isPlaying == false)
            {
                aud.Play();
            }
            if(timer >= 0.25f / (ss.speed / 2))
            {
                Instantiate(snowParts, coll.point, Quaternion.identity);
                timer = 0;
            }
          
        }
        else
        {
            aud.Pause();
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }
}
