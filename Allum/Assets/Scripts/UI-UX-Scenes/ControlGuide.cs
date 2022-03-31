using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGuide : MonoBehaviour
{
    public GameObject helpIcon;
    public GameObject helpPanel;

    private void Start()
    {
        helpPanel.SetActive(false);
    }
    private void Update()
    {
        if (SaveManager.instance.canWalk && !InteractionSystem.instance.interacting)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                helpPanel.SetActive(true);
                helpIcon.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                helpPanel.SetActive(false);
                helpIcon.SetActive(true);
            }
        }
        
        if (InteractionSystem.instance.interacting)
        {
            helpIcon.SetActive(false);
        }else
        {
            helpIcon.SetActive(true);
        }

    }
}
