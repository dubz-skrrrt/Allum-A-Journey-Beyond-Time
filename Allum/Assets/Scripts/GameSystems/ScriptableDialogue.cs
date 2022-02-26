using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public string characterName;
    [TextArea(2, 5)]
    public string text;
    public bool hasChoices;
    public Choices choices;
}

[System.Serializable]
public struct response
{
    [TextArea(1,3)]
    public string text;
}


[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class ScriptableDialogue : ScriptableObject
{
    public string characterName;
    public Line[] lines;
}
