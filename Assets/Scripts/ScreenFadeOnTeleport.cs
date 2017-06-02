using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeOnTeleport : MonoBehaviour {
    public Image screenImage;
    public float fadeSpeed = 0.05f;
    private bool fadeIn = false;
	// Use this for initialization
	void Start () {
        //always start transparent
        screenImage.color = new Color(1, 1, 1, 0);
	}
	
    void Update()
    {
        if (fadeIn)
        {
            StartCoroutine(Fade());
        }
    }
    private IEnumerator Fade()
    {
        Color texture = screenImage.color;
        float alphaFade = texture.a;
        alphaFade += fadeSpeed * Time.deltaTime;
        alphaFade = Mathf.Clamp01(alphaFade);
        texture.a = alphaFade;
        screenImage.color = texture;
        yield return new WaitForSeconds(0.25f);
        fadeIn = false;
        StartCoroutine(FadeBack());
    }
	
    private IEnumerator FadeBack()
    {
        Color texture = screenImage.color;
        float alphaFade = texture.a;
        alphaFade -= fadeSpeed * Time.deltaTime;
        alphaFade = Mathf.Clamp01(alphaFade);
        texture.a = alphaFade;
        screenImage.color = texture;
        yield return null;
    }

    public void StartFade()
    {
        fadeIn = true;
    }
}
