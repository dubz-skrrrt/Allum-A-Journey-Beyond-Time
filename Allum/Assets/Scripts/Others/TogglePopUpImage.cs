using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePopUpImage : MonoBehaviour
{
    public static bool show;
    public GameObject thisObject;
    void Update()
    {
        if (show)
        {
            thisObject.SetActive(true);
        }
        else
        {
            thisObject.SetActive(false);
        }
    }
}
