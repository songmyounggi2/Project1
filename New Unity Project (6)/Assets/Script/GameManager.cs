using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    RectTransform pos;
    public GameObject skillTable;
    GameObject blackBox;
    Vector2 firstPos;
    float clickTime = 0f;
    bool questTab = false;
    public bool useSkill = false;
   // public Text playerName;

    //public Player playerData = null;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        //skillTable = GameObject.Find("UI").transform.Find("SkillTable").gameObject;
        // blackBox = GameObject.Find("UI").transform.Find("BlackBox").gameObject;
        //pos = GameObject.Find("UI").transform.Find("Quest").GetComponent<RectTransform>();
        //useSkill = false;

        // firstPos = pos.anchoredPosition;
        
    }
    //void DataLaod()
    //{
    //    if (SceneManager.GetActiveScene().name != "SampleScene")
    //        return;
        
    //    playerName.text = playerData.name;
    //}
    //IEnumerator CreateSkillTable()
    //{

    //    yield return new WaitForSeconds(10f);
    //    useSkill = true;
    //}

   
    // Update is called once per frame
    void Update()
    {

        
        //if (Input.GetKey(KeyCode.Tab))
        //{
        //    questTab = true;
        //    pos.anchoredPosition = Vector2.MoveTowards(pos.anchoredPosition, new Vector2(-702f,200f),Time.deltaTime*600f);
        //}
        //PlayerInput();

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
