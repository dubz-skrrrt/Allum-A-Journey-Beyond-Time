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
    public bool isInteracting,  isConversing, isRespondingDone, inDialogue, timetravelPiece, discriminationScene;
    public int index;
    public float typingSpeed;
    public static bool dialogueFinished, onCollide;
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
        if (isInteracting)
        {
            player.movementDisabled = true;
            dialogueBox.GetComponent<Animator>().SetBool("inDialogue", true);
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
                
            }
        }

         if (isRespondingDone)
        {
            if (Input.GetAxis("Submit") == 1)
            {
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
                    if (dialogueFinished)
                    {
                        index = 0;
                        inDialogue = false;
                        player.movementDisabled = false;
                        interactionSystem.interacting = false;
                        interactionSystem.isCreated = false;
                        dialogueFinished = true;
                        dialogueBox.GetComponent<Animator>().SetBool("inDialogue", false);
                        TogglePopUpImage.show = false;
                        if (discriminationScene)
                        {
                            StartCoroutine(SceneFader.instance.FadeOutFX());
                                          
                        }


                    }
                }
            }
        }
        if (SceneFader.faded)
        {
            this.gameObject.SetActive(false);
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
