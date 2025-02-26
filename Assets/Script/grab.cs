using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    private bool isGrabbed = false;
    private Camera mainCamera;
    private Vector3 offset;
    public Vector3 position;
    public Quaternion rotation;

    void Start()
    {
        mainCamera = Camera.main;
        position = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {
        // Keep the object's Z position always zero
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (isGrabbed)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -mainCamera.transform.position.z; // Convert to world space
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;
            transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        else
        {
            transform.position = position;
           // transform.rotation = rotation;
        }
    }

    void OnMouseDown()
    {
        isGrabbed = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        offset = transform.position - worldPosition;
    }

    void OnMouseUp()
    {
        isGrabbed = false;
    }


}