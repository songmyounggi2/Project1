using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RectTransform pos;
    public GameObject skillTable;
    GameObject blackBox;
    Vector2 firstPos;
    float clickTime = 0f;
    bool questTab = false;
    public bool useSkill = false;

    // Start is called before the first frame update
    void Start()
    {
        skillTable = GameObject.Find("UI").transform.Find("SkillTable").gameObject;
        blackBox = GameObject.Find("UI").transform.Find("BlackBox").gameObject;
        //pos = GameObject.Find("UI").transform.Find("Quest").GetComponent<RectTransform>();
        useSkill = false;
       // firstPos = pos.anchoredPosition;

    }

    //IEnumerator CreateSkillTable()
    //{

    //    yield return new WaitForSeconds(10f);
    //    useSkill = true;
    //}

    void PlayerInput()
    {

        if (Input.GetMouseButton(0))
        {
            //Debug.Log(clickTime);
            clickTime = clickTime + Time.deltaTime * 10f;
           // Debug.Log(clickTime);
            if (clickTime > 10.0f)
            {
                Time.timeScale = 0.01F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                skillTable.gameObject.SetActive(true);
                blackBox.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickTime = 0.0f;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            skillTable.gameObject.SetActive(false);
            blackBox.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Tab))
        //{
        //    questTab = true;
        //    pos.anchoredPosition = Vector2.MoveTowards(pos.anchoredPosition, new Vector2(-702f,200f),Time.deltaTime*600f);
        //}
        PlayerInput();

        //if (Input.GetKeyUp(KeyCode.Tab))
        //{
        //    questTab = false;
        //}
        //if(questTab == false)
        //{
        //    pos.anchoredPosition = Vector2.MoveTowards(pos.anchoredPosition, new Vector2(-948f, 200f), Time.deltaTime * 800f);
        //}
    }
}
