using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Transform button;
    public Vector3 scale;
    private Color defaultColor;
    public Color hoverColor;
    // Start is called before the first frame update
    void Start()
    {
        scale = button.localScale;
        defaultColor = button.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ScaleUp(GameObject obj)
    {
        obj.transform.localScale = scale*1.1f;
        obj.GetComponent<Image>().color = hoverColor;
    }

    public void ScaleDown(GameObject obj)
    {
        obj.transform.localScale = scale;
        obj.GetComponent<Image>().color = defaultColor;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
