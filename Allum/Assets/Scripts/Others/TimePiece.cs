using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePiece : MonoBehaviour
{
    public static bool timepieceAppear;
    public bool isPast;
    public static bool timePieceDialogue;
    private void Update()
    {
        if (SaveManager.instance.FirstMissionComplete)
        {
            isPast = true;
            Debug.Log(ItemDialogueTrigger.dialogueFinished + " " + timePieceDialogue);
            if (ItemDialogueTrigger.dialogueFinished && timePieceDialogue)
            {
                Debug.Log("check1");
                timepieceAppear = true;
            }

            if (timepieceAppear)
            {
                isPast = false;
                timePieceDialogue = false;
                this.gameObject.SetActive(false);
                return;
            }
            if (PastFuture.change)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("check2");
            this.gameObject.SetActive(false);
        }

        if (isPast)
        {
            Debug.Log("check");
            this.gameObject.SetActive(true);
        }
    }
}
