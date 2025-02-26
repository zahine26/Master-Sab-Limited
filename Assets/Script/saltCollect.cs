using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltCollect : MonoBehaviour
{
    public GameObject NextButton;
    public GameObject salt;
    public Transform spoon;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            done = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn" && !done)
        {
            NextButton.SetActive(true);
            GameObject go = Instantiate(salt, spoon.position, Quaternion.identity);
            done = true;
        }
    }
}
