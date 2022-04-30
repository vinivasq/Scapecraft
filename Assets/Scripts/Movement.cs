using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] AudioClip thrustSFX;

    [SerializeField] ParticleSystem rightThrusterVSX;
    [SerializeField] ParticleSystem leftThrusterVFX;
    [SerializeField] ParticleSystem mainThrusterVFX;

    Rigidbody rb; 
    AudioSource audioSource;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSFX);

            }
            if (!mainThrusterVFX.isPlaying)
            {
                mainThrusterVFX.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
            mainThrusterVFX.Stop();
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
            if (!leftThrusterVFX.isPlaying)
            {
                leftThrusterVFX.Play();
            }
            
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
            if (!rightThrusterVSX.isPlaying)
            {
                rightThrusterVSX.Play();
            }
        }
        else
        {
            rightThrusterVSX.Stop();
            leftThrusterVFX.Stop();
        }
    }

    private void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can rotate manually 
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezong rotation so the phisics system can take over
    }
}
