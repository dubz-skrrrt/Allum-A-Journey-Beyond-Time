using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bgm, btnClick, choiceBtn, btnPressed, doorOpen, doorClose, earthquakeSFX;
    public static AudioSource audioSrc;

    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }
    void Start()
    {
       
        bgm = Resources.Load<AudioClip>("BGM");
        btnClick = Resources.Load<AudioClip>("ButtonNavigate");
        choiceBtn = Resources.Load<AudioClip>("ButtonNavigate1");
        btnPressed = Resources.Load<AudioClip>("ButtonSound");
        doorClose = Resources.Load<AudioClip>("DoorClose");
        doorOpen = Resources.Load<AudioClip>("DoorOpen");
        earthquakeSFX = Resources.Load<AudioClip>("Earthquake");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {

        if (audioSrc == null){
            return;
        }else{
            switch (clip)
            {
                case "BGM":
                    audioSrc.PlayOneShot(bgm);
                    break;
                case "menuBtn":
                    audioSrc.PlayOneShot(btnClick);
                    break;
                case "gameBtn":
                    audioSrc.PlayOneShot(choiceBtn);
                    break;
                case "btnPress":
                    audioSrc.PlayOneShot(btnPressed);
                    break;
                case "Open":
                    audioSrc.PlayOneShot(doorOpen);
                    break;
                case "Close":
                    audioSrc.PlayOneShot(doorClose);
                    break;
                case "quake":
                    audioSrc.PlayOneShot(earthquakeSFX);
                    break;
                // case "new_card":
                //     audioSrc.PlayOneShot(drawCard);
                //     break;
                // case "owl":
                //     audioSrc.PlayOneShot(owl);
                //     break;
                // case "parrot":
                //     audioSrc.PlayOneShot(parrot);
                //     break;
                // case "penguin":
                //     audioSrc.PlayOneShot(penguin);
                //     break;
                // case "pigeon":
                //     audioSrc.PlayOneShot(pigeon);
                //     break;
            }
        }
        
    }
}
