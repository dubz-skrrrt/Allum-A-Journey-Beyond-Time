using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   public int SceneIndex;
   public string SceneName;
   public float[] position;
   public float[] facingRight;
   public bool isfacing;

   public PlayerData (Player player)
   {
      Vector3 playerPos = player.transform.position;
      Vector3 scale = player.transform.localScale;
      isfacing = player.isFacingRight;
      SceneIndex = SaveManager.instance.sceneNum;
      SceneName = SaveManager.instance.sceneName;
      position = new float[]
      {
         playerPos.x, playerPos.y, playerPos.z
      };

      facingRight = new float[]
      {
         scale.x, scale.y, scale.z
      };
   }
}
