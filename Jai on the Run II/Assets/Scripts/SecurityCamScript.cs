 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 public class SecurityCamScript : MonoBehaviour
 {
 
    public Light lights;
    private void OnPreCull() 
    {
        lights.enabled = true;
    }
 
    void OnPostRender()
    {
        lights.enabled = false;
    }
 }