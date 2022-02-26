using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform DetectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public bool interacting;
    public GameObject interactableText;
    private bool isCreated;

 
    private void Update()
    {
        if (DetectObject())
        {
           // interactableText.transform.position =
            interactableText.SetActive(true);
            isCreated = true;
            if (InteractInput())
            {
                interacting = true;
            }
            
        }else
        {
            interactableText.SetActive(false);
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(DetectionPoint.position, detectionRadius, detectionLayer);
    }
}
