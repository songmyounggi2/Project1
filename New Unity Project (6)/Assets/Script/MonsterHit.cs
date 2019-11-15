using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            Debug.Log("충돌");
        }
        Debug.Log("충돌");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
