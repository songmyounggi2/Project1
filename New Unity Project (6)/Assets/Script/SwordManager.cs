using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{

    //MonsterManager monsterManager = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>();

    MansState mansState;
    CharState charState;
    BoxCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        //swordCollider = this.gameObject.
        swordCollider = this.gameObject.GetComponent<BoxCollider>();
        swordCollider.enabled = false;
    }
    public void CreateSwordCollider()
    {
        swordCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider col)
    {



        if (col.gameObject.tag == "Left"|| col.gameObject.tag == "Right" || col.gameObject.tag == "Mibble")
        {

            swordCollider.enabled = false;
           
        }

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
