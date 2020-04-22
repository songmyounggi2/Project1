using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct MonsterMapSet
{
    string name;
    string booty;
    string area;
    int pos;
    int lv;
    Image monsterImage;
}
public class MapControl : MonoBehaviour
{
    public static int EASY = 10;
    public static int NORMAL = 40;
    public static int HARD = 80;

    int playerPower;
    int maxMonsterLV;
    int minMonsterLV;
    int maxMonsterNum;
    int minMonsterNum;

    List<MonsterMapSet> monsterMapList = new List<MonsterMapSet>();

    // Start is called before the first frame update
    void Start()
    {
        //playerPower = GameManager.instance.playerData.power;
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
    }
}
