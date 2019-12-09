using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float MoveSpeed;
    Vector3 lookDirection = Vector3.zero;
    Animator Animator;
    
    int state;
    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 2;
        state = 0;
        Animator = gameObject.GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();

    }
    void PlayerInput()
    {
        
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.W))
            {
                lookDirection = Vector3.forward;
                Animator.SetBool("WALK", true);
                this.transform.rotation = Quaternion.LookRotation(lookDirection);
                this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                lookDirection = Vector3.left;
                Animator.SetBool("WALK",true);
                this.transform.rotation = Quaternion.LookRotation(lookDirection);
                this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                lookDirection = Vector3.back;
                Animator.SetBool("WALK", true);
                this.transform.rotation = Quaternion.LookRotation(lookDirection);
                this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                lookDirection = Vector3.right;
                Animator.SetBool("WALK", true);
                this.transform.rotation = Quaternion.LookRotation(lookDirection);
                this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
           

        }
        else
            Animator.SetBool("WALK", false);

    }
    void SetIdle()
    {
       
    }
}
