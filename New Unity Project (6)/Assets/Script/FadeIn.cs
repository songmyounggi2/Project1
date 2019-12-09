﻿using System.Collections;
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

        OutStartFadeAnim();
    }

    public void InStartFadeAnim()
    {
        if (isPlaying == true) //중복재생방지
        {
            return;
        }
        StartCoroutine("fadeIntanim");
    }
    public void OutStartFadeAnim()
    {
        if (isPlaying == true) //중복재생방지
        {
            return;
        }
        start = 1f;
        end = 0f;
        StartCoroutine("fadeinplay");    //코루틴 실행
    }

    IEnumerator fadeinplay()
    {
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
        StartCoroutine("fadeoutplay");
        isPlaying = false;
    }
    IEnumerator fadeoutplay()
    {
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
        //GameObject.Find("TitleScreen").gameObject.SetActive(false);
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
