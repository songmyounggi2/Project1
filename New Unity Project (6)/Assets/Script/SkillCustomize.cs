using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCustomize : MonoBehaviour
{
    public List<GameObject> skillList = new List<GameObject>();
    GameObject temp;
    Image skillIcon;
    Color fadecolor;
    RectTransform pos;
    //Vector2 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        skillList.Add(GameObject.Find("SkillInformation"));
        skillList.Add(GameObject.Find("SkillInformation (1)"));
        skillList.Add(GameObject.Find("SkillInformation (2)"));

        ;
        //firstPos = pos.anchoredPosition;
        
    }
    void UpdatePos()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            skillList[i].transform.position = new Vector3(960, 40 + (i*500), 0);
        }
    }
    void UpdateAcolor()
    {
        skillIcon = skillList[0].transform.Find("skillIcon").GetComponent<Image>();
        fadecolor.a = 0.3f;
        skillIcon.color = fadecolor;
        skillIcon = skillList[1].transform.Find("skillIcon").GetComponent<Image>();
        fadecolor.a = 1f;
        skillIcon.color = fadecolor;
        skillIcon = skillList[2].transform.Find("skillIcon").GetComponent<Image>();
        fadecolor.a = 0.3f;
        skillIcon.color = fadecolor;
    }
    // Update is called once per frame
    void Update()
    {
        UpdatePos();
        UpdateAcolor();

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("휠 다운");
            for (int i = 0; i < skillList.Count - 1; i++)
            {
                
                temp = skillList[i];
                skillList[i] = skillList[i+1];
                skillList[i + 1] = temp;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("휠 업");
            for (int i = skillList.Count - 1; i > 0; i--)
            {
                temp = skillList[i-1];
                skillList[i-1] = skillList[i];
                skillList[i] = temp;
            }
        }


    }
}
