using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filtering : MonoBehaviour
{
    public StepCpontroller stepCpontroller;
    public Vector3 newPosition;
    public Quaternion newRotation;
    public GameObject hitUp;
    bool done;
    public GameObject square;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && done)
        {
            done = false;
            StartCoroutine(nextStep());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            grab grab = other.GetComponent<grab>();
            grab.position = newPosition;
            grab.rotation = newRotation;
            done = true;
            square.SetActive(false);
        }
    }



    IEnumerator nextStep()
    {
        yield return new WaitForSeconds(1f);
        stepCpontroller.steps += 1;
       // hitUp.SetActive(true);
        Destroy(gameObject);
    }
}
