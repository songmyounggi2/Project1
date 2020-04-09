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
    public float moveSpeed = 3.0f;
    public Vector3 avoidEndtPos;
    public Vector3 skillEndtPos;
    public Vector3 avoidDirection;
    public GameObject skillTable;
    GameObject blackBox;
    float clickTime = 0f;
    public bool useSkill = false;
    public string skillName;

    protected override IEnumerator Idle()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }
    protected override IEnumerator Move()
    {
        do
        {
            yield return null;
            if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
                SetState(PlayerState.Idle);
        } while (!isNewState);

    }
    protected virtual IEnumerator Avoid()
    {
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, avoidEndtPos, 15 * Time.deltaTime);
            yield return null;
            if (this.transform.position == avoidEndtPos)
            {
                avoidEndtPos = Vector3.zero;
                SetState(PlayerState.Idle);
            }

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

    protected virtual IEnumerator Test()
    {
        do
        {
            yield return null;
        } while (!isNewState);
    }


    protected virtual IEnumerator Attack1()
    {
        do
        {
            yield return null;
            AnimatorStateInfo animInfo;
            animInfo = anim.GetCurrentAnimatorStateInfo(0);

            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
            {
                SetIdle();
            }
        } while (!isNewState);
    }
    protected virtual IEnumerator Attack2()
    {
        do
        {
            yield return null;
            MousePress();
            
        } while (!isNewState);
    }
    protected virtual IEnumerator Attack3()
    {
        do
        {
            yield return null;
            //SetIdle();
        } while (!isNewState);
    }

    protected virtual IEnumerator Hit()
    {
        do
        {
            yield return null;
            SetIdle();
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
        skillEndtPos = this.transform.position + this.transform.localRotation * Vector3.forward * 8;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, skillEndtPos, 3 * Time.deltaTime);
            yield return null;
        } while (!isNewState);
    }
    private void SetAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                SetState(PlayerState.Attack2);
            }

            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                //SetState(PlayerState.Attack3);
            }
            else
            {
                SetState(PlayerState.Attack1);
            }
        }
        //MousePress();

    }
    void MousePress()
    {
        if (Input.GetMouseButton(0))
        {  
            clickTime = clickTime + Time.deltaTime * 10f;
            //Debug.Log(clickTime);
            if (clickTime > 10.0f)
            {
                Time.timeScale = 0.01F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                skillTable.gameObject.SetActive(true);
                blackBox.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (useSkill)
                SetSKill();
       
            else
            {
                AnimatorStateInfo animInfo;
                animInfo = anim.GetCurrentAnimatorStateInfo(0);

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
                {
                    SetIdle();
                }  
            }
                
            skillTable.gameObject.SetActive(false);
            blackBox.gameObject.SetActive(false);
            useSkill = false;
            clickTime = 0.0f;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; 
        }
    }
    public void SetIdle()
    {

        SetState(PlayerState.Idle);
        Debug.Log("dd");
    }
    public void SetSKill()
    {
        Debug.Log(skillName);

        if(skillName == "Skill2")
            SetState(PlayerState.Attack3);
        else if (skillName == "Skill3")
            SetState(PlayerState.Skill1);
    }
    // Start is called before the first frame update
    void Start()
    {
        skillTable = GameObject.Find("UI").transform.Find("SkillTable").gameObject;
        blackBox = GameObject.Find("UI").transform.Find("BlackBox").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float transtime = 0.5f;

        if (Input.GetKey(KeyCode.A))
        {
            SetState(PlayerState.Move);

            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 0f, transtime, Time.deltaTime);
            avoidDirection = Vector3.left;


        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            SetState(PlayerState.Move);

            this.transform.Translate((Vector3.back + Vector3.left) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
            avoidDirection = Vector3.back;
        }
        if (Input.GetKey(KeyCode.S))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
            avoidDirection = Vector3.back;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.back + Vector3.right) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
            avoidDirection = Vector3.back;

        }

        if (Input.GetKey(KeyCode.D))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 0f, transtime, Time.deltaTime);
            avoidDirection = Vector3.right;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.right + Vector3.forward) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);
            avoidDirection = Vector3.right;

        }
        if (Input.GetKey(KeyCode.W))
        {
            SetState(PlayerState.Move);
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);
            avoidDirection = Vector3.back;

        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            SetState(PlayerState.Move);
            this.transform.Translate((Vector3.forward + Vector3.left) * moveSpeed * Time.deltaTime * 0.05f);
            anim.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            anim.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(PlayerState.Avoid);
            anim.SetInteger("AVOID_TYPE", 2);
            avoidEndtPos = this.transform.position + this.transform.localRotation * avoidDirection * 8;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(PState.ToString());
            SetState(PlayerState.Hit);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(PState.ToString());
            SetState(PlayerState.Test);
            
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                anim.SetFloat("ATTACK_TYPE", 2.0f);
            }

            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                anim.SetFloat("ATTACK_TYPE", 3.0f);
            }
            else
            {
                anim.SetFloat("ATTACK_TYPE", 1.0f);
            }
        }
        SetAttack();
        
    }
}
