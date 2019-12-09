using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogText : MonoBehaviour
{
    public Text ChatText;
    public Text CharacterName;
    public InputField inputField;
    string writerText;
    string PlayerName;
    public Animator PubOwner;

    // Start is called before the first frame update
    void Start()
    {
        PlayerName = "주인공";
        StartCoroutine(TextPractice_NoName());
        //PubOwner = GameObject.Find("PubOwner").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TextPractice_NoName()
    {
        PubOwner.SetTrigger("DIALOG");
        yield return StartCoroutine(NormalChat(PlayerName, "Ask and go to the blue"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("주인장", "?!!"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("주인장", "What?! \n Hey puppy!We have only beer!"));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat(PlayerName, "Ask and go to the blue..."));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("주인장", "Are you serious? \n Don’t blame me for what happened! \n so, what's your name ?"));
        yield return new WaitForSeconds(4f);
        EndFirstScript();
        
    }
    IEnumerator TextPractice()
    {
        PubOwner.SetTrigger("FOLLOW");
        yield return StartCoroutine(NormalChat(PlayerName, PlayerName+"...\n"+ PlayerName));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(NormalChat("주인장", "ok "+ PlayerName + "\nFollow me"));
        yield return new WaitForSeconds(3f);
    }
    void EndFirstScript()
    {
        PubOwner.SetTrigger("IDLE");
        inputField.gameObject.SetActive(true);
        ChatText.gameObject.SetActive(false);
        
    }
    public void SetName()
    {
        PlayerName = inputField.text;
        inputField.gameObject.SetActive(false);
        ChatText.gameObject.SetActive(true);
        StartCoroutine(TextPractice());
    }
    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.01f);
        }

    }
    IEnumerator Name(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
