using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partticleControl : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float currentRate = 0f;
    public float duration = 2f;
    private float previousRate;
    private float elapsedTime = 0f;
    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }
        emission = particleSystem.emission;
        previousRate = emission.rateOverTime.constant;
    }

    void Update()
    {
        if (Mathf.Approximately(previousRate, currentRate)) return;

        if (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float newRate = Mathf.Lerp(previousRate, currentRate, t);
            emission.rateOverTime = newRate;
            elapsedTime += Time.deltaTime;
        }
        else
        {
            emission.rateOverTime = currentRate;
            previousRate = currentRate;
            elapsedTime = 0f;
        }
    }
}
