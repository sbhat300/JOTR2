using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    [SerializeField] AudioClip click;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] TextMeshProUGUI text;
    public int charge;
    Coroutine chargeRoutine;
    [SerializeField] Light flash;
    bool fading;
    float time;
    PhoneController phoneController;
    bool on;
    bool chargeable;
    bool charging;
    float timer;
    [SerializeField] AudioSource chargerAudio;
    AudioClip charger;
    [SerializeField] Transform jai;
    public bool godMode;
    [SerializeField] Collider flashlightCollider;
    JaiNavMesh jaiMesh;
    public bool touchingJai;
    public bool firstCharge;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        charge = 100;
        flashlight.SetActive(true);
        phoneController = GetComponent<PhoneController>();
        chargeRoutine = StartCoroutine(ChangeCharge());
        on = true;
        jaiMesh = jai.GetComponent<JaiNavMesh>();
        touchingJai = false;
        firstCharge = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerMovement.dead)
        {
            if(godMode) charge = 100;
            if(!jaiMesh.stunned)
            {
                if(flashlight.activeInHierarchy) jaiMesh.speed = 7;
                else jaiMesh.speed = 14;
            }
            timer += Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space) && charge > 0 && !phoneController.phoneOut && !charging) 
            { 
                audioPlayer.PlayOneShot(click);
                flashlight.SetActive(!flashlight.activeSelf);
                on = !on;
                if(flashlight.activeSelf) 
                {
                    charge -= 10;
                    text.text = Mathf.Clamp(charge, 0, 100) + "%";
                    if(touchingJai) {
                        jaiMesh.StunStart();
                    }
                }
            }
            if(fading) {
                time += Time.deltaTime;
                flash.intensity = 3.5f * Mathf.Cos(6 * time) + 3.5f;
                if(time > 1.57f) {
                    fading = false;
                    flash.intensity = 0;
                    charge = 0;
                }
            }
            if(Input.GetKey(KeyCode.E) && chargeable && timer > 1) {
                bool resetRoutine = false;
                if(charge <= 0) {
                    resetRoutine = true;
                } 
                firstCharge = true;
                fading = false;
                time = 0;
                flash.intensity = 7;
                charge = Mathf.Clamp(charge + 10, 0, 100);
                text.text = charge + "%";
                charging = true;
                timer = 0;
                on = true;
                flashlight.SetActive(true);
                if(!chargerAudio.isPlaying) {
                    chargerAudio.Play();
                }
                if(resetRoutine) {
                    resetRoutine = false;
                    chargeRoutine = StartCoroutine(ChangeCharge());
                    resetRoutine = true;
                }
            }
            if(charging && !Input.GetKey(KeyCode.E)) {
                charging = false;
                chargerAudio.Stop();
            }
        }
    }

    IEnumerator ChangeCharge() {
        text.text = charge + "%";
        while(charge > 0) 
        {
            yield return new WaitForSeconds(1.2f);
            if(!charging)
            {
                if(flashlight.activeInHierarchy) charge -= 2;
                else charge -= 1;
                text.text = charge + "%";
            }
        }
        text.text = "0%";
        charge = 0;
        time = 0;
        fading = true;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Charger") chargeable = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Charger"){
            chargeable = false;
            charging = false;
            chargerAudio.Stop();
            timer = 0;
        }
    }
}
