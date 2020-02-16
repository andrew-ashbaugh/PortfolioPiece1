using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MedicineCalculator : MonoBehaviour
{
    public int meds;
    public int tempMeds;
    public List<CrateScript> crates;
    public TextMeshProUGUI medicineText;
    public Color oneMedLeft;
    private Color medDefault;

    // Start is called before the first frame update

    void Start()
    {
        meds = 3;
        medDefault = medicineText.color;
        InvokeRepeating("CalcMeds", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        medicineText.text = meds.ToString();

    }


    void CalcMeds()
    {
        tempMeds = 0;
        for (int i = 0; i < crates.Count; i++)
        {
            tempMeds += crates[i].medicine.Count;
        }
       
        meds = tempMeds;
        if (meds < 2)
        {
            medicineText.color = oneMedLeft;
        }
        else
        {
            medicineText.color = medDefault;
        }

      
    }
}
