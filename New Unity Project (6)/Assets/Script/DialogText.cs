using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;

public class Player
{
    public string Name;
    public int HP;
    public int Power;
    public int MoveSpeed;

    public Player(string name, int hp, int power, int movespeed)
    {
        Name = name;
        HP = hp;
        Power = power;
        MoveSpeed = movespeed;
    }
}

public class DialogText : MonoBehaviour
{
    public Text ChatText;
    public Text CharacterName;
    public InputField inputField;
    string writerText;
    string PlayerName;
    public Animator PubOwner;

    public List<Player> playerList = new List<Player>();


    // Start is called before the first frame update
    void Start()
    {
        //.Find("UI").transform.Find("Fadein").gameObject.SetActive(true);
        PlayerName = "???";

        StartCoroutine(TextPractice_NoName());
        
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
        ChatText.gameObject.SetActive(false);
        CharacterName.gameObject.SetActive(false);
        

    }
    public void SetName()
    {
        PlayerName = inputField.text;
        SaveName(PlayerName);
        // charStats.Name = PlayerName;
        inputField.gameObject.SetActive(false);
        ChatText.gameObject.SetActive(true);
        CharacterName.gameObject.SetActive(true);
        
        StartCoroutine(TextPractice());

    }
    public void SaveName(string playerName)
    {
        playerList.Add(new Player(playerName, 50 , 3 , 1));
        //player.Name = playerName;

        JsonData PlayerStateJson = JsonMapper.ToJson(playerList);

        File.WriteAllText(Application.dataPath + "/Resource/Player.json", PlayerStateJson.ToString());
        Debug.Log(playerList[0].Name);

    }
    IEnumerator NormalChat(string narrator, string narration)
    {
        CharacterName.text = narrator;
        writerText = "";

        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
