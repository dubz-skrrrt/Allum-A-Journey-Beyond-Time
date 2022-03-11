using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public static InteractionSystem instance;
    public Transform DetectionPoint;
    public Sprite thoughtBubble;
    public Sprite thoughtBubbleEye;
    public Sprite thoughtBubbleDoor;
    public Sprite thoughtBubbleWalk;
    public GameObject NPCDialogue;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public bool interacting;
    public GameObject interactablePrompt;
    public bool isCreated;
    private bool isDoor;
    private bool isItem;
    private bool isNPC;

    private void Awake()
    {
        instance = this;
    }
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
                SoundManager.PlaySound("btnPressed");
                interacting = true;
                isCreated = true;
                if (isNPC)
                {
                    NPCDialogue.GetComponent<DialogueTrigger>().isInteracting = true;
                    isNPC = false;
                }
                if (isItem)
                {
                    NPCDialogue.GetComponent<ItemDialogueTrigger>().isInteracting = true;
                    isItem = false;
                }
                if (isDoor)
                {
                    SoundManager.PlaySound("Open");
                    isDoor = false;
                }
                
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
            isNPC = true;
        }
        if (other.gameObject.layer == 6)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubbleEye;
            isItem = true;
        }
        if (other.gameObject.layer == 10)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubbleDoor;
            isDoor = true;
        }
         if (other.gameObject.layer == 11)
        {
            NPCDialogue = other.gameObject;
            interactablePrompt.GetComponent<SpriteRenderer>().sprite = thoughtBubbleWalk;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 6 || other.gameObject.layer == 9)
        {
            isItem = false;
            isNPC = false;
            isDoor = false;
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
