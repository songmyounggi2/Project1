using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float FadeTime = 2f;

    Image fadeImg;

    float start;

    float end;

    float time = 0f;

    bool isPlaying = false;

    private void Awake()
    {
        fadeImg = GetComponent<Image>();
        StartFadeAnim();
        
    }

    public void StartFadeAnim()
    {
        if (isPlaying == true) //중복재생방지
        {
            return;
        }
        start = 1f;
        end = 0f;
        if (this.gameObject.tag == "Fadein"|| this.gameObject.tag == "Fadeinout")
            StartCoroutine("fadeinplay");
        else if (this.gameObject.tag == "Fadeout")
            StartCoroutine("fadeoutplay");
    }

    IEnumerator fadeinplay()
    {
        //Debug.Log(fadeImg.color);

        isPlaying = true;
        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(start, end, time);

        while (fadecolor.a > 0f)
        {
            time += Time.deltaTime / FadeTime;

            fadecolor.a = Mathf.Lerp(start, end, time);

            fadeImg.color = fadecolor;

            yield return null;

        }

        if (this.gameObject.tag == "Fadeinout")
        {
            StartCoroutine("fadeoutplay");
        }
        else 
            gameObject.SetActive(false);
        isPlaying = false;
    }
    IEnumerator fadeoutplay()
    {
        isPlaying = true;
        Color fadecolor = fadeImg.color;
        time = 0f;
        fadecolor.a = Mathf.Lerp(end, start, time);

        while (fadecolor.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            fadecolor.a = Mathf.Lerp(end, start, time);
            fadeImg.color = fadecolor;
            yield return null;
        }
        isPlaying = false;
        //gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
