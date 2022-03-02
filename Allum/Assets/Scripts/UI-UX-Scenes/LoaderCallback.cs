using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;
    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            StartCoroutine(LoadingDelay());
        }
    }

    IEnumerator LoadingDelay()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("now");
        Loader.OnLoaderCallBack();
    }
}
