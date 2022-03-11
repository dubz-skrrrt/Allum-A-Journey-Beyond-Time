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
            if (ItemDialogueTrigger.dialogueFinished && timePieceDialogue)
            {
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
            this.gameObject.SetActive(false);
        }

        if (isPast)
        {
            this.gameObject.SetActive(true);
        }
    }
}
