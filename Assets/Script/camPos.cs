using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camPos : MonoBehaviour
{
    public Transform[] position;
    public StepCpontroller StepCpontroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, position[StepCpontroller.steps].position, Time.deltaTime * 10f);
    }
}
