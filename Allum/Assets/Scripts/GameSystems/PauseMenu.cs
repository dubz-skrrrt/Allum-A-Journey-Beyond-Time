using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject PauseMenuUI;
    public int index;
    [SerializeField] int maxIndex;
    [SerializeField] bool keyDown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
    
            }
        }
        if (GameisPaused)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
                {
                    if (!keyDown)
                    {
                        if (Input.GetAxisRaw("Vertical") < 0)
                        {
                            if (index < maxIndex)
                                index++;
                            else
                                index = 0;
                        }
                        else if (Input.GetAxisRaw("Vertical") > 0)
                        {
                            if (index > 0)
                                index--;
                            else   
                                index = maxIndex;
                        }
                        keyDown = true;
                    }
                }
                else
                    keyDown = false;
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameisPaused = false;
        Loader.load("MainMenu");
    }

    public void SaveGame()
    {
        SaveManager.instance.SavePlayer();
    }
}
