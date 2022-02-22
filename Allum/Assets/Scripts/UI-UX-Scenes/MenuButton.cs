using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    
    public int thisIndex;
    private void Update()
    {
        if (MenuController.isStartPanel)
        {
            if (menuButtonController.index == thisIndex)
            {
                animator.SetBool("selected", true);
                if (Input.GetAxis("Submit") == 1)
                {
                    Debug.Log("pressed1");
                    animator.SetBool("pressed", true);
                }
                else if (animator.GetBool ("pressed"))
                {
                    animator.SetBool("pressed", false);
                    //animatorFunctions.disableOnce = true;
                }
            }
            else
            {
                animator.SetBool ("selected", false);
            }
        }
        else
        {
            if (menuButtonController.index == thisIndex)
            {
                animator.SetBool("selected", true);
                if (Input.GetAxis("Submit") == 1)
                {
                    Debug.Log("pressed");
                    animator.SetBool("pressed", true);
                }
                else if (animator.GetBool ("pressed"))
                {
                    animator.SetBool("pressed", false);
                    //animatorFunctions.disableOnce = true;
                }
            }
            else
            {
                animator.SetBool ("selected", false);
            }
        }
        
            
    }

}
