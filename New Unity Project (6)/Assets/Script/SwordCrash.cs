using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCrash : MonoBehaviour
{

    //MonsterManager monsterManager = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>();

    MansState mansState;
    CharState charState;
    public MeshCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        //swordCollider = this.gameObject.
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("충돌");
        // transform.localRotation;
        //transform.position;

        if (col.gameObject.tag == "Left")
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().monsstate = MansState.L_Hit;
        else if (this.gameObject.tag == "Right")
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().monsstate = MansState.R_Hit;
        else if (this.gameObject.tag == "Middle")
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().monsstate = MansState.R_Hit;

        GameObject.Find("Juggernaut").GetComponent<MonsterManager>().MonsterAnimationControl();
        // 
    }
    void CheckAttack()
    {
        if (GameObject.Find("Character").GetComponent<PlayerManager>().charstate == CharState.ATTACK)
            swordCollider.enabled = true;
        else if (GameObject.Find("Character").GetComponent<PlayerManager>().charstate != CharState.ATTACK)
            swordCollider.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }
}
