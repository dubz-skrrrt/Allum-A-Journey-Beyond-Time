using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;
    public Image image;
    public AnimationCurve fadeCurve;
    public static bool unmovable;
    public static bool faded;
    void Awake()
    {
        instance = this;
        unmovable = true;
    }
    void Start()
    {
        StartCoroutine(FadeIn());
        
    }

    public void FadeToScene(string Scene)
    {
        unmovable = true;
        StartCoroutine(FadeOut(Scene));
        
    }

    // public void FadeEffect()
    // {
    //     StartCoroutine(FadeOutFX);
    // }
    public IEnumerator FadeIn ()
    {
        float t = 1f;
        
         while (t > 0f)
         {
             t -= Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
         }
         unmovable = false;
    }

    IEnumerator FadeOut (string _Scene)
    {
        float t = 0f;
        
         while (t < 1f)
         {
             t += Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
         }

         Loader.load(_Scene);
    }
    
    public IEnumerator FadeOutFX ()
    {
        float t = 0f;
         while (t < 1f)
         {
             t += Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
             StartCoroutine(FadeInFX());
             faded = true;
         }
    }
    public IEnumerator FadeInFX ()
    {
        float t = 1f;
        
         while (t > 0f)
         {
             t -= Time.deltaTime * 0.5f;
             float a = fadeCurve.Evaluate(t);
             image.color = new Color (0f, 0f ,0f, a);
             yield return 0;
             
         }
         
    }
}
