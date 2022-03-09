using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBehavior : MonoBehaviour
{
    public static bool showKid;

    private void Update()
    {
        if (showKid)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
