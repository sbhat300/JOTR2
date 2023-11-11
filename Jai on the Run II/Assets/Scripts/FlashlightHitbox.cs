using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHitbox : MonoBehaviour
{
    [SerializeField] FlashlightController fc;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Jai"){
            fc.touchingJai = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Jai"){
            fc.touchingJai = false;
        }
    }
}
