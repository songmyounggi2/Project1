﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseUp : MonoBehaviour
{
    Text skillName;
    GameObject skillIcon;
    Vector3 IconSclse;
    FSMPlayer fsmPlayerManager;
    bool isHover = false;

    // Start is called before the first frame update
    void Start()
    {
        IconSclse = new Vector3(1.0f, 1.0f, 1.0f);
        fsmPlayerManager = GameObject.Find("Character").transform.GetComponent<FSMPlayer>();
    }

    public void MouseHover()
    {
        isHover = true;
        skillIcon = transform.Find("Icon").gameObject ;
        transform.Find("Text").GetComponent<Text>().fontStyle = FontStyle.Bold;

        fsmPlayerManager.useSkill = true;
        fsmPlayerManager.skillName = this.transform.parent.name;
        Debug.Log(this.transform.parent.name);
        IconSclse = new Vector3(1.5f, 1.5f, 1f);


    }
    public void MouseUnHover()
    {
       
        skillIcon = transform.Find("Icon").gameObject;
        transform.Find("Text").GetComponent<Text>().fontStyle = FontStyle.Normal;
        Debug.Log(skillIcon);
        Debug.Log(skillName);
        IconSclse = new Vector3(1.0f, 1.0f, 1.0f);
        fsmPlayerManager.useSkill = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isHover == true)
        {
            skillIcon.transform.localScale = IconSclse;
 
        }
    }
}
