using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;



public class DialogText : MonoBehaviour
{
    public Text chatText;
    public Text characterName;
    public Image map;
    public InputField inputField;
    string writerText;
    string playerName;
    public Animator PubOwner;
    public int PlayerId;
    GameObject Dialog;

    DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = DataManager.instance;
        playerName = "???";
        PlayerId = 0;
 
        Dialog = GameObject.Find("UI").transform.Find("Dialog").gameObject;

        if (!dataManager.playerData.completeTutorial)
        {
            StartCoroutine(FirstMeetDialog());
        }
        else
            StartCoroutine(NewMonster());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FirstMeetDialog()
    {
        DataManager.instance.playerData.completeTutorial = true;
        yield return StartCoroutine(NormalChat(playerName, "Ask and go to the blue"));
        yield return new WaitForSeconds(3f);
        PubOwner.SetTrigger("DIALOG");
        yield return StartCoroutine(NormalChat("Owner", "?!!"));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(NormalChat("Owner", "What?! \n Hey puppy!We have only beer!"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat(playerName, "Ask and go to the blue..."));
        yield return new WaitForSeconds(2.3f);
        yield return StartCoroutine(NormalChat("Owner", "hahahaha!! Seriously ? \n Don’t blame me for what happened! \n so, what's your name ?"));
        yield return new WaitForSeconds(4f);
        EndFirstMeetDialog();
    }

    IEnumerator FirstBattleDialog()
    {
        yield return StartCoroutine(NormalChat(playerName, playerName + "...\n" + playerName));
        yield return new WaitForSeconds(3f);
        PubOwner.SetTrigger("FOLLOW");
        yield return StartCoroutine(NormalChat("Owner", "ok... " + playerName + "\nFollow me"));
        yield return new WaitForSeconds(3f);
        GameObject.Find("UI").transform.Find("Fadeout").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator NewMonster()
    {
        playerName = dataManager.playerData.name;
        PubOwner.SetTrigger("DIALOG");
        yield return StartCoroutine(NormalChat("Owner", "Are you still alive?"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat(playerName, "...Damn...old man"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("Owner", "hahahaha!! \n i'm just kidding"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("Owner", "Here's the new news"));
        yield return new WaitForSeconds(3f);
        ShowMap();

    }

    void EndDialog()
    {
        PubOwner.SetTrigger("IDLE");
        chatText.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
    }

    void EndFirstMeetDialog()
    {
        EndDialog();
        inputField.gameObject.SetActive(true);
    }

    void ShowMap()
    {
        EndDialog();

        map.gameObject.SetActive(true);
        Dialog.SetActive(false);
    }

    public void SetName()
    {
        playerName = inputField.text;
        SaveName(playerName);

        inputField.gameObject.SetActive(false);
        chatText.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
        
        StartCoroutine(FirstBattleDialog());
    }

    public void SaveName(string playerName)
    {
        DataManager.instance.playerData = new Player(playerName, 50 , 3 , 1 , PlayerId , true);
        DataManager.instance.playerList.Add(DataManager.instance.playerData);

       JsonData PlayerStateJson = JsonMapper.ToJson(DataManager.instance.playerList);

        File.WriteAllText(Application.dataPath + "/Resource/Player.json", PlayerStateJson.ToString());
    }

    int IDCheck()
    {
        int idNum = 0;

        for (int i = 0; i < DataManager.instance.playerList.Count; i++)
        {
            idNum += DataManager.instance.playerList[i].id;
            Debug.Log(i + "번째 아이디 " + DataManager.instance.playerList[i].id);
        }
        return idNum;
    }
    void numCheck()
    {
        if (IDCheck() == 11)
            PlayerId = 100;
        else if (IDCheck() == 1 || IDCheck() == 101)
            PlayerId = 10;
        else
            PlayerId = 1;
    }
    IEnumerator NormalChat(string narrator, string narration)
    {
        characterName.text = narrator;
        writerText = "";

        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            chatText.text = writerText;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
