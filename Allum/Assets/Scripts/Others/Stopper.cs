using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    public GameObject stopper;
    [SerializeField] bool iskey;
    private void Awake()
    {
        if (stopper == null)
            stopper = null;

        if (NPCDIalogueChecker.NPCDialogueDone)
        {
            stopper.SetActive(false);
        }
        else
        {
            stopper.SetActive(true);
        }
    }
    
    private void Update()
    {
        if (NPCDIalogueChecker.NPCDialogueDone)
        {
            foreach(var name in SaveManager.instance.data.NPCNames)
            {
                Debug.Log(name + " is found");
                if (name == NPCDIalogueChecker.NPCName)
                {
                    Player.current.DialogueIsDone = true;
                }
            }
        }
        
        if (SaveManager.instance.FirstMissionComplete)
        {
            this.gameObject.SetActive(true);
        }
        Debug.Log(NPCDIalogueChecker.NPCDialogueDone);
        if (NPCDIalogueChecker.NPCDialogueDone && Player.current.DialogueIsDone)
        {
            Debug.Log("stop");
            stopper.SetActive(false);
            if (SaveManager.instance.FirstMissionComplete)
            {
                SaveManager.instance.SavePlayer();
            }
            if (SaveManager.instance.SecondMissionStart)
            {
                SaveManager.instance.SavePlayer();
            }
        }
        else
        {
            if (SaveManager.instance.keyFound && iskey)
            {
                SaveManager.instance.SavePlayer();
                stopper.SetActive(false);
            }
            else
            {
                stopper.SetActive(true);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("hitting");

            ItemDialogueTrigger.onCollide = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!SaveManager.instance.FirstMissionComplete)
            {
                SaveManager.instance.FirstMissionComplete = false;
            }
            if (!SaveManager.instance.SecondMissionStart)
            {
                SaveManager.instance.SecondMissionStart = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(SaveManager.instance.FirstMissionComplete)
            {
                ParentBehavior.showParent = true;
                SaveManager.instance.SecondMissionStart = true;
                
            }
            SaveManager.instance.FirstMissionComplete = true;
        }
    }
}
