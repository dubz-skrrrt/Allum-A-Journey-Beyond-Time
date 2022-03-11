using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogueTriggerNPC : MonoBehaviour
{
    public bool trigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger = true;
           
             if (trigger)
            {
                this.GetComponent<DialogueTrigger>().isInteracting = true;
                Player.current.GetComponent<InteractionSystem>().NPCDialogue = this.gameObject;
                Player.current.GetComponent<InteractionSystem>().interacting = true;
                trigger = false;
            }
        }
    }
}
