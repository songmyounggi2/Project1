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
    public InputField inputField;
    string writerText;
    string PlayerName;
    public Animator PubOwner;
    public int PlayerId;


    // Start is called before the first frame update
    void Start()
    {
        //.Find("UI").transform.Find("Fadein").gameObject.SetActive(true);
        PlayerName = "???";
        PlayerId = 0;
        EndFirstScript();
        StartCoroutine(TextPractice());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextPractice_NoName()
    {


        
        yield return StartCoroutine(NormalChat(PlayerName, "Ask and go to the blue"));
        yield return new WaitForSeconds(3f);
        PubOwner.SetTrigger("DIALOG");
        yield return StartCoroutine(NormalChat("Owner", "?!!"));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(NormalChat("Owner", "What?! \n Hey puppy!We have only beer!"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat(PlayerName, "Ask and go to the blue..."));
        yield return new WaitForSeconds(2.3f);
        yield return StartCoroutine(NormalChat("Owner", "hahahaha!! Seriously ? \n Don’t blame me for what happened! \n so, what's your name ?"));
        yield return new WaitForSeconds(4f);
        EndFirstScript();
       
    }
    IEnumerator TextPractice()
    {
         yield return StartCoroutine(NormalChat(PlayerName, PlayerName+"...\n"+ PlayerName));
        yield return new WaitForSeconds(3f);
        PubOwner.SetTrigger("FOLLOW");
        yield return StartCoroutine(NormalChat("Owner", "ok... "+ PlayerName + "\nFollow me"));
        yield return new WaitForSeconds(3f);
        GameObject.Find("UI").transform.Find("Fadeout").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("SampleScene");
    }
    void EndFirstScript()
    {
        PubOwner.SetTrigger("IDLE");
        inputField.gameObject.SetActive(true);
        chatText.gameObject.SetActive(false);
        characterName.gameObject.SetActive(false);
        

    }
    public void SetName()
    {
        PlayerName = inputField.text;
        SaveName(PlayerName);
        // charStats.Name = PlayerName;
        inputField.gameObject.SetActive(false);
        chatText.gameObject.SetActive(true);
        characterName.gameObject.SetActive(true);
        
        StartCoroutine(TextPractice());

    }
    public void SaveName(string playerName)
    {
        //numCheck();
        GameManager.instance.playerData = new Player(playerName, 50 , 3 , 1 , PlayerId);
        
        Debug.Log(PlayerId);
       //player.Name = playerName;

       JsonData PlayerStateJson = JsonMapper.ToJson(GameManager.instance.playerData);

        File.WriteAllText(Application.dataPath + "/Resource/Player.json", PlayerStateJson.ToString());

        

    }
    //int IDCheck()
    //{
    //    int idNum = 0;

    //    for (int i = 0; i < DataManager.instance.playerList.Count; i++)
    //    {
    //        idNum +=DataManager.instance.playerList[i].id;
    //        Debug.Log(i + "번째 아이디 " + DataManager.instance.playerList[i].id);
    //    }
    //    return idNum;
    //}
    //void numCheck()
    //{
    //    if (IDCheck() == 11)
    //        PlayerId = 100;
    //    else if(IDCheck() == 1 || IDCheck() == 101)
    //        PlayerId = 10;
    //    else
    //        PlayerId = 1;
    //}
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
