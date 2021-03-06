using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    private void Update()
    {
        if (MenuController.isStartPanel && !SceneFader.unmovable)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        SoundManager.PlaySound("menuBtn");
                        if (index < maxIndex)
                            index++;
                        else
                            index = 0;
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        SoundManager.PlaySound("menuBtn");
                        if (index > 0)
                            index--;
                        else   
                            index = maxIndex;
                    }
                    keyDown = true;
                }
            }
            else
                keyDown = false;
        }
        else
        {
            if (!SceneFader.unmovable)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (!keyDown)
                    {
                        if (Input.GetAxis("Horizontal") > 0)
                        {
                            SoundManager.PlaySound("menuBtn");
                            if (index < maxIndex)
                                index++;
                            else
                                index = 0;
                        }
                        else if (Input.GetAxis("Horizontal") < 0)
                        {
                            SoundManager.PlaySound("menuBtn");
                            if (index > 0)
                                index--;
                            else   
                                index = maxIndex;
                        }
                        keyDown = true;
                    }
                }
                else
                    keyDown = false;
            }
        }
        
    }
}
