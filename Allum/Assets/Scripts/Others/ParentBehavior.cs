using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBehavior : MonoBehaviour
{
    public static bool showParent;

    private void Update()
    {
        if (SaveManager.instance.SecondMissionStart && SaveManager.instance.FirstMissionComplete)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
