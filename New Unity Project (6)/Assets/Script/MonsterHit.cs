using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    Transform MonsTransform;
    private Animator _monsterAnimator;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider col)
    {
        // transform.localRotation;
        //transform.position;

        //if (col.gameObject.tag == "Sword")
        //{
        //    //Debug.Log(this.gameObject.name);
        //    if(this.gameObject.tag == "Left")
        //        _monsterAnimator.SetTrigger("Hit_L");
        //    else if (this.gameObject.tag == "Right")
        //        _monsterAnimator.SetTrigger("Hit_R");

        //}
       // Debug.Log("충돌");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
