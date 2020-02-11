using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawReign : MonoBehaviour
{
    public LineRenderer lr;
    public Transform reignEnd;
    public float distance;
    public Vector3[] pointPos;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 10; // create 10 points
        pointPos = new Vector3[10]; // create 9 other points throughout the reign
       
    }

    // Update is called once per frame
    void Update()
    {
       // lr.SetPosition(0, transform.position); // set the first position to be the hands pos
        distance = Vector3.Distance(transform.position, reignEnd.position); // grabs the distance between the reign start and end point
        for (int i = 0; i < pointPos.Length; i++)
        {
           // pointPos[i] = (transform.position + reignEnd.position)/i;
            pointPos[i] = distance/10 *(i+1)* Vector3.Normalize(reignEnd.position - transform.position) + transform.position;
        }
        for (int j = 0; j < lr.positionCount; j++) // loop through all positions except first
        {
            if (j!=0)
            {
                lr.SetPosition(j, pointPos[j]);
            }
            else
            {
                lr.SetPosition(j, transform.position);
            }
         
        }
    }
}
