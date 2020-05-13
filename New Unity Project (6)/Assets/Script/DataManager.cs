using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
using UnityEngine.UI;

public class Player
{
    public string name;
    public int hp;
    public int power;
    public int moveSpeed;
    public int id;
    public bool completeTutorial;
    //public int completeTutorial;

    public Player(string name, int hp, int power, int movespeed , int id, bool completeTutorial)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        this.moveSpeed = movespeed;
        this.id = id;
        this.completeTutorial = completeTutorial;

    }
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    JsonData userData;                                              // 제이슨 파일에 저장된 유저의 데이터를 불러오는 용도
    JsonData tempData;                                              // 유저의 데이터를 임시 저장하는 용도
    public List<Player> playerList = new List<Player>();            // 불러온 데이터를 리스트화
    public List<Text> slotText = new List<Text>();                  // 슬롯에 저장된 데이터를 관리하기위한 리스트
    public Text []playerDataText = new Text[3];                     // 슬롯에 저장된 데이터를 시각화해주는 메세지
    public Text choseDataText;                                      // 유저가 선택한 슬롯의 정보를 보여주는 메세지
    public int slotNum;                                             // 유저가 선택한 슬롯의 번호
    int selectSlot = 0;

    public Player playerData;
    public MonsterMapSet monsterMapSet;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    IEnumerator LoaCo()
    {
        
        string UserString = File.ReadAllText(Application.dataPath + "/Resource/Player.json");
        //JsonData UserData = JsonMapper.ToObject(UserString);
        userData = JsonMapper.ToObject(UserString);

        ParsingJsonData(userData, userData.Count);
        
        yield return null;
    }
    //Start is called before the first frame update
    void ParsingJsonData(JsonData UserData, int DataNum)
    {
        for (int i = 0; i < DataNum; i++)
        {
            string TempName = UserData[i]["name"].ToString();
            string TempHP = UserData[i]["hp"].ToString();
            string TempPower = UserData[i]["power"].ToString();
            string TempMoveSpeed = UserData[i]["moveSpeed"].ToString();
            string TempID = UserData[i]["id"].ToString();
            string TempCompleteTutorial = UserData[i]["completeTutorial"].ToString();
            playerList.Add(new Player(TempName, int.Parse(TempHP), int.Parse(TempPower), int.Parse(TempMoveSpeed), int.Parse(TempID), bool.Parse(TempCompleteTutorial)));
            playerDataText[i].text = "Name : " + playerList[i].name + "\n" + "Code : " + playerList[i].id;
            slotText.Add(playerDataText[i]);
            Debug.Log(slotText.Count);

        }
    }
    public void CreateCharacter()
    {
        if(playerList.Count > 2)
        {
            GameObject.Find("WarningMessege").transform.Find("TooMuchData").gameObject.SetActive(true);
            return;
        }
        Debug.Log("성공");

        playerData = new Player(null, 50, 3, 1, 0, false);
       // playerData.completeTutorial = false;

        SceneManager.LoadScene("Story");
    }

    public bool CheckFileExists()
    {
        string strFile = Application.dataPath + "/Resource/Player.json";
        FileInfo fileInfo = new FileInfo(strFile);

        return fileInfo.Exists;
    }

    public void LoadCharacter()
    {
        if (!CheckFileExists())
        {
            OpenWarningMessage();
            return;
        }
        else
        {
            if (userData.Count > 0)
                LoadDataMessage();
            else
                OpenWarningMessage();
        }
        //SceneManager.LoadScene("CharacterSelect");
    }
    //public void LoadData()
    //{
    //    string Jsonstring = File.ReadAllText(Application.dataPath + "/Resource/Player.json");
    //    userData = JsonMapper.ToObject(Jsonstring);
    //    //ParsingJsonPlayerStats(itemData);
    //}
    public void ClickSlot()
    {
        if (slotText.Count < slotNum+1)
        {
            OpenWarningMessage();
            return;
        }
        GameObject.Find("WarningMessege").transform.Find("ThisData").gameObject.SetActive(true);
        choseDataText.text = "You chose " + playerList[slotNum].name + "\n"+"What are you going to do?";
        selectSlot = slotNum;
        playerData = playerList[selectSlot];
        Debug.Log(playerData.completeTutorial);
    }
    public void OpenWarningMessageDelete()
    {
        GameObject.Find("WarningMessege").transform.Find("DeleteData").gameObject.SetActive(true);
    }
    public void LoadDataMessage()
    {
        GameObject.Find("UI").transform.Find("LoadGame").gameObject.SetActive(true);
    }
    public void CloseLoadData()
    {
        GameObject.Find("UI").transform.Find("LoadGame").gameObject.SetActive(false);
    }
    public void OpenWarningMessage()
    {
        GameObject.Find("WarningMessege").transform.Find("NoData").gameObject.SetActive(true);
    }
    public void CloseWarningMessage()
    {
        GameObject.FindGameObjectWithTag("Warning").SetActive(false);
    }
    public void StartLoadGame()
    {
        //DataManager.instance.playerData = playerList[selectSlot];
        //Debug.Log(GameManager.instance.playerData.name);
        //playerData.completeTutorial = true;
        SceneManager.LoadScene("Pub");
    }
    //public void MouseOverFirstSlot()
    //{
    //    slotNum = 0;
    //    this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    //}
    //public void MouseOverSecondSlot()
    //{
    //    slotNum = 1;
    //    this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    //}
    //public void MouseOverThirdSlot()
    //{
    //    slotNum = 2;
    //    this.gameObject.transform.Find("Click").gameObject.SetActive(true);

    //}
    //public void UnMouseOver()
    //{
    //    this.gameObject.transform.Find("Click").gameObject.SetActive(false);

    //}

public void DeleteData()
    {
        playerList.RemoveAt(slotNum);
        slotText.RemoveAt(slotNum);
        playerDataText[userData.Count-1].text = "Empty";

        GameObject.FindGameObjectWithTag("Warning").SetActive(false);
        tempData = userData;
       
        //ParsingJsonData(TempData, TempData.Count);
        RefrashJsonData();
    }
    public void RefrashJsonData()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            playerDataText[i].text = "Name : " + playerList[i].name + "\n" + "ID : " + playerList[i].id;
        }
        File.Delete(Application.dataPath + "/Resource/Player.json");
        JsonData PlayerStateJson = JsonMapper.ToJson(playerList);
        File.WriteAllText(Application.dataPath + "/Resource/Player.json", PlayerStateJson.ToString());

        string UserString = File.ReadAllText(Application.dataPath + "/Resource/Player.json");

        userData = JsonMapper.ToObject(UserString);

    }
    public void ExitGame()
    {
        Application.Quit();

    }
    void Start()
    {
        if (CheckFileExists())
        {
            StartCoroutine(LoaCo());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "MainScene")
                return;
            CloseWarningMessage();
        }
    }
}
