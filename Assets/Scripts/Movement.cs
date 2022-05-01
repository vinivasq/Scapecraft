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
            StartThrusting();
        }
        else
        {
            StopThrust();
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

    void StartThrusting()
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

    void StopThrust()
    {
        audioSource.Stop();
        mainThrusterVFX.Stop();
    }

    void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can rotate manually 
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezong rotation so the phisics system can take over
    }

    void RotateRight()
    {
        ApplyRotation(-rotateSpeed);
        if (!rightThrusterVSX.isPlaying)
        {
            rightThrusterVSX.Play();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotateSpeed);
        if (!leftThrusterVFX.isPlaying)
        {
            leftThrusterVFX.Play();
        }    
    }

    void StopRotation()
    {
        rightThrusterVSX.Stop();
        leftThrusterVFX.Stop();
    }
}
