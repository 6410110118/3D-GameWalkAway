using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource myAudio;
    public float raycastDistance = 0.1f;
    public Transform raycastOrigin;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Ray ray = new Ray(raycastOrigin.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance)) { 
                if(hit.collider.tag == "Untagged") {
                    myAudio.Play();
                }
                if(hit.collider.tag == "Platform") { 
                }
            }
        }

    }

   
}
