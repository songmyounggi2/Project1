using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCrash : MonoBehaviour
{

    //MonsterManager monsterManager = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>();

    MansState MansState;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("충돌");
        // transform.localRotation;
        //transform.position;

        if (col.gameObject.tag == "Left")
            GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>().monsstate = MansState.L_Hit;
            
        else if (this.gameObject.tag == "Right")
            GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>().monsstate = MansState.R_Hit;
        else if (this.gameObject.tag == "Middle")
            GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>().monsstate = MansState.R_Hit;
        
        GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>().MonsterAnimationControl();
        // 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
