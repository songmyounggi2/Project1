using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{

    //MonsterManager monsterManager = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>();

    MansState mansState;
    CharState charState;
    MeshCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        //swordCollider = this.gameObject.
        swordCollider = this.gameObject.GetComponent<MeshCollider>();
        swordCollider.enabled = false;
    }
    public void CreateSwordCollider()
    {
        swordCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider col)
    {
        //swordCollider.enabled = false;
        // transform.localRotation;
        //transform.position;


        if (col.gameObject.tag == "Monster")
        {
            

            swordCollider.enabled = false;
            ////GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
            //GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_M();
        }

        //else if (this.gameObject.tag == "Right")
        //{
        //    swordCollider.enabled = false;
        //   // GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
        //    GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_R();
        //}
        //else if (this.gameObject.tag == "Left")
        //{
        //    swordCollider.enabled = false;
        //    //GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
        //    GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_L();
        //}

        // GameObject.Find("Juggernaut").GetComponent<MonsterManager>().MonsterAnimationControl();
    }
    void CheckAttack()
    {

      

    }
    

    // Update is called once per frame
    void Update()
    {
        //CheckAttack();
    }
}
