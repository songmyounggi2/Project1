using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _moveSpeed = 5.0f;
    private Animator _playerAnimator;

    public enum Charstate
    {
         idle,attack,walk,jump
    }

    public Charstate charstate;
 

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        charstate = Charstate.idle;
        PlayerAnimationColtrol();

    }
    private void PlayerAnimationColtrol()
    {
        switch ((int)charstate)
        {
            case 0:
                _playerAnimator.SetTrigger("IDLE 2 WEAPONS");
                break;
            case 1:
                _playerAnimator.SetTrigger("ATTACK 2 WEAPONS A");
                break;
            case 2:
                _playerAnimator.SetTrigger("ATTACKMOVE");
                break;
        }
    }
    private void CharacterInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                SetWalk();
            SetJump();
            SetAttack();
        }
        else
            SetIdle();

        PlayerAnimationColtrol();
    }
    bool CheckIsAttacking()
    {
        if (this._playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            return true;
        else
            return false;
    }
    void SetWalk()
    {
        ResetAnimationParameters();

        if (CheckIsAttacking())
            return;

        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);

        charstate = Charstate.walk;
    }
    void SetJump()
    {
        ResetAnimationParameters();
        if (Input.GetKeyDown(KeyCode.Space))
            charstate = Charstate.jump;
    }
    private void SetAttack()
    {
        ResetAnimationParameters();
        if (Input.GetMouseButtonDown(0))
            charstate = Charstate.attack;
    }
    void SetIdle()
    {
        ResetAnimationParameters();
        charstate = Charstate.idle;
    }
    void ResetAnimationParameters()
    {
        _playerAnimator.ResetTrigger("IDLE 2 WEAPONS");
        _playerAnimator.ResetTrigger("ATTACK 2 WEAPONS A");
        _playerAnimator.ResetTrigger("ATTACKMOVE");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterInput();
    }
}
