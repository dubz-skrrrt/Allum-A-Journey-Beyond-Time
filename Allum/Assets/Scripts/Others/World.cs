using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SwitchSceneLoader
{
    public Transform player;
    public float posX;
    public float posY;
    public string previous;
    
    public void Start()
    {
        base.Start();
        Debug.Log("PlayerPosSaved " + prevScene);
        if (prevScene == previous)
        {
            Debug.Log("PlayerPosSaved");
            player.position = new Vector2(posX, posY);
            player.localScale = player.transform.localScale;
        }
    }


}
