using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform DetectionPoint;

    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;

    public GameObject interactableText;
    private bool isCreated;

    private void Update()
    {
        if (DetectObject())
        {
            interactableText.SetActive(true);
            isCreated = true;
            if (InteractInput())
            {
                Debug.Log("Interactable");
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
