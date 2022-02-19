using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] MenuController menuController;
    public bool disableOnce; 

    public void EnableSavePanel()
    {
        if (menuButtonController.index == 0)
        {
            menuController.GetComponent<Animation>().Play("MenuTransition");
        }
    }
}
