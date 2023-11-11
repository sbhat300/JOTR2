using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    [SerializeField] GameObject phone;
    Animation anim;
    [SerializeField] GameObject flashlight;
    public bool phoneOut;
    [SerializeField] Camera secCam;
    [SerializeField] Texture[] camTextures;
    [SerializeField] Transform[] camMountPoints;
    [SerializeField] RawImage screen;
    [SerializeField] AudioListener mainListener;
    [SerializeField] AudioListener secListener;
    [SerializeField] AudioSource camAudio;
    public int looking;
    bool flashOrig;
    // Start is called before the first frame update
    void Start()
    {
        anim = phone.GetComponent<Animation>();
        phone.SetActive(false);
        phone.transform.localPosition = new Vector3(0, -1.36f, 1.569298f);
        phone.transform.rotation = Quaternion.Euler(90, 0, 0);
        mainListener.enabled = true;
        phoneOut = false;
        secListener.enabled = false;
        looking = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !anim.isPlaying) {
            if(!phone.activeSelf) 
            {
                phone.SetActive(true);
                flashOrig = flashlight.activeInHierarchy;
                flashlight.SetActive(false);
                phoneOut = true;
                anim.Play("PullOut");
                screen.texture = camTextures[0];
            }
            else 
            {
                anim.Play("PutBack");
                mainListener.enabled = true;
                secListener.enabled = false;
                StartCoroutine(WaitHide()); 
                looking = -1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && phoneOut) 
        {
            ChangeView(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && phoneOut)
        {
            ChangeView(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && phoneOut)
        {
            ChangeView(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && phoneOut) 
        {
            ChangeView(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && phoneOut)
        {
            ChangeView(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && phoneOut)
        {
            ChangeView(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7) && phoneOut)
        {
            ChangeView(6);
        }

    }
    public void ChangeView(int num) 
    {
        if(looking == -1) {
            camAudio.Play();
        }
        if(looking != num)
            {
                secCam.transform.position = camMountPoints[num].transform.position;
                secCam.transform.rotation = camMountPoints[num].transform.rotation;
                screen.texture = camTextures[1];
                looking = num;
                mainListener.enabled = false;
                secListener.enabled = true;
            }
            else 
            {
                screen.texture = camTextures[0];
                mainListener.enabled = true;
                secListener.enabled = false;
                camAudio.Stop();
                looking = -1;
            }
    }
    IEnumerator WaitHide() 
    {
        yield return new WaitForSeconds(0.25f);
        camAudio.Stop();
        looking = -1;
        flashlight.SetActive(flashOrig);
        phoneOut = false;
        phone.SetActive(false);
    }
}
