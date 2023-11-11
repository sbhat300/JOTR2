using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float camInput;
    public Transform camMountPoint;
    public float mouseSens;
    float verticalMov;
    float horizontalMov;
    public int walkSpeed;
    public Vector3 move;
    private CharacterController charController;
    [SerializeField] Animator anim;
    [SerializeField] GameObject jaiScare;
    [SerializeField] AudioClip jaiAudio;
    [SerializeField] GameObject dumpaScare;
    [SerializeField] AudioClip dumpaAudio;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject jai;
    [SerializeField] Timer t;
    [SerializeField] JaiNavMesh jaiNavMesh;
    float timer = 0;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        charController = GetComponent<CharacterController>();
        transform.position = new Vector3(-4.39010572f,1.42019463f,78.3572159f);
        transform.eulerAngles = new Vector3(2.3374517f,178.382614f,0.000182015225f);
        jaiScare.SetActive(false);
        dumpaScare.SetActive(false);
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {
            LookRotation();
            Movement();
            Move();
        }
        if(dead) 
        {
            timer += Time.deltaTime;
        }
        if(timer > 2.48f) SceneManager.LoadScene("End");
    }
    void LookRotation()
    {
        camInput -= Input.GetAxis("Mouse Y") * mouseSens * Time.unscaledDeltaTime;
        camInput = Mathf.Clamp(camInput, -90, 90);
        camMountPoint.localEulerAngles = new Vector3(camInput, 0, 0);
        transform.rotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + (Input.GetAxis("Mouse X") * mouseSens * Time.unscaledDeltaTime), transform.localRotation.eulerAngles.z);
    }
    void Movement()
    {
        verticalMov = Input.GetAxis("Vertical") * walkSpeed;
        horizontalMov = Input.GetAxis("Horizontal") * walkSpeed;
        move = transform.forward * verticalMov + transform.right * horizontalMov;
    }
    void Move()
    {
        charController.Move(new Vector3(move.x, 0, move.z) * Time.deltaTime);
        if(move.x == 0 && move.z == 0) anim.speed = 0.5f;
        else anim.speed = 1.5f;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Jai" && !jaiNavMesh.stunned) 
        {
            jaiScare.SetActive(true);
            audioSource.PlayOneShot(jaiAudio);
            jai.SetActive(false);
            dead = true; 
            t.SetScore(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
         if(other.gameObject.tag == "Dumpa") 
        {
            dumpaScare.SetActive(true);
            audioSource.PlayOneShot(dumpaAudio);
            jai.SetActive(false);
            dead = true; 
            t.SetScore(1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
    }
}
