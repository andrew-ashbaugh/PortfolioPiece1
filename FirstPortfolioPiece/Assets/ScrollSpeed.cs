using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeed : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public List<GroundMovement> grounds;
    private bool gas;
    private bool stop;
    public float defaultGroundSpeed;
    public float defaultMidGroundSpeed;
    public float defaultFarBGSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            if (grounds[i].gameObject.tag == "Ground")
            {
                grounds[i].speed = defaultGroundSpeed * speed;
            }
            else if(grounds[i].gameObject.tag == "MidGround")
            {
                grounds[i].speed = defaultMidGroundSpeed * speed;
            }
            else if (grounds[i].gameObject.tag == "FarBG")
            {
                grounds[i].speed = defaultFarBGSpeed * speed;
            }
        }

        if(speed<3)
        {
            speed += 0.01f;
        }
        else
        {
            speed -= 0.01f;
        }

        if(gas == true)
        {
            if (speed < maxSpeed)
            {
                speed += 0.1f;
            }
            else
            {
                speed = maxSpeed;
            }
        }

        if(stop == true)
        {
            if (speed > 3)
            {
                speed -= 0.1f;
            }
            else
            {
                speed = 3;
            }
        }
    }

    public void Gas()
    {
        gas = true;
    }

    public void EndGas()
    {
        gas = false;
    }

    public void Break()
    {
        stop = true;
    }

    public void EndBreak()
    {
        stop = false;
    }
}
