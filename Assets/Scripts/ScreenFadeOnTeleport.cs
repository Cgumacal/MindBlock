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
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Fade());
        }
    }
    public IEnumerator Fade()
    {
        Color texture = screenImage.color;
        float alphaFade = 0f;
        alphaFade += 1 * fadeSpeed * Time.deltaTime;
        alphaFade = Mathf.Clamp01(alphaFade);
        texture.a = alphaFade;
        screenImage.color = texture;
        StartCoroutine(FadeBack());
        yield return null;
    }
	
    private IEnumerator FadeBack()
    {
        Color texture = screenImage.color;
        float alphaFade = 1f;
        alphaFade -= 1 * fadeSpeed * Time.deltaTime;
        alphaFade = Mathf.Clamp01(alphaFade);
        texture.a = alphaFade;
        screenImage.color = texture;
        yield return null;
    }
}
