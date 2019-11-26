using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharState                                                          //상태
{
    IDLE, MOVE, ATTACK, AVOID,
}
public struct CharStats                                                          //스텟
{
    int HP;
    int _moveSpeed;

}


public class PlayerManager : MonoBehaviour
{
    private float _moveSpeed = 10.0f;
    private float _runSpeed = 15.0f;
    private Animator _playerAnimator;
    private Vector3 Look;
    private Vector3 AvoidStartPos;
    private Vector3 AvoidEndtPos;
    private bool isAvoid;



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
                _playerAnimator.SetTrigger("AVOID");
                break;
            case 7:
                _playerAnimator.SetTrigger("ATTACK_SKILL");
                break;
            case 8:
                _playerAnimator.SetTrigger("AVOID_LEFT");
                break;
            case 9:
                _playerAnimator.SetTrigger("AVOID_RIGHT");
                break;
            case 10:
                _playerAnimator.SetTrigger("AVOID_BACK");
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
        if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("AttackSkill"))
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
        _playerAnimator.ResetTrigger("IDLE");
        float transtime = 0.5f;

        if (Input.GetKey(KeyCode.A))
        {
            if (isAvoid)
                return;

            this.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", 1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y",-1f, transtime, Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {

                AvoidEndtPos = this.transform.position + this.transform.localRotation * Vector3.left * 15 + this.transform.localRotation * Vector3.forward * 12;
              

                //gameObject.GetComponent<lockOn>().enabled = false;

                Debug.Log("AvoidEndtPos" + AvoidEndtPos);

                isAvoid = true;
                charstate = CharState.AVOID;
                _playerAnimator.SetInteger("AVOID_TYPE", 1);

            }
        }
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.S))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.back+Vector3.left) * _moveSpeed * Time.deltaTime / 20f);
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                AvoidEndtPos = this.transform.position + this.transform.localRotation * Vector3.back * 8;
               
                
                //gameObject.GetComponent<lockOn>().enabled = false;

                Debug.Log("어보이드 엔드 포지션" + AvoidEndtPos);

              
                charstate = CharState.AVOID;
                _playerAnimator.SetInteger("AVOID_TYPE", 2);
                isAvoid = true;

            }
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.back + Vector3.right) * _moveSpeed * Time.deltaTime / 20f);
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
               

                //gameObject.GetComponent<lockOn>().enabled = false;

                AvoidEndtPos = this.transform.position + this.transform.localRotation * Vector3.right * 15 + this.transform.localRotation * Vector3.forward * 12;

                isAvoid = true;
                charstate = CharState.AVOID;
                _playerAnimator.SetInteger("AVOID_TYPE", 3);

            }
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            if (isAvoid)
                return;

            this.transform.Translate((Vector3.right + Vector3.forward) * _moveSpeed * Time.deltaTime / 20f);
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

            this.transform.Translate((Vector3.forward + Vector3.left) * _moveSpeed * Time.deltaTime / 20f);
            charstate = CharState.MOVE;
            _playerAnimator.SetFloat("MOVE_DIRECTION_X", -1f, transtime, Time.deltaTime);
            _playerAnimator.SetFloat("MOVE_DIRECTION_Y", 1f, transtime, Time.deltaTime);

        }

    }
    void AvoidPosition()
    {
        Debug.Log("현 포지션" + transform.position);
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
        transform.position = Vector3.MoveTowards(transform.position, AvoidEndtPos, 25 * Time.deltaTime);
       

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
            charstate = CharState.ATTACK;
            _playerAnimator.SetTrigger("ATTACK");

            if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                _playerAnimator.SetFloat("ATTACK_TYPE",2.0f);
            else if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
                _playerAnimator.SetFloat("ATTACK_TYPE", 3.0f);
            else
                _playerAnimator.SetFloat("ATTACK_TYPE", 1.0f);
        }
    }

    void SetIdle()
    {
        if (CheckIsAttacking())
        {
            return;
        }
        ResetAnimationParameters();
        charstate = CharState.IDLE;
    }
    void ResetAnimationParameters()
    {
        _playerAnimator.ResetTrigger("IDLE");
        _playerAnimator.ResetTrigger("ATTACK");
        _playerAnimator.ResetTrigger("MOVE");
        _playerAnimator.ResetTrigger("AVOID");
    }

    // Update is called once per frame
    void Update()
    {
       
        CharacterInput();
        AvoidPosition();
    }
}
