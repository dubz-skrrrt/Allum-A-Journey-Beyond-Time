using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform DetectionPoint;
    public Sprite thoughtBubble;
    public Sprite thoughtBubbleEye;
    public Sprite thoughtBubbleDoor;
    public GameObject NPCDialogue;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public bool interacting;
    public GameObject interactablePrompt;
    public bool isCreated;
    private bool isDoor;
 
    private void Update()
    {
        if (DetectObject())
        {
            if (isCreated)
            {
                interactablePrompt.SetActive(false);
            }else
            {
                interactablePrompt.SetActive(true);
            }
            if (InteractInput())
            {
                isCreated = true;
                interacting = true;
                if (!isDoor)
                    NPCDialogue.GetComponent<DialogueTrigger>().isInteracting = true;
                
            }
            
        }else
        {
            interactablePrompt.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubble;
        }
        if (other.gameObject.layer == 6)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubbleEye;
        }
        if (other.gameObject.layer == 10)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubbleDoor;
            isDoor = true;
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
