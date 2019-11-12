using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _moveSpeed = 5.0f;
    private Animator _playerAnimator;


    public enum CharState                                                          //상태
    {
         idle,walk_left, walk_right, walk_forward, walk_backward, attack, attack2, attack3,
    }
    public struct CharStats                                                          //스텟
    {
        int HP;
        int _moveSpeed;

    }
 
    public CharState charstate;

    private void Awake()
    {
      
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        charstate = CharState.idle;
        PlayerAnimationControl();

    }
    private void PlayerAnimationControl()
    {
        switch ((int)charstate)
        {
            case 0:
                _playerAnimator.SetTrigger("IDLE");
                break;
            case 1:
                _playerAnimator.SetTrigger("MOVE_LEFT");
                break;
            case 2:
                _playerAnimator.SetTrigger("MOVE_RIGHT");
                break;
            case 3:
                _playerAnimator.SetTrigger("MOVE_FORWARD");
                break;
            case 4:
                _playerAnimator.SetTrigger("MOVE_BACKWARD");
                break;
            case 5:
                _playerAnimator.SetTrigger("ATTACK");
                break;
            case 6:
                _playerAnimator.SetTrigger("ATTACK2");
                break;
            case 7:
                _playerAnimator.SetTrigger("ATTACK_SKILL");
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

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                SetWalk();
            }
        }
        else
            SetIdle();

        PlayerAnimationControl();
  
    }
    bool CheckIsAttacking()
    {
        if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("AttackSkill"))
            return true;
        else
            return false;
    }
    void SetWalk()
    {
        if (CheckIsAttacking())
            return;
        _playerAnimator.ResetTrigger("IDLE");


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            charstate = CharState.walk_left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
            charstate = CharState.walk_right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
            charstate = CharState.walk_forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
            charstate = CharState.walk_backward;
        }


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
            if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                charstate = CharState.attack2;
            else if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
                charstate = CharState.attack3;
            else
                charstate = CharState.attack;
        }
    }

    void SetIdle()
    {
        if (CheckIsAttacking())
        {
            return;
        }
        ResetAnimationParameters();
        charstate = CharState.idle;
    }
    void ResetAnimationParameters()
    {
        _playerAnimator.SetTrigger("IDLE");
        _playerAnimator.ResetTrigger("ATTACK");
        _playerAnimator.ResetTrigger("ATTACK2");
        _playerAnimator.ResetTrigger("ATTACK_SKILL");
        _playerAnimator.ResetTrigger("MOVE_LEFT");
        _playerAnimator.ResetTrigger("MOVE_RIGHT");
        _playerAnimator.ResetTrigger("MOVE_FORWARD");
        _playerAnimator.ResetTrigger("MOVE_BACKWARD");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterInput();
    }
}
