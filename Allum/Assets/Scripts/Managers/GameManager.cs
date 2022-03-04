using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
