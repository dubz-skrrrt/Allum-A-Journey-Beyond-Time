using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemDialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI nameOfSpeaker;
    public TextMeshProUGUI textDisplay;
    public ScriptableDialogue dialogue;
    public GameObject dialogueBox;
    public GameObject continueButton;
    [SerializeField] InteractionSystem interactionSystem;
    [SerializeField] Player player;
    public bool isInteracting,  isConversing, isRespondingDone, inDialogue, timetravelPiece, discriminationScene, newsPaper, KeyFind, fader, ending;
    public int index;
    public float typingSpeed;
    public static bool dialogueFinished, onCollide, fadedFX;
    public static ItemDialogueTrigger instance;
    private void Awake()
    {
        instance = this;
        interactionSystem = FindObjectOfType<InteractionSystem>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (onCollide)
        {
            isInteracting = true;
            onCollide = false;
        }
        if (isInteracting && SaveManager.instance.canWalk)
        {
            player.movementDisabled = true;
            dialogueBox.GetComponent<Animator>().SetBool("inDialogue", true);
            SoundManager.PlaySound("menuBtn");
            inDialogue = true;
            StartCoroutine(Type());
            isInteracting = false;
            isConversing = true;
        }

        if (isConversing)
        {
            if (textDisplay.text == dialogue.lines[index].text && !dialogue.lines[index].hasChoices)
            {
                continueButton.SetActive(true);
                if (timetravelPiece)
                {
                    if (index == 2)
                    {
                        SoundManager.PlaySound("quake");
                        CameraShake.instance.ShakeCamera(3f, 2f);
                        FrameSwitchingSystem.pastTime = true;
                        if (continueButton.activeSelf)
                        {
                            isRespondingDone = true;
                            isConversing = false;
                        }
                        
                    }
                     if (continueButton.activeSelf)
                        {
                            
                            isRespondingDone = true;
                            isConversing = false;
                        }
                }
                if (newsPaper)
                {
                    if (index == 3)
                    {
                        
                        TogglePopUpImage.show = true;
                    }
                    if (continueButton.activeSelf)
                    {
                        isRespondingDone = true;
                        isConversing = false;
                    }
                    if (index == 8)
                    {
                        TogglePopUpImage.show = false;
                    }
                }
                if (KeyFind)
                {
                    if (index == 0)
                    {
                        TogglePopUpImage.show = true;
                    }
                    if (index == 2)
                    {
                        TogglePopUpImage.show = false;
                    }
                    if (continueButton.activeSelf)
                    {
                        isRespondingDone = true;
                        isConversing = false;
                    }
                }
                if (continueButton.activeSelf)
                {
                    
                    isRespondingDone = true;
                    isConversing = false;
                }
            }
        }

         if (isRespondingDone)
        {
            if (Input.GetAxis("Submit") == 1)
            {
                SoundManager.PlaySound("btnPress");
                NextDialogue();
                isRespondingDone = false;
                 if (index >= dialogue.lines.Length)
                {
                    dialogueFinished = true;
                }
            }
        }
        if (inDialogue)
        {
            if (index >= dialogue.lines.Length && dialogueFinished)
            {
                if (Input.GetAxis("Submit") == 1)
                {
                    SoundManager.PlaySound("btnPress");
                    if (dialogueFinished)
                    {
                        index = 0;
                        inDialogue = false;
                        player.movementDisabled = false;
                        interactionSystem.interacting = false;
                        interactionSystem.isCreated = false;
                        dialogueFinished = true;
                        dialogueBox.GetComponent<Animator>().SetBool("inDialogue", false);
                        if (timetravelPiece)
                        {
                            TimePiece.timePieceDialogue = true;
                        }
                        if (discriminationScene)
                        {
                            StartCoroutine(SceneFader.instance.FadeOutFXPersist());
                        }
                        if (newsPaper)
                        {
                            this.gameObject.SetActive(false);
                        }
                        if (KeyFind)
                        {
                            SaveManager.instance.keyFound = true;
                        }
                        if (fader)
                        {
                            StartCoroutine(SceneFader.instance.FadeOutFX());
                        }
                        if (ending)
                        {
                            Debug.Log("Ending");
                            StartCoroutine(SceneFader.instance.FadeOutFXEnd());
                        }
                    }
                }
            }
        }
        if (SceneFader.faded && discriminationScene)
        {
            this.gameObject.SetActive(false);
        }
        if (fadedFX && fader)
        {
            Player.current.movementDisabled = false;
        }
    }

    IEnumerator DialogueDelay()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator Type()
    {
        nameOfSpeaker.text = dialogue.lines[index].characterName;   
        foreach (var letter in dialogue.lines[index].text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);  
            
        }
    
    }

    public void NextDialogue()
    {
        continueButton.SetActive(false);
        if (index < dialogue.lines.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            isConversing = true;
        }else
        {
            continueButton.SetActive(false);
            textDisplay.text = "";
            index++;
        }

    }
}
