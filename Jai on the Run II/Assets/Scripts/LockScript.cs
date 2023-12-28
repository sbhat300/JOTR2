using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class LockScript : MonoBehaviour
{
    [SerializeField] AudioSource[] doors;
    [SerializeField] PhoneController phone;
    public int curr;
    Coroutine currentAudio;
    float timer;
    public bool firstLocked;
    [SerializeField] GameObject dumpa;
    ColorGrading colorGrading;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip dumpaEnter;
    public void SetNewLocation() 
    {
        int newDoor = Random.Range(0, 7);
        doors[curr].enabled = false;
        firstLocked = true;
        StopCoroutine(currentAudio);
        StartCoroutine(SetNewLocation(newDoor));
    }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Tut") dumpa.SetActive(false);
        curr = Random.Range(0, 7);
        foreach(AudioSource a in doors) {
            a.enabled = false;
            a.gameObject.transform.parent.eulerAngles = new Vector3(0, 0, 0);
        }
        currentAudio = StartCoroutine(PlaySound());
        print(curr + 1);
        timer = 0;
        firstLocked = false;
        
        Camera.main.gameObject.GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings(out colorGrading);
        colorGrading.mixerRedOutRedIn.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(phone.looking != -1) {
            doors[curr].maxDistance = 40;
            if(phone.looking != curr) doors[curr].volume = 0;
            else doors[curr].volume = 0.2f;
        }
        else {
            doors[curr].maxDistance = 4;
            doors[curr].volume = 0.2f;
        }
        timer += Time.deltaTime;
        if(timer > 60 && SceneManager.GetActiveScene().name != "Tut") 
        {
            Vector3 current = doors[curr].gameObject.transform.parent.eulerAngles;
            if(curr == 0 || curr == 3 ||curr == 4 ||  curr == 5)
                doors[curr].gameObject.transform.parent.eulerAngles = new Vector3(current.x, current.y + 90, current.z);
            else
                doors[curr].gameObject.transform.parent.eulerAngles = new Vector3(current.x, current.y - 90, current.z);
            dumpa.transform.position = doors[curr].transform.position;
            dumpa.SetActive(true);
            colorGrading.mixerRedOutRedIn.value = 200;
            doors[curr].enabled = false;
            StopCoroutine(currentAudio);
            audioSource.PlayOneShot(dumpaEnter);
            this.enabled = false;
        }
    }
    IEnumerator PlaySound() 
    {
        while(true) 
        {
            doors[curr].enabled = true;
            doors[curr].Play();
            yield return new WaitForSeconds(10);
        }
    }
    IEnumerator SetNewLocation(int loc) {
        yield return new WaitForSeconds(10);
        curr = loc;
        doors[curr].enabled = true;
        print(curr + 1);
        timer = 0;
        currentAudio = StartCoroutine(PlaySound());
    }
}
