using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] DialogueTrigger dialogueTrigger;
    public int thisIndex;

    private void Awake()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();
    }
    private void Update()
    {
        if (dialogueTrigger.textDisplayDone)
        {
            if (dialogueTrigger.choiceIndex == thisIndex)
            {
                if (Input.GetAxis("Submit") == 1)
                {
                    dialogueTrigger.choiceResponse();
                    dialogueTrigger.textDisplayDone = false;
                }
            }
        }
    }
}
