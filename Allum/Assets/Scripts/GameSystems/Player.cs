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
    public bool DialogueIsDone;
    public static Animator animator;
    public static bool teleport;
    public bool IC, OC, IW, OW;
    bool startAnim;
    private void Awake()
    {
        animator = GetComponent<Animator>();
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
                if (animator.GetBool("isWalking") && IC)
                {
                    SoundManager.PlaySound("inside");
                }
                else if (animator.GetBool("isWalking") && OC)
                {
                    SoundManager.PlaySound("concrete");
                }
                else if (animator.GetBool("isWalking") && IW)
                {
                    SoundManager.PlaySound("wood");
                }
                else if (animator.GetBool("isWalking") && OW)
                {
                    SoundManager.PlaySound("inWood");
                }
                if (Input.GetKeyDown(KeyCode.D) && !isFacingRight)
                {
                    Flip();
                }
                else if(Input.GetKeyDown(KeyCode.A) && isFacingRight)
                {
                    Flip();
                }
            }
            else
                animator.SetBool("isWalking", false);
                // IC = false;
                // OC = false;
                // IW = false;
                // OW = false;
        }

        if (SaveManager.instance.sceneSwitchSave)
        {
            SaveManager.instance.SceneSwitchData();
        }
        
        if (ItemDialogueTrigger.onCollide)
        {
            animator.SetBool("isWalking", false);
        }
        if (movementDisabled)
        {
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case ("InsideConcrete"):
                IC = true;
                break;
            case ("OutsideConcrete"):
                OC = true;
                break;
            case ("InsideWood"):
                IW = true;
                break;
            case ("OutsideWood"):
                OW = true;
                break;
        }
    }
}
