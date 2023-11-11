using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DumpNavMesh : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float speed;
    [SerializeField] Transform movePos;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = 20;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePos.position;
        navMeshAgent.speed = speed;
    }
}
