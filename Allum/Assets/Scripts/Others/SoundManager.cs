using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bgm, btnClick, choiceBtn, btnPressed, walkConcrete, walkInside, walkWood, walkInsideWood;
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
        walkConcrete = Resources.Load<AudioClip>("FootstepsConcrete3");
        walkInside = Resources.Load<AudioClip>("FootstepsTest");
        walkWood = Resources.Load<AudioClip>("FootstepsWood3");
        walkInsideWood = Resources.Load<AudioClip>("FootstepsWood1");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.5f;
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
                case "concrete":
                    audioSrc.PlayOneShot(walkConcrete);
                    break;
                case "inside":
                    audioSrc.PlayOneShot(walkInside);
                    break;
                case "wood":
                    audioSrc.PlayOneShot(walkWood);
                    break;
                case "inWood":
                    audioSrc.PlayOneShot(walkInsideWood);
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
