using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public List<GameObject> medicine;
    public MedicineCalculator medCalc;
    public bool destroy;
    // Start is called before the first frame update
    void Start()
    {
        medCalc = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<MedicineCalculator>();
        medCalc.crates.Add(gameObject.GetComponent<CrateScript>());
    }

    // Update is called once per frame
    void Update()
    {
        if(medicine.Count == 0 && destroy == false)
        {
            Destroy(gameObject,2);
            medCalc.crates.Remove(gameObject.GetComponent<CrateScript>());
            destroy = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            for (int i = 0; i < medicine.Count; i++)
            {
                medicine[i].GetComponent<MedicineSmashScript>().Smash();
            }
        }
    }
}
