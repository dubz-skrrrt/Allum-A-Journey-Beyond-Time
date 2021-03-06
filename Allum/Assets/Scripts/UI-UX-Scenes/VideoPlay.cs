using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoPlay : MonoBehaviour
{
    public GameObject videoPanel;
    public VideoPlayer videoPlayer;
    public string sceneName;
    public static bool playVid;
    // Update is called once per frame
    void Update()
    {
        if (playVid)
        {
            videoPanel.SetActive(true);
            if (videoPlayer.frame > 0 && !videoPlayer.isPlaying)
            {
                Debug.Log("Finished");
                playVid = false;
                SwitchSceneLoader.instance.SwitchScene(sceneName);
            }
        }
        else
        {
            videoPanel.SetActive(false);
        }
    }
}
