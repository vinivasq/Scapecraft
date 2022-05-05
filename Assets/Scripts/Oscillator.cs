using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 4f;

        void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time / period; // period define a velocidade em que os ciclos se repetem
        const float tau = Mathf.PI * 2; // 1 Tau é = 2Pi, ou seja, uma volta completa
        float rawSinWave = Mathf.Sin(cycles * tau); // vai de -1 a +1

        movementFactor = (rawSinWave + 1f) / 2f;  // RawSinWave retorna valores entre -1 e +1. Adicionar 1 e divindo por 2 retornara de 0 a 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
