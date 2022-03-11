using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject SlotSelectPanel;
    [SerializeField] MenuButtonController menuButtonController;
    public static bool isStartPanel;
    public static bool isStartPressed;
    public static bool isReturn;

    private void Awake()
    {
        isStartPanel = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SoundManager.PlaySound("btnPress");
            this.gameObject.GetComponent<Animation>().Play("ReturnAnim");
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.PlaySound("btnPress");
        }
        
    }
    
    public void OnClickEscape()
    {
        isReturn = true;
        MainMenuEnabled();
    }
    public void returnMenuAnim()
    {
        SoundManager.PlaySound("menuBtn");
        this.gameObject.GetComponent<Animation>().Play("MenuTransition2");
        
    }
    public void SelectPanelEnabled()
    {
        MenuPanel.SetActive(false);
        SlotSelectPanel.SetActive(true);
        isStartPanel = false;
    }

    public void MainMenuEnabled()
    {
        menuButtonController.index = 0;
        MenuPanel.SetActive(true);
        SlotSelectPanel.SetActive(false);
        isReturn = false;
        isStartPanel = true;
    }

}
