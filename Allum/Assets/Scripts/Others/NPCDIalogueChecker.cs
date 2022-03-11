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
    }

    private void Start()
    {
        NPCName = this.gameObject.name;
    }
    private void Update()
    {
        NPCName = this.gameObject.name;
        if (Player.current.DialogueIsDone && !NPCDialogueDone)
        {
            NPCDialogueDone = true;
            SaveManager.instance.NPCs.Add(NPCName);
        }

        foreach (string NPCnames in SaveManager.instance.NPCs)
        {
            if (NPCName == NPCnames)
            {
                NPCDialogueDone = true;
                if (NPCDialogueDone)
                {
                    Player.current.DialogueIsDone = true;
                }
            }
        }
    }
}
