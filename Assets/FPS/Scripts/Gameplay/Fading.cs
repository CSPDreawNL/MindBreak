using System.Collections;
using UnityEngine;


public class Fading : MonoBehaviour
{
    static Fading instance = null;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeOutImmediatly()
    {
        canvasGroup.alpha = 1;
    }

    public IEnumerator FadeOut(float time)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float time)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
}

