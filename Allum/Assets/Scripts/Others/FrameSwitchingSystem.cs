using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchingSystem : MonoBehaviour
{
    public GameObject activeFrame;
    public GameObject past;
    public GameObject future;
    public static FrameSwitchingSystem instance;
    public static bool pastTime;
    public GameObject[] frames;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (SaveManager.instance.FirstMissionComplete)
        {
            if (pastTime)
            {
                past.SetActive(true);
                future.SetActive(false);
            } 
        }
        else
        {
            past.SetActive(false);
            future.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activeFrame.SetActive(true);
            for (int i = 0; i < frames.Length; i++)
            {
               frames[i].SetActive(false);
            }
        }
    }
}
