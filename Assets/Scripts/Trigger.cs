using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    
     void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

    }
    public void OnTriggerEnter()
    {
        meshRenderer.enabled = true;

    }

}
