using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb; 
    AudioSource thrustSFX;
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 200f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustSFX = GetComponent<AudioSource>();

    }

    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
            if (!thrustSFX.isPlaying)
            {
                thrustSFX.Play();
            }
        }
        else
        {
            thrustSFX.Stop();
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can rotate manually 
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezong rotation so the phisics system can take over
    }
}
