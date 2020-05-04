using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillCustomize : MonoBehaviour
{
    public List<GameObject> skillList = new List<GameObject>();
    public List<Image> skillIconList = new List<Image>();
    GameObject temp;

    public Canvas mycanvas;


    GraphicRaycaster gr;
    PointerEventData ped;


    Color fadecolor;
    Color clickIconColor;
    Vector3 defaultPos;
    RectTransform pos;

    bool isDrag = false;
    //Vector2 firstPos;

    // Start is called before the first frame update
    void Start()
    {
        gr = mycanvas.GetComponent<GraphicRaycaster>();
        ped = new PointerEventData(null);

        skillList.Add(GameObject.Find("SkillInformation"));
        skillList.Add(GameObject.Find("SkillInformation (1)"));
        skillList.Add(GameObject.Find("SkillInformation (2)"));

        isDrag = false;
        //firstPos = pos.anchoredPosition;

    }
    void UpdatePos()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            skillList[i].transform.position = new Vector3(960, 40 + (i * 500), 0);
        }
    }
    void UpdateAcolor()
    {
        fadecolor.a = 0.3f;
        skillList[0].transform.Find("skillIcon").GetComponent<Image>().color = fadecolor;
        fadecolor.a = 1f;
        skillList[1].transform.Find("skillIcon").GetComponent<Image>().color = fadecolor;
        fadecolor.a = 0.3f;
        skillList[2].transform.Find("skillIcon").GetComponent<Image>().color = fadecolor;

    }
    //public void ClickIcon()
    //{

    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        Debug.Log(hit.transform.gameObject.name);
    //    }


    //    defaultPos = skillList[1].transform.position;

    //    isDrag = true;
    //}
    public void DragIcon()
    {
        if (!isDrag)
            return;
        Vector3 currentPos = Input.mousePosition;
        temp.transform.position = currentPos;
        temp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        clickIconColor = Color.white;
        temp.GetComponent<Image>().color = clickIconColor;

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
                    skillList[i] = skillList[i + 1];
                    skillList[i + 1] = temp;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Debug.Log("휠 업");
                for (int i = skillList.Count - 1; i > 0; i--)
                {
                    temp = skillList[i - 1];
                    skillList[i - 1] = skillList[i];
                    skillList[i] = temp;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                ped.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>(); // 여기에 히트 된 개체 저장
                gr.Raycast(ped, results);
                if (results.Count != 0)
                {
                    GameObject obj = results[0].gameObject;

                    if (obj.transform.position == new Vector3(290.0f, 495.0f, 0.0f)) // 히트 된 오브젝트의 태그와 맞으면 실행
                    {
                        defaultPos = obj.transform.position;
                        temp = obj;
                        isDrag = true;
                    }
                }
            }
            DragIcon();
            if (Input.GetMouseButtonUp(0))
            {
                temp.transform.localScale = new Vector3(1f, 1f, 1f);
                isDrag = false;
                temp.transform.position = defaultPos;
            }

        }
}

