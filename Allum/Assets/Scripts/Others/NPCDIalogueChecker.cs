using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDIalogueChecker : MonoBehaviour
{
    public static string NPCName;
    public static bool NPCDialogueDone;
    public static NPCDIalogueChecker instance;

    private void Awake()
    {
        instance = this;
        NPCName = this.gameObject.name;
    }

    private void Start()
    {
        //NPCName = this.gameObject.name;
    }
    private void Update()
    {
        Debug.Log(NPCDialogueDone);
        if (Player.current.DialogueIsDone)
        {
            NPCDialogueDone = true;
            Debug.Log("saved to list");
        }
    }
}
