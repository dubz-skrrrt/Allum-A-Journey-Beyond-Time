using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI nameOfSpeaker;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;
    public ScriptableDialogue dialogue;
    public GameObject dialogueBox;
    public GameObject choice1Button;
    public GameObject choice2Button;
    [SerializeField] InteractionSystem interactionSystem;
    [SerializeField] Player player;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public static DialogueTrigger instance;
    public bool inDialogue;
    public bool isInteracting;
    public bool dialogueFinished, isConversing, isResponding, isRespondingDone, textDisplayDone;
    public int choiceIndex;
    public int index;
    public float typingSpeed;
    private void Awake()
    {
        instance = this;
        interactionSystem = FindObjectOfType<InteractionSystem>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        // if (interactionSystem.interacting)
        // {
        //     isInteracting = true;
            
        // }
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
            //Debug.Log(textDisplay.text);
            
            if (textDisplay.text == dialogue.lines[index].text && dialogue.lines[index].hasChoices)
            {
                choice1Button.SetActive(true);
                choice2Button.SetActive(true);
                textDisplayDone = true;
                isConversing = false;
            }
            if (textDisplay.text == dialogue.lines[index].text && !dialogue.lines[index].hasChoices)
            {
                isRespondingDone = true;
                isConversing = false;
            }
            
        }
        if (isResponding)
        {
            if (textDisplay.text == dialogue.lines[index].choices.response1.text)
            {
                Debug.Log(dialogue.lines[index].choices.response1.text);
                isRespondingDone = true;
                isResponding = false;
                
            }
            else if (textDisplay.text == dialogue.lines[index].choices.response2.text)
            {
                Debug.Log(dialogue.lines[index].choices.response2.text);
                isRespondingDone = true;
                isResponding = false;
            }
            
        }
        if (isRespondingDone)
        {
            if (Input.GetAxis("Submit") == 1)
            {
                choiceIndex = 0;
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
                    //dialogueFinished = false;
                    Debug.Log("done");
                    if (dialogueFinished)
                    {
                        inDialogue = false;
                        player.movementDisabled = false;
                        interactionSystem.interacting = false;
                        interactionSystem.isCreated = false;
                        dialogueBox.GetComponent<Animator>().SetBool("inDialogue", false);
                        index = dialogue.lines.Length-1;
                    }
                }
                
            }
            
        }

        if (textDisplayDone)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
               if (!keyDown)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (choiceIndex < maxIndex)
                            choiceIndex++;
                        else
                            choiceIndex = 0;
                    }
                    else if (Input.GetAxis("Horizontal") < 0)
                    {
                        if (choiceIndex > 0)
                            choiceIndex--;
                        else   
                            choiceIndex = maxIndex;
                    }
                    keyDown = true;
                }
            }
            else
                keyDown = false;
        
        }
        
    }
    IEnumerator Type()
    {
        nameOfSpeaker.text = dialogue.lines[index].characterName;
        if (dialogue.lines[index].hasChoices)
        {
            choice1Text.text = dialogue.lines[index].choices.choice1;
            choice2Text.text = dialogue.lines[index].choices.choice2;
        }
        
        foreach (var letter in dialogue.lines[index].text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);  
            
        }
    }
    IEnumerator Response1Type()
    {
        textDisplay.text = "";
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        foreach (var letter in dialogue.lines[index].choices.response1.text.ToString().ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);  
        }
        
    }
    IEnumerator Response2Type()
    {
        textDisplay.text = "";
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        foreach (var letter in dialogue.lines[index].choices.response2.text.ToString().ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);  
        }
    }

    public void choiceResponse()
    {
        if (choiceIndex == 0)
        {
            StartCoroutine(Response1Type());
            isResponding = true;
        }
        else if (choiceIndex == 1)
        {
            StartCoroutine(Response2Type());
            isResponding = true;
        }
    }
    public void NextDialogue()
    {
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);
        
        if (index < dialogue.lines.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            isConversing = true;
        }else
        {
            textDisplay.text = "";
            choice1Button.SetActive(false);
            choice2Button.SetActive(false);
            index++;
        }

    }
}
