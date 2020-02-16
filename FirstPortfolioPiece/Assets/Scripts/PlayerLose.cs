using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLose : MonoBehaviour
{
    public GameObject loseMenu;
    public TextMeshProUGUI loseText;
    public MedicineCalculator medCalc;

    public DistanceCalculator dc;
    public PlayerController pc;
    public ScrollSpeed ss;
    public bool playerDied;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (medCalc.meds == 0 && loseMenu.activeSelf == false) // if you havent lost yet, and you have no meds...
        {
            loseMenu.SetActive(true);
            loseText.text = "All your medicine broke!";
            PlayerDead();
        }

        if(playerDied == true && loseMenu.activeSelf == false) // if you havent lost yet, and you hit the ground...
        {
            loseMenu.SetActive(true);
            loseText.text = "You are incapacitated!";
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        ss.commandCanvas.SetActive(false);
        ss.dead = true;
        ss.Break();
        pc.anim.SetBool("isWalk",false);
        pc.anim.SetBool("inAir", false);
        pc.enabled = false;
        dc.calcDist = false;
        pc.rb.constraints = RigidbodyConstraints2D.None;

    }
}
