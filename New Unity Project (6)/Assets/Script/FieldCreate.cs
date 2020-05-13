using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CreateTutorialField(DataManager dataManager)
    {
        if (dataManager.monsterMapSet.area== "forest")
        {
            //Instantiate(Resources.Load("Prefabs/Pest"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
        else if (dataManager.monsterMapSet.name == "mountain")
        {
            //Instantiate(Resources.Load("Prefabs/Juggernaut"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
        else if (dataManager.monsterMapSet.name == "desert")
        {
            //Instantiate(Resources.Load("Prefabs/Mudman"), new Vector3(14.79f, 0.22f, -2.06f), Quaternion.Euler(0f, -90f, 0f));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
