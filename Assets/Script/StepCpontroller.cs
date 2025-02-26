using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCpontroller : MonoBehaviour
{
    public int steps;
    public Transform grab;  // Assign in Inspector
    public Renderer Renderer;  // Assign in Inspector
    public Renderer Renderer_2;
    private float initialPour = 2f; // Start value of _feel
    private bool filteringStarted = false;
    public GameObject waterline;
    void Start()
    {
        initialPour = Renderer.material.GetFloat("_feel");
    }

    void Update()
    {
        if (steps == 6 && !filteringStarted)
        {
            filteringStarted = true;
            StartCoroutine(AnimateValues(5f));
        }
    }

    private IEnumerator AnimateValues(float duration)
    {
        float elapsedTime = 0f;
        float startRotation = 45;// grab.eulerAngles.z;
        waterline.SetActive(true);
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            // Rotate from current rotation to 90 degrees
            float newRotation = Mathf.Lerp(startRotation, 90f, t);
            grab.rotation = Quaternion.Euler(grab.eulerAngles.x, 180f, -newRotation);

            // Lerp _feel from 2 to 0
            float pourValue = Mathf.Lerp(initialPour, -0.9f, t);
            Renderer.material.SetFloat("_feel", pourValue);

            float pourValue2 = Mathf.Lerp(0.2f, 2f, t);
            Renderer_2.material.SetFloat("_feel", pourValue2);

            yield return null;
        }

        // Ensure final values are set correctly
        grab.rotation = Quaternion.Euler(grab.eulerAngles.x, 180f, -90f);
        Renderer.material.SetFloat("_feel", -.90f);
        Renderer_2.material.SetFloat("_feel", 2f);
        grab.gameObject.SetActive(false);
    }
}
