using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public enum CharState                                                          //상태
//{
//    IDLE,
//    MOVE,
//    AVOID,
//    ATTACK1,
//    ATTACK2,
//    ATTACK3,
//    SMASH,
//    HIT,
//    Test
//}

//public struct CharStats                                                          //스텟
//{
//    public string Name;
//    public int HP;
//    public int _moveSpeed;
//    public Vector3 _avoidDirection;
//    public bool IsAvoidable;
//    public float avoidCooltime;
//}


public class PlayerManager : MonoBehaviour
{
    //string playerName;
    public Text playerName;
    private float moveSpeed = 10.0f;
    //public Animator playerAnimator;
  

  

    private void Awake()
    {
        DataLaod();
    }

    void DataLaod()
    {
        if (SceneManager.GetActiveScene().name != "SampleScene")
            return;

        playerName.text = GameManager.instance.playerData.name;
    }
    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();

        
         //AttackType = 0;
         //LoadPlayerStats();
        //charStats.Name = File.ReadAllText(Application.dataPath + "/Resource/Player.json");
        

    }
    void LoadPlayerStats()
    {
        //string Jsonstring = File.ReadAllText(Application.dataPath + "/Resource/Player.json");
        //JsonData itemData = JsonMapper.ToObject(Jsonstring);
        //ParsingJsonPlayerStats(itemData);
       // Debug.Log(playerName);
    }
    void ParsingJsonPlayerStats(JsonData stats)
    {
        //for (int i = 0; i < stats.Count; i++)
        //{

        //    playerName = DataManager.instance.playerData.name;
            
        //}


    }

    void CreateColider()
    {
        MeshCollider.Instantiate(this, this.transform);
    }

    void DestroyColider()
    {

    }

    void CreatSwordCollider()
    {
        GameObject.Find("Dragonblade(Clone)").GetComponent<SwordManager>().CreateSwordCollider();
    }

    // Update is called once per frame
    void Update()
    {
       
 
    }
}
