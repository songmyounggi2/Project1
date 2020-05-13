using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    Player player;
    

    // Start is called before the first frame update
    void Start()
    {
        //dataManager = DataManager.instance;
    }
    public void CreateTutorialMonster(DataManager dataManager)
    {
        Debug.Log(dataManager.monsterMapSet.name);
        if (dataManager.monsterMapSet.name == "Pest")
        {
            
            Instantiate(Resources.Load("Prefabs/Pest"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
        else if (dataManager.monsterMapSet.name == "Juggernaut")
        {
            Instantiate(Resources.Load("Prefabs/Juggernaut"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
        else if (dataManager.monsterMapSet.name == "Mudman")
        {
            Instantiate(Resources.Load("Prefabs/Mudman"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
