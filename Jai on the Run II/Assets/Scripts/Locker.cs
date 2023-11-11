using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public bool lockable;
    [SerializeField] float lockDuration;
    bool locking;
    public float timer;
    [SerializeField] LockScript lockScript;
    [SerializeField] AudioSource lockAudio;
    [SerializeField] GameObject flashlight;
    [SerializeField] bool flashOrig;
    // Start is called before the first frame update
    void Start()
    {
        lockable = false;
        locking = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(lockable && Input.GetKey(KeyCode.E))
        {
            locking = true;
            timer += Time.deltaTime;
            if(!lockAudio.isPlaying) {
                flashOrig = flashlight.activeInHierarchy;
                flashlight.SetActive(false);
                lockAudio.Play();
            }
        }
        else if(locking)
        {
            timer = 0;
            locking = false;
            flashlight.SetActive(flashOrig);
            lockAudio.Stop();
        }
        if(timer > lockDuration) 
        {
            lockScript.SetNewLocation();
            lockAudio.Stop();
            lockable = false;
            flashlight.SetActive(flashOrig);
            timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Door" && other.gameObject.GetComponent<AudioSource>().enabled == true) lockable = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Door") lockable = false;
    }
}
