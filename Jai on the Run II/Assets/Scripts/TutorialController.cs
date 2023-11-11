using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TutorialController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject enter;
    [SerializeField] LockScript lockScript;
    [SerializeField] FlashlightController flashlightController;
    [SerializeField] GameObject jai;
    [SerializeField] JaiNavMesh jaiNavMesh;
    // Start is called before the first frame update
    void Start()
    {
        enter.SetActive(true);
        text.text = "Welcome to Jai on the Run 2";
        StartCoroutine("Tutorial");
        flashlightController.godMode = true;
        jai.SetActive(false);
        jaiNavMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Tutorial() 
    {
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Press space to turn on and off your flashlight";
        enter.SetActive(false);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        while (Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        enter.SetActive(true);
        text.text = "Turning on your flashlight normally consumes 10% power";
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Press Q to open your map";
        enter.SetActive(false);
        while (!Input.GetKeyDown(KeyCode.Q))
        {
            yield return null;
        }
        text.text = "You are the red indicator";
        enter.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Press the keys 1-7 to look at the cameras in your map";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Listen for knocking in one of the rooms";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Press the number of the camera you are looking at to close the camera, head to the room, and press enter when you reach";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Head towards the door and hold E near it to lock it";
        enter.SetActive(false);
        while (!lockScript.firstLocked)
        {
            yield return null;
        }
        enter.SetActive(true);
        text.text = "You have 60 second to lock the door, if the door is not locked in time Dumpa will catch you";
        while (!lockScript.firstLocked)
        {
            yield return null;
        }
        text.text = "After you lock a door, Dumpa will try another door in 10 seconds";
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        flashlightController.godMode = false;
        text.text = "Your flashlight's battery will slowly go down while off, and go down faster while it is on";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Head to the room marked E on your map and press enter when you reach";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        enter.SetActive(false);
        text.text = "Stand near the charger and hold E to charge your flashlight";
        while(!flashlightController.firstCharge) 
        {
            yield return null;
        }
        enter.SetActive(true);
        text.text = "Head to the center room and press enter";
        while(!Input.GetKeyDown(KeyCode.Return)) 
        {
            yield return null;
        }
        jai.transform.position = new Vector3(-3.5999999f,0.709999979f,43.4000015f);
        jai.SetActive(true);
        jaiNavMesh.audioSource.Pause();
        text.text = "This is Jai";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Jai will always chase you, don't let him catch you";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "He moves faster when your flashlight is off";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "You can stun him by flashing him with your flashlight (turning it on while looking at him)";
        while (Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        text.text = "Try flashing him, he can't hurt you if he's stunned";
        jaiNavMesh.enabled = true;
        jaiNavMesh.audioSource.Play();
        enter.SetActive(false);
        while (!jaiNavMesh.firstFlash)
        {
            yield return null;
        }
        enter.SetActive(true);
        text.text = "You are ready to enter Jai's domain. Good luck.";
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        SceneManager.LoadScene("Main Menu");
    }
}
