using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitUp : MonoBehaviour
{
    public float wait;
    public StepCpontroller StepCpontroller;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(next());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator next()
    {
        yield return new WaitForSeconds(wait);
        StepCpontroller.steps += 1;
        Destroy(gameObject);
    }
}
