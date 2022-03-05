using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePiece : MonoBehaviour
{
    public static bool timepieceAppear;
    public bool isPast;

    private void Update()
    {
        if (SaveManager.instance.FirstMissionComplete)
        {
            isPast = true;
            if (ItemDialogueTrigger.dialogueFinished)
            {
                timepieceAppear = true;
            }

            if (timepieceAppear)
            {
                isPast = false;
                this.gameObject.SetActive(false);
                return;
            }

            if (isPast)
            {
                this.gameObject.SetActive(true);
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
