using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play() 
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Tutorial() 
    {
        SceneManager.LoadScene("Tut");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
