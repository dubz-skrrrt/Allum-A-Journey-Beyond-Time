using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   public int SceneIndex;
   public string SceneName;
   public float[] position;


   public PlayerData (Player player)
   {
      Vector3 playerPos = player.transform.position;
      SceneIndex = SaveManager.instance.sceneNum;
      SceneName = SaveManager.instance.sceneName;
      position = new float[]
      {
         playerPos.x, playerPos.y, playerPos.z
      };
   }
}
