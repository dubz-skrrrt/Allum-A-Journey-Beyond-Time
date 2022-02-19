using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   public int SceneIndex;
   public float[] position;


   public PlayerData (Player player)
   {
      Vector3 playerPos = player.transform.position;
      position = new float[]
      {
         playerPos.x, playerPos.y, playerPos.z
      };
   }
}
