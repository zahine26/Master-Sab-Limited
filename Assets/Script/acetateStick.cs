using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acetateStick : MonoBehaviour
{
    public StepCpontroller stepCpontroller;
    public Vector3 newPosition;
    bool done;

    public Transform crystal;
    bool crystalOn;
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

        if(crystalOn)
        {
            crystal.gameObject.SetActive(true);
            crystal.localScale = Vector3.Lerp(crystal.localScale,new Vector3(.7f,.7f,.7f),Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            grab grab = other.GetComponent<grab>();
            grab.position = newPosition;
            done = true;
        }
    }



    IEnumerator nextStep()
    {
        yield return new WaitForSeconds(1f);
        stepCpontroller.steps += 1;
        // hitUp.SetActive(true);
        //Destroy(gameObject);
        crystalOn = true;
    }
}
