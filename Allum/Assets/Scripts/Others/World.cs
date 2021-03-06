using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SwitchSceneLoader
{
    public Transform player;
    public float posX;
    public float posY;
    public string previous;
    public override void Start()
    {
        base.Start();
        if (prevScene == previous)
        {
            Debug.Log("PlayerPosSaved");
            Player.current.DialogueIsDone = DialogueSceneDone;
            player.position = new Vector2(posX, posY);
            player.localScale = player.transform.localScale;
        }
    }


}
