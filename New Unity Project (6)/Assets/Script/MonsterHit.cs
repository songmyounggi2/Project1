using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    Transform MonsTransform;
    private Animator _monsterAnimator;
    Vector3 direction;
    Vector3 hitPosition;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.forward;
        hitPosition = Vector3.zero;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            //Debug.Log(this.gameObject.name);
            if (this.gameObject.tag == "Left")
            {
                direction = Vector3.left;
                hitPosition = this.transform.position;
                Debug.Log("왼쪽");
            }
            else if (this.gameObject.tag == "Right")
            {
                direction = Vector3.right;
                hitPosition = this.transform.position;
                Debug.Log("오른쪽");
            }

            else
            { 
                direction = Vector3.forward;
                hitPosition = this.transform.position;
                Debug.Log("중앙");
            }

            GameObject.Find("Juggernaut").GetComponent<MonsterManager>().hitDirection = direction;


        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
