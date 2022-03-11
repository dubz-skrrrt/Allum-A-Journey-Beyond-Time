using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Player : MonoBehaviour
{
    public static Player current;
    public float MovementSpeed = 1;
    public bool isFacingRight = true;
    public bool movementDisabled = false;
    public bool isMoving;
    public bool DialogueIsDone;
    public static Animator animator;
    public AudioSource audioSrc;
    public static bool teleport;
    bool startAnim;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
        current = this;
    }
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath +  "/SaveFile_" + SaveSlotData.SlotName + ".dat") && !SaveManager.instance.sceneSwitchSave)
        {
            Debug.Log("SaveFirst");
            SaveManager.instance.LoadPlayerMissionData();
            SaveManager.instance.SceneSwitchData();
        }
        if (!teleport && PastFuture.change)
        {
            this.transform.position = new Vector3(33.05f, -2.87f, 0);
            Flip();
        }
    }
    private void Update()
    {
        if (!movementDisabled && SaveManager.instance.canWalk)
        {
            animator.SetBool("Start", true);
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            {
                animator.SetBool("isWalking", true);
                isMoving = true;
                audioSrc.volume = Random.Range(0.75f, 1);
                audioSrc.pitch = Random.Range(0.8f, 1.1f);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    
                    audioSrc.Play();
                    if (!isFacingRight)
                    { 
                        Flip();
                    }
                    
                }
                else if(Input.GetKeyDown(KeyCode.A))
                {
                    
                    audioSrc.Play();
                    if (isFacingRight)
                    {
                        Flip();
                    }
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                isMoving = false;
                audioSrc.Stop();
            }
        }

        if (SaveManager.instance.sceneSwitchSave)
        {
            SaveManager.instance.SceneSwitchData();
        }
        
        if (ItemDialogueTrigger.onCollide)
        {
            audioSrc.Stop();
            animator.SetBool("isWalking", false);
        }
        if (movementDisabled)
        {
            audioSrc.Stop();
            animator.SetBool("isWalking", false);
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void onStart()
    {
        if (!startAnim)
        { 
            Debug.Log("done");
            SaveManager.instance.start = true;
            startAnim = true;
        }
        
    }
}
