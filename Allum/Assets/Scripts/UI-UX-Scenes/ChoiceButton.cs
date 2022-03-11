using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] InteractionSystem interactionSystem;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] Animator animator;
    public int thisIndex;

    private void Awake()
    {
        interactionSystem = FindObjectOfType<InteractionSystem>(true);
        
    }
    private void Update()
    {
        if (interactionSystem.interacting)
        {
            dialogueTrigger = interactionSystem.NPCDialogue.GetComponent<DialogueTrigger>();
        
            if (dialogueTrigger.textDisplayDone)
            {
                if (dialogueTrigger.choiceIndex == thisIndex)
                {
                    animator.SetBool("selected", true);
                    if (Input.GetAxis("Submit") == 1)
                    {
                        animator.SetBool("pressed", true);
                        
                    }
                    else if (animator.GetBool ("pressed"))
                    {
                        animator.SetBool("pressed", false);

                    }
                }
                else
                {
                    animator.SetBool ("selected", false);
                }
            }
        }
    }

    public void OnPressResponse()
    {
        dialogueTrigger.choiceResponse();
        dialogueTrigger.textDisplayDone = false;
    }
}
