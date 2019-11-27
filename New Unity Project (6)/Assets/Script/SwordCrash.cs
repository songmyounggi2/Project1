using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCrash : MonoBehaviour
{

    //MonsterManager monsterManager = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterManager>();

    MansState mansState;
    CharState charState;
    MeshCollider swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        //swordCollider = this.gameObject.
        swordCollider = gameObject.GetComponent<MeshCollider>();
        swordCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("충돌");
        // transform.localRotation;
        //transform.position;

        if (col.gameObject.tag == "Middle")
        {
            swordCollider.enabled = false;
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_M();
        }

        else if (this.gameObject.tag == "Right")
        {
            swordCollider.enabled = false;
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_R();
        }
        else if (this.gameObject.tag == "Left")
        {
            swordCollider.enabled = false;
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().ResetAnimationParameters();
            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().SetStateHit_L();
        }

        GameObject.Find("Juggernaut").GetComponent<MonsterManager>().MonsterAnimationControl();
    }
    void CheckAttack()
    {

        if (GameObject.Find("Character").GetComponent<PlayerManager>()._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || GameObject.Find("Character").GetComponent<PlayerManager>()._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || GameObject.Find("Character").GetComponent<PlayerManager>()._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        { }

        else
            swordCollider.enabled = true;

    }
    

    // Update is called once per frame
    void Update()
    {
        //CheckAttack();
    }
}
