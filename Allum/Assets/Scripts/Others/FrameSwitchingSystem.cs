using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchingSystem : MonoBehaviour
{
    public GameObject activeFrame;
    public GameObject past;
    public GameObject future;
    public GameObject timePiece;
    private bool timepieceAppear;
    public static bool pastTime;
    public GameObject[] frames;

    private void Update()
    {
        if (SaveManager.instance.FirstMissionComplete)
        {
            if (!timepieceAppear)
            {
                timePiece.SetActive(true);
                if (pastTime)
                {
                    Debug.Log(ItemDialogueTrigger.instance.dialogueFinished);
                    past.SetActive(true);
                    future.SetActive(false);
                    if (ItemDialogueTrigger.instance.dialogueFinished)
                    {
                        Debug.Log("Hide");
                        timepieceAppear = true;
                    }
                }
            }else
            {
                timePiece.SetActive(false);
            }
            
            
        }
        else
        {
            timePiece.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activeFrame.SetActive(true);
            for (int i = 0; i < frames.Length; i++)
            {
               frames[i].SetActive(false);
            }
        }
    }
}
