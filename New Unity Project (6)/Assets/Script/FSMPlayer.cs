using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMPlayer : FSMBase
{
    public int currentHP = 100;
    public int maxHP = 100;
    public int exp = 0;
    public int level = 1;
    public int gold = 0;
    public float attack = 40.0f;
    public float attackRange = 1.5f;
    public float moveSpeed = 1.5f;

    protected override IEnumerator Idle()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }
    protected virtual IEnumerator Run()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }
    protected virtual IEnumerator AttackRun()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }


    protected virtual IEnumerator Attack()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }

    protected virtual IEnumerator Dead()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }

    protected virtual IEnumerator Skill1()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float transtime = 0.5f;

        if (Input.GetKey(KeyCode.A))
        {
            SetState(PlayerState.Move);

            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
            //charStats._avoidDirection = Vector3.left;


        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            SetState(PlayerState.Move);

            this.transform.Translate((Vector3.back + Vector3.left) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.back + Vector3.right) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.D))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 0f, transtime, Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.right + Vector3.forward) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.W))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.forward + Vector3.left) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);

        }
    }
}
