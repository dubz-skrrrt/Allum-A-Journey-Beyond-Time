using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    public bool trigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger = true;
           
             if (trigger)
            {
                this.GetComponent<ItemDialogueTrigger>().isInteracting = true;
                trigger = false;
            }
        }
    }
}
