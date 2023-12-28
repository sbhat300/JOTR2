using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class JaiNavMesh : MonoBehaviour
{
    [SerializeField] Transform movePos;
    public NavMeshAgent navMeshAgent;
    public bool stunned;
    public AudioSource audioSource;
    public AudioSource jaiClips;
    public AudioClip[] sounds;
    public float speed;
    public bool firstFlash;
    // Start is called before the first frame update
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = 7;
        
    }
    void Start()
    {
        StartCoroutine(PlaySound());
        stunned = false;
        firstFlash = false;
        if(SceneManager.GetActiveScene().name != "Tut")
        {
            transform.position = new Vector3(-3.5999999f,0.709999979f,-10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePos.position;
        if(!stunned) navMeshAgent.speed = speed;
    }
    public void StunStart() { 
        if(!stunned) StartCoroutine(Stun());
    }
    IEnumerator Stun() {
        firstFlash = true;
        navMeshAgent.speed = 0;
        speed = 0;
        stunned = true;
        audioSource.Pause();
        yield return new WaitForSeconds(5);
        audioSource.Play();
        stunned = false;
    }
    IEnumerator PlaySound()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(10, 15));
            jaiClips.clip = sounds[Random.Range(0,3)];
            jaiClips.Play();
        }
    }
}
