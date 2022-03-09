using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchMiniGame : MonoBehaviour
{
    public GameObject halfRight;
    public GameObject halfLeft;
    public GameObject panel;
    public bool combineWatch;
    public static WatchMiniGame instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (combineWatch)
        {
            panel.SetActive(true);
            
        }
        else
        {
            panel.SetActive(false);
            
        }

        if (panel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                halfLeft.transform.position += new Vector3(0.5f, 0 ,0) * 0.895f;
                halfRight.transform.position += new Vector3(-0.5f, 0 ,0) * 0.895f;
            }
        }
    }
}
