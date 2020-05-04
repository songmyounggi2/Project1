using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class MonsterMapSet
{
    public string name;
    public string area;
    public Vector3 pos;
    public float lv;
    public GameObject monsterIcon;

    public MonsterMapSet(string name, string area, Vector3 pos, float lv, GameObject monsterIcon)
    {
        this.name = name;
        this.area = area;
        this.pos = pos;
        this.lv = lv;
        this.monsterIcon = monsterIcon;
    }
}
public class MapControl : MonoBehaviour
{
    public static int EASY = 10;
    public static int NORMAL = 40;
    public static int HARD = 80;
    public GameObject map;
    bool mapOn;

    int playerPower;
    int maxMonsterLV;
    int minMonsterLV;
    int maxMonsterNum;
    int minMonsterNum;
    //Vector3 pointerPos;
    //GameObject obj = Instantiate(Resources.Load("/Prefabs/MonsList"+i)) as GameObject;

    MonsterMapSet monsterMapSet;
    List<MonsterMapSet> monsterMapList = new List<MonsterMapSet>();
    List<Vector3> pointerPos = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("UI").transform.Find("Map").gameObject;
        for (int i =0; i<3; i++)
        {
            GameObject obj = Instantiate(Resources.Load("Prefabs/MonsList"+(i+1))) as GameObject;
            GameObject spawner = GameObject.Find("UI").transform.Find("Map").Find("Spawner" + (i + 1)).gameObject ;
            //Vector3 spawnerPos = GameObject.Find("UI").transform.Find("Map").Find("Spawner"+(i+1)).transform.position;

            monsterMapSet = new MonsterMapSet("pest", "forest", spawner.transform.position , 1 , obj);
            monsterMapList.Add(monsterMapSet);
            Instantiate(monsterMapList[i].monsterIcon, Vector3.zero, Quaternion.identity);
            monsterMapList[i].monsterIcon.transform.SetParent(spawner.transform, false);
            pointerPos.Add(spawner.transform.position + new Vector3(0,20,0));
        }
        //GameObject pointerObj = Instantiate(Resources.Load("Prefabs/pointer")) as GameObject;

        //Instantiate(mapPointer, pointerPos[0], Quaternion.identity);
        //mapPointer.transform.SetParent(this.gameObject.transform);
        //mapPointer.transform.SetParent(GameObject.Find("UI").transform.Find("Map").transform);
        
        Debug.Log(pointerPos[0]);

    }
    // Update is called once per frame

    void CheckDifficulty()
    {
        if (0< playerPower && playerPower < EASY)
        {
            minMonsterLV = 1;
            maxMonsterLV = playerPower + 2;
            minMonsterNum = 1;
            maxMonsterNum = 2;
            
        }
        else if (EASY <= playerPower && playerPower < NORMAL)
        {
            minMonsterLV = playerPower - 2;
            maxMonsterLV = playerPower + 5;
            minMonsterNum = 2;
            maxMonsterNum = 3;
        }
        else if (NORMAL <= playerPower && playerPower < HARD)
        {
            minMonsterLV = playerPower - 1;
            maxMonsterLV = playerPower + 10;
            minMonsterNum = 3;
            maxMonsterNum = 4;
        }
        else
        {
            minMonsterLV = playerPower + 3;
            maxMonsterLV = playerPower + 20;
            minMonsterNum = 4;
            maxMonsterNum = 6;
        }
    }
    void Update()
    {

        CheckDifficulty();
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (map.activeSelf == true)
            {
                mapOn = false;
                map.SetActive(false);
                
            }
            else
            {
                mapOn = true;
                map.SetActive(true);
            }
        }
    }
}
