using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControl : MonoBehaviour
{
    DataManager dataManager;
    Player player;
    MonsterCreater monsterCreater = null;
    FieldCreate fieldCreate = null;
    bool isFirst = true;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        dataManager = DataManager.instance;
        player = dataManager.playerData;
        monsterCreater = new MonsterCreater();
        fieldCreate = new FieldCreate(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (!isFirst)
                return;
            isFirst = false;
            if (player.completeTutorial)
            {
                monsterCreater.CreateTutorialMonster(dataManager);
                fieldCreate.CreateTutorialField(dataManager);
            }
        }



        
    }
}
