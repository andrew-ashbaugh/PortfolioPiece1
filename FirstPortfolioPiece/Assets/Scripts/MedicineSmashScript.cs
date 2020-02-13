using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineSmashScript : MonoBehaviour
{
    public Collider2D[] colls;
    public Rigidbody2D[] rbs;
    public GameObject medicineSprite;
    public bool smashed;
    public CrateScript cs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && smashed == false || other.gameObject.tag == "Sled" && smashed == false)
        {
            Smash();
        }
    }

    public void Smash()
    {
        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = true;
            rbs[i].bodyType = RigidbodyType2D.Dynamic;
        }
        smashed = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
        medicineSprite.SetActive(false);
        cs.medicine.Remove(gameObject);
        Destroy(gameObject, 2f);
    }
}
