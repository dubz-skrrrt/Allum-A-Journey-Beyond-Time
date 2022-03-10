using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBehavior : MonoBehaviour
{
    public static bool showKid;
    public GameObject thisKid;
    private void Update()
    {
        Debug.Log(showKid);
        if (showKid)
        {
            thisKid.SetActive(true);
        }
        else
        {
            thisKid.SetActive(false);
        }
    }
}
