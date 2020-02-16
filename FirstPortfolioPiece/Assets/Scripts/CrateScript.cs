using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public List<GameObject> medicine;
    public MedicineCalculator medCalc;
    public bool destroy;
    public GameObject hitFx;
    public AudioSource hitAud;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        medCalc = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<MedicineCalculator>();
        medCalc.crates.Add(gameObject.GetComponent<CrateScript>());
        hitAud = gameObject.GetComponent<AudioSource>();
        hitAud.pitch = Random.Range(0.6f, 1f);
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

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            for (int i = 0; i < medicine.Count; i++)
            {
                medicine[i].GetComponent<MedicineSmashScript>().Smash();
                hitAud.pitch = Random.Range(0.6f, 1f);
                hitAud.Play();
                Instantiate(hitFx, transform.position, Quaternion.identity);
            }
        }
        
        if(timer>= 3f && other.gameObject.tag!= "Ground")
        {
            hitAud.pitch = Random.Range(0.6f, 1f);
            hitAud.Play();
            Instantiate(hitFx, transform.position, Quaternion.identity);
            timer = 0;
        }

    }

}
