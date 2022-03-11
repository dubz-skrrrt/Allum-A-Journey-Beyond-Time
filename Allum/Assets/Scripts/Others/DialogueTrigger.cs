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
    public GameObject continueButton;
    [SerializeField] InteractionSystem interactionSystem;
    [SerializeField] Player player;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public static DialogueTrigger instance;
    public bool inDialogue;
    public bool isInteracting;
    public bool dialogueFinished, isConversing, isResponding, isRespondingDone, textDisplayDone, isGoing, isGoing2, mailStart, startVid, afterConsultation, combine, startVid2, LastQuest;
    public static bool walkedAway, walkedAway2, parentHide;
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
        if (NPCDIalogueChecker.NPCDialogueDone && Player.current.DialogueIsDone)
        {
            foreach (string NPCnames in SaveManager.instance.NPCs)
            {
                if (this.gameObject.name == NPCnames)
                {
                    index = dialogue.lines.Length-1;
                }
                else
                {
                    Player.current.DialogueIsDone = false;
                }
            }
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
            //Debug.Log(textDisplay.text);
            
            if (textDisplay.text == dialogue.lines[index].text && dialogue.lines[index].hasChoices)
            {
                if (isGoing)
                {
                    if (index >= dialogue.lines.Length -1)
                    {
                        Debug.Log("Going");
                        Vector3 thisScale = transform.localScale;
                        thisScale.x *= -1;
                        transform.localScale = thisScale;
                        
                    }
                }
                choice1Button.SetActive(true);
                choice2Button.SetActive(true);
                textDisplayDone = true;
                isConversing = false;
            }
            if (textDisplay.text == dialogue.lines[index].text && !dialogue.lines[index].hasChoices)
            {
                if (isGoing || isGoing2)
                {
                    if (index >= dialogue.lines.Length -1)
                    {
                        Debug.Log("Going");
                        Vector3 thisScale = transform.localScale;
                        thisScale.x *= -1;
                        transform.localScale = thisScale;
                        
                    }
                }
                continueButton.SetActive(true);
                if (continueButton.activeSelf)
                {
                    isRespondingDone = true;
                    isResponding = false;
                }
                isConversing = false;
            }
        }
        #region Walking
        if (isGoing && index >= dialogue.lines.Length -1)
        {Debug.Log("Stillwalking");
            this.GetComponent<Animator>().SetBool("isWalking", true);
            transform.position += new Vector3(-0.5f, 0, 0)* Time.deltaTime *3f;
        }
        if (isGoing && this.transform.position.x < -9.5f )
        {
            if (dialogueFinished)
            { 
                transform.position += new Vector3(-0.5f, 0, 0)* Time.deltaTime *3f;
                walkedAway = true; 
            }
            
            if (this.gameObject.activeSelf)
            {
                SaveManager.instance.SavePlayer();
            }
        }else
        {
            
        }
        if (isGoing && walkedAway)
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                SaveManager.instance.SavePlayer();
            }
        }
        #endregion
        #region Walking2
        if (isGoing2 && index >= dialogue.lines.Length -1)
        {Debug.Log("Stillwalking");
            this.GetComponent<Animator>().SetBool("isWalking", true);
            transform.position += new Vector3(-0.5f, 0, 0)* Time.deltaTime *3f;
        }
        if (isGoing2 && this.transform.position.x < -9.5f )
        {
            if (dialogueFinished)
            { 
                transform.position += new Vector3(-0.5f, 0, 0)* Time.deltaTime *3f;
                walkedAway2 = true; 
            }
            
            if (this.gameObject.activeSelf)
            {
                SaveManager.instance.SavePlayer();
            }
        }else
        {
            
        }
        if (isGoing2 && walkedAway2)
        {
            this.gameObject.SetActive(false);
            if (this.gameObject.activeSelf)
            {
                SaveManager.instance.SavePlayer();
            }
        }
        #endregion
        if (isResponding)
        {
            if (textDisplay.text == dialogue.lines[index].choices.response1.text)
            {
                continueButton.SetActive(true);
                if (continueButton.activeSelf)
                {
                    isRespondingDone = true;
                    isResponding = false;
                }
                
            }
            else if (textDisplay.text == dialogue.lines[index].choices.response2.text)
            {
                continueButton.SetActive(true);
                if (continueButton.activeSelf)
                {
                    isRespondingDone = true;
                    isResponding = false;
                }
                
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
                        player.DialogueIsDone = true;
                        index = dialogue.lines.Length-1;
                        if (mailStart)
                        {
                            SaveManager.instance.SavePlayer();
                        }
                        if (startVid)
                        {
                            ParentBehavior.showParent = false;
                            parentHide = false;
                            VideoPlay.playVid = true;
                        }
                        if (afterConsultation)
                        {
                            StartCoroutine(SceneFader.instance.FadeOutFXPersist());

                        }
                        if (combine)
                        {
                            WatchMiniGame.instance.combineWatch = true;
                            Player.current.movementDisabled = true;
                        }
                        if (startVid2)
                        {
                            KidBehavior.showKid = true;
                            VideoPlay.playVid = true;
                            SaveManager.instance.SavePlayer();
                        }

                        if (LastQuest)
                        {
                            Player.teleport = true;
                            SaveManager.instance.SavePlayer();
                        }
                    }
                }
                
            }
        }
        if (parentHide && afterConsultation)
        {
            this.gameObject.SetActive(false);
            KidBehavior.showKid = true;
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
        continueButton.SetActive(false);
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
            continueButton.SetActive(false);
            index++;
        }

    }
}
