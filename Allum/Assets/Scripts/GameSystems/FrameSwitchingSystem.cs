using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitchingSystem : MonoBehaviour
{
    public GameObject activeFrame;
    public GameObject[] frames;

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
