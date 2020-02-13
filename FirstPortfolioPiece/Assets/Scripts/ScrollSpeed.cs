using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public Transform commandPos;
    public GameObject commandCanvas;
    public Animator commandAnim;
    public TextMeshProUGUI commandText;
    public bool hasPrompt;
    public GameObject prompt2;
    public GameObject prompt1;
    public ParticleSystem snow;
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

           var  main = snow.main;
           main.simulationSpeed = 0.5f * speed;
        if(prompt1.GetComponent<Animator>().GetBool("FadeOut") == true && prompt1.transform.GetChild(1).GetComponent<Image>().color.a <0.5f)
        {
            if(prompt2.activeSelf == false)
            {
                prompt2.SetActive(true);
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

        commandCanvas.transform.position = commandPos.position;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Gas();
            if(commandCanvas.activeSelf == false)
            {
                commandCanvas.SetActive(true);
            }
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            EndGas();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Break();
            if (commandCanvas.activeSelf == false)
            {
                commandCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            EndBreak();
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {   if (commandCanvas.activeSelf == true)
            {
                commandAnim.SetBool("StartCommand", true);
            }
            if (prompt2.activeSelf == true)
            {
                prompt2.GetComponent<Animator>().SetBool("FadeOut",true);
            }
        }
        else
        {
            if (commandCanvas.activeSelf == true)
            {
                commandAnim.SetBool("StartCommand", false);
            }
        }
    }

    public void Gas()
    {
        gas = true;
        commandText.text = "Mush!";
       
    }

    public void EndGas()
    {
        gas = false;
      
    }

    public void Break()
    {
        stop = true;
        commandText.text = "Whoa!";
        
    }

    public void EndBreak()
    {
        stop = false;
      
    }
}
