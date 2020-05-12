using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogManager : MonoBehaviour
{
    GameObject Player;
    GameObject NPC;
    GameObject InteractionMessage;
    GameObject Dialog;
    GameObject sideCamera;

    float distance = 0.0f;
    bool spaceAble = false;
    bool IsConversation = false;
    bool tutorial = false;

    DataManager dataManager;
    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PubOwner").gameObject;
        NPC = GameObject.Find("CharacterIn").gameObject;
        InteractionMessage = GameObject.Find("UI").transform.Find("InteractionMessage").gameObject;
        Dialog = GameObject.Find("UI").transform.Find("Dialog").gameObject;
        sideCamera = GameObject.Find("CM vcam2").gameObject;
        dataManager = DataManager.instance;
        map = GameObject.Find("UI").transform.Find("Map").gameObject;
    }
    void CheckDistanceFromNPC()
    {
        distance = Vector3.Distance(Player.transform.position, NPC.transform.position);
        if (IsConversation)
            return;
        if (distance < 10.0f)
        {
            InteractionMessage.SetActive(true);
            spaceAble = true;
        }
        else 
        {
            InteractionMessage.SetActive(false);
            spaceAble = false;
        }
    }
    void PlayerInput()
    {
        if (!spaceAble)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorial = dataManager.playerData.completeTutorial;

            if (tutorial)
            {
                IsConversation = true;
                InteractionMessage.SetActive(false);
                sideCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;
                Dialog.SetActive(true);
            }
            if (!tutorial)
            {
                sideCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().Priority = 1;

                if (map.activeSelf == true)
                {
                    map.SetActive(false);
                }
                else
                {
                    map.SetActive(true);
                }
                IsConversation = true;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistanceFromNPC();
        PlayerInput();
    }
}
