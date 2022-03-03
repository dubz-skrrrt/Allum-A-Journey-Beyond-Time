using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    public int thisIndex;
    void Update()
    {
        if (PauseMenu.GameisPaused)
        {
            if (pauseMenu.index == thisIndex)
            {
                this.GetComponent<Animator>().SetBool("selected", true);
                if (Input.GetAxisRaw("Submit") == 1)
                {
                    this.GetComponent<Animator>().SetBool("pressed", true);
                }
                else if (this.GetComponent<Animator>().GetBool("pressed"))
                {
                    this.GetComponent<Animator>().SetBool("pressed", false);
                }
            }
            else
            {
                this.GetComponent<Animator>().SetBool("selected", false);
            }
        }
    }

    public void PauseButtonChoice()
    {
        if (pauseMenu.index == 0)
        {
            pauseMenu.Resume();
        }
        else if (pauseMenu.index == 1)
        {
            Debug.Log("clicked save");
            pauseMenu.Resume();
            pauseMenu.SaveGame();
        }
        else if(pauseMenu.index == 2)
        {
            pauseMenu.LoadMenu();
            SaveManager.instance.inMenu = true;
        }
    }
}
