using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTrigger : MonoBehaviour
{
    public float time;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "watch")
        {
            SoundManager.audioSrc.volume = 0.5f;
            SoundManager.PlaySound("quake");
            CameraShake.instance.ShakeCamera(3f, time);
            StartCoroutine(delay());
            
        }
        
    }

    IEnumerator delay()
    {
        
        yield return new WaitForSeconds(time);
        Loader.load("Outside");
        PastFuture.change = true;
        FrameSwitchingSystem.pastTime = false;
        WatchMiniGame.instance.combineWatch = false;
        SaveManager.instance.SavePlayer();
        
    }
}
