using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   public int SceneIndex;
   public float[] position;


   public PlayerData ()
   {
       position = new float[3];
    //    position[0]
    //    position[1]
    //    position[2]
   }
}
