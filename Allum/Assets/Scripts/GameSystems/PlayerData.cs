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
   public bool secondMisson;
   public bool pastFrames;
   public bool timePieceOn;
   public bool fade;
   public bool walkingAway;
   public bool parentShow, kidShow;
   public bool changeTime;
   public List<string> NPCNames = new List<string>();
   public PlayerData (Player player)
   {
      Vector3 playerPos = player.transform.position;
      Vector3 scale = player.transform.localScale;
      isfacing = player.isFacingRight;
      parentShow = ParentBehavior.showParent;
      kidShow = KidBehavior.showKid;
      changeTime = PastFuture.change;
      firstMission = SaveManager.instance.FirstMissionComplete;
      secondMisson = SaveManager.instance.SecondMissionStart;
      walkingAway = DialogueTrigger.walkedAway;
      timePieceOn = TimePiece.timepieceAppear;
      pastFrames = FrameSwitchingSystem.pastTime;
      dialogueDone = NPCDIalogueChecker.NPCDialogueDone;
      wakingup = SaveManager.instance.canWalk;
      SceneIndex = SaveManager.instance.sceneNum;
      fade = SceneFader.faded;
      SceneName = SaveManager.instance.sceneName;
      position = new float[]
      {
         playerPos.x, playerPos.y, playerPos.z
      };

      facingRight = new float[]
      {
         scale.x, scale.y, scale.z
      };
      foreach(string npc in SaveManager.instance.NPCs)
      {
         NPCNames.Add(npc);
      }
      
   }
}
