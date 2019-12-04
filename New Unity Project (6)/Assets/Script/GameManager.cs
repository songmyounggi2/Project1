using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RectTransform pos;
    GameObject skillTable;
    Vector2 firstPos;
    float clickTime = 0f;
    bool questTab = false;
    // Start is called before the first frame update
    void Start()
    {
        skillTable = GameObject.Find("UI").transform.Find("SkillTable").gameObject;
        pos = GameObject.Find("Quest").GetComponent<RectTransform>();
        firstPos = pos.anchoredPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            questTab = true;
            Debug.Log("tab");
            pos.anchoredPosition = Vector2.MoveTowards(pos.anchoredPosition, new Vector2(-702f,200f),Time.deltaTime*600f);
        }
        if (Input.GetMouseButtonDown(0))
        {

            clickTime = clickTime + Time.deltaTime * 10f;
            Debug.Log(clickTime);
            if (clickTime > 3.8f)
            {
                Time.timeScale = 0.01F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                skillTable.gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            questTab = false;
        }
        if(questTab == false)
        {
            pos.anchoredPosition = Vector2.MoveTowards(pos.anchoredPosition, new Vector2(-948f, 200f), Time.deltaTime * 800f);
        }
    }
}
