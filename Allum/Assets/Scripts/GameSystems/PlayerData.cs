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
   public bool wakingup;
   public bool dialogueDone;
   public string prevScene;
   public bool firstMission;
   public bool pastFrames;
   public bool timePieceOFF;
   public PlayerData (Player player)
   {
      Vector3 playerPos = player.transform.position;
      Vector3 scale = player.transform.localScale;
      isfacing = player.isFacingRight;
      firstMission = SaveManager.instance.FirstMissionComplete;
      timePieceOFF = FrameSwitchingSystem.instance.timepieceAppear;
      pastFrames = FrameSwitchingSystem.pastTime;
      dialogueDone = SwitchSceneLoader.instance.DialogueSceneDone;
      wakingup = SaveManager.instance.canWalk;
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
