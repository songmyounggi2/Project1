﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharState                                                          //상태
{
    IDLE, MOVE, AVOID, ATTACK1, ATTACK2, ATTACK3,HIT
}

public struct CharStats                                                          //스텟
{
    public int HP;
    public int _moveSpeed;
    public Vector3 _avoidDirection;
    public bool IsAvoidable;
    public float avoidCooltime;
}

public class PlayerManager : MonoBehaviour
{
    private float _moveSpeed = 10.0f;
    private float _runSpeed = 15.0f;
    public Animator _playerAnimator;
    private Vector3 AvoidEndtPos;
    private bool isAvoid;
    private int AttackType;

    public CharStats charStats;

    public CharState charstate;

    private void Awake()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        charstate = CharState.IDLE;
        PlayerAnimationControl();
        isAvoid = false;
        AvoidEndtPos = Vector3.zero;
        AttackType = 0;
        charStats._avoidDirection = Vector3.back;
        charStats.IsAvoidable = true;
        charStats.avoidCooltime = 3.0f;
       
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Left")
        {
            Debug.Log("맞음");
            charstate = CharState.HIT;
            PlayerAnimationControl();
        }
        else if (col.gameObject.tag == "Right")
        {
            Debug.Log("맞음");
            charstate = CharState.HIT;
            PlayerAnimationControl();
        }
    }

    private void PlayerAnimationControl()
    {
        switch ((int)charstate)
        {
            case 0:
                _playerAnimator.SetTrigger("IDLE");
                break;
            case 1:
                _playerAnimator.SetTrigger("MOVE");
                break;
            case 2:
                _playerAnimator.SetTrigger("AVOID");
                break;
            case 3:
                _playerAnimator.SetTrigger("ATTACK1");
                break;
            case 4:
                _playerAnimator.SetTrigger("ATTACK2");
                break;
            case 5:
                _playerAnimator.SetTrigger("ATTACK3");
                break;
            case 6:
                _playerAnimator.SetTrigger("HIT");
                break;
        }
    }
   
    private void CharacterInput()
    {
        if (Input.anyKey)
        {
            ResetAnimationParameters();
            //SetJump();
            SetAttack();
            SetAvoid();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) )
            {
                SetMove();
            }
        }
        else
            SetIdle();

        PlayerAnimationControl();
        

    }
    
    bool CheckIsAttacking()
    {

        if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
            return true;
        else
            return false;
    }
    void CreateColider()
    {
        MeshCollider.Instantiate(this, this.transform);
    }

    void DestroyColider()
    {

    }
    void SetMove() // 무브액션
    {
        if (CheckIsAttacking())
            return;
        //_playerAnimator.ResetTrigger("IDLE");
        float transtime = 0.5f;

        if (Input.GetKey(KeyCode.A))
        {
            if (isAvoid)
                return;

            this.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y",-1f, transtime, Time.deltaTime);
            charStats._avoidDirection = Vector3.left;

        
        }
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.S))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.back+Vector3.left) * _moveSpeed * Time.deltaTime * 0.05f);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
           
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (isAvoid)
                return;
            
            this.transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
            charStats._avoidDirection = Vector3.back;
         
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.back + Vector3.right) * _moveSpeed * Time.deltaTime * 0.05f);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", -1f, transtime, Time.deltaTime);
       

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (isAvoid)
                return;

            this.transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", 0f, transtime, Time.deltaTime);
            charStats._avoidDirection = Vector3.right;
        
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.right + Vector3.forward) * _moveSpeed * Time.deltaTime * 0.05f);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);

          
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (isAvoid)
                return;

            this.transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 0f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", 1f , transtime, Time.deltaTime);

   
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.forward + Vector3.left) * _moveSpeed * Time.deltaTime * 0.05f);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);

        }

    }
    IEnumerator AvoidTimer()
    {
        if (charStats.IsAvoidable == true)
        {
            charStats.IsAvoidable = false;

            AvoidEndtPos = this.transform.position + this.transform.localRotation * charStats._avoidDirection * 8;
            isAvoid = true;
            charstate = CharState.AVOID;
            PlayerAnimationControl();
            _playerAnimator.SetInteger("AVOID_TYPE", 2);

            yield return new WaitForSeconds(charStats.avoidCooltime);
            charStats.IsAvoidable = true;
        }

    }
    void SetAvoid()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {    
            StartCoroutine("AvoidTimer");
        }
    }
    void AvoidPosition()
    {
        if (!isAvoid)
            return;
        if (transform.position == AvoidEndtPos)
        {
            isAvoid = false;
           // gameObject.GetComponent<lockOn>().enabled = true;
            _playerAnimator.SetInteger("AVOID_TYPE",0);
            charstate = CharState.MOVE;
            Debug.Log("그만도망가");
            
        }
        Debug.Log("욍포지션" + AvoidEndtPos);
        transform.position = Vector3.MoveTowards(transform.position, AvoidEndtPos, 15 * Time.deltaTime);
       

    }
    //void SetJump()
    //{
    //    ResetAnimationParameters();
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        charstate = Charstate.jump;
    //}
    //콤보 대기시간,콤보 키 입력은 어캐?
    //한번클릭 -> 공격, 시간 내에 두번클릭 -> 연속공격, 드래그 -> 스킬
    //클릭을 때는 순간 돌아가는데?
    //클릭을 땔때 이거라면 돌아가지 않게?

    //시간안에 클릭하지 않으면 돌아감 -> 공격 애니메이션이 실행중인지 확인
    // 실행 중에 공격했다면 다음으로 아니라면 아이들?
    // 모션이 끝나기 전에 클릭시 연계공격     

    private void SetAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            {
                charstate = CharState.ATTACK2;
            }

            else if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                charstate = CharState.ATTACK3;
            }
            else if (_playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
                charstate = CharState.IDLE;
            else
            {
                charstate = CharState.ATTACK1;

            }
        }
    
    }
    void CreatSwordCollider()
    {
        GameObject.Find("Dragonblade(Clone)").GetComponent<SwordManager>().CreateSwordCollider();
    }
    void SetIdle()
    {
        if (CheckIsAttacking())
            return;

        ResetAnimationParameters();
        charstate = CharState.IDLE;
    }

    void ResetAnimationParameters()
    {
        _playerAnimator.ResetTrigger("IDLE");
        _playerAnimator.ResetTrigger("ATTACK1");
        _playerAnimator.ResetTrigger("ATTACK2");
        _playerAnimator.ResetTrigger("ATTACK3");
        _playerAnimator.ResetTrigger("MOVE");
        _playerAnimator.ResetTrigger("AVOID");
        _playerAnimator.ResetTrigger("HIT");
    }

    // Update is called once per frame
    void Update()
    {
       
        CharacterInput();
        AvoidPosition();
    }
}
