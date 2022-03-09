using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastFuture : MonoBehaviour
{
    public GameObject past;
    public GameObject future;
    public static bool change;
    private void Update()
    {
        if (change)
        {
            future.SetActive(true);
            past.SetActive(false);
        }
        else
        {
            future.SetActive(false);
            past.SetActive(true);
        }
    }
}
