using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MansState
{
    idle, walk, dash, change, attack, attack2, attack3, jump, L_Hit, R_Hit, M_Hit
}
struct MonsStats                                                          //스텟
{
    public string Habitat;
    public string Name;
    public int HP;
    public int Power;
    public float MoveSpeed;
    public float DashSpeed;
    public float AttackSpeed;
    public float PerceptionRange;
    public float AttackRange;
    public bool Perception;

    public MonsStats(string MonsHabitat, string MonsName, int MonsHP, int MonsPower, float MonsMoveSpeed, float MonsDashSpeed, float MonsAttackSpeed, float MonsPerceptionRange,float MonsAttackRange, bool MonsPerception)
    {
        Habitat = MonsHabitat;
        Name = MonsName;
        HP = MonsHP;
        Power = MonsPower;
        MoveSpeed = MonsMoveSpeed;
        DashSpeed = MonsDashSpeed;
        AttackSpeed = MonsAttackSpeed;
        PerceptionRange = MonsPerceptionRange;
        AttackRange = MonsAttackRange;
        Perception = MonsPerception;
    }

}
public class MonsterManager : MonoBehaviour
{
    private GameObject Player;
    private float _moveSpeed = 5.0f;
    private float _dashSpeed = 10.0f;
    private Animator _monsterAnimator;
    private bool IsAttackable = true;
    

    public MansState monsstate;

    MonsStats[] mons = new MonsStats[]
         {
            new MonsStats("Snow","Ogre",1500,150,10f,20f,5.0f,35.0f,8.0f,false),
         };

    // 기본 움직임 
    //아이들 상태 -> 플레이어가 일정 범위 도달시 플레이어 인식
    //플레이어 인식시 -> 점프모션 -> 플레이어에게 대쉬
    // 대쉬 -> 일정거리 공격
    // 공격패턴
    // 1. 기본공격 두번 후 내려찍기
    // 2. 대쉬후 찌르기
    // 3. 
    // 공격 -> 일정 조건 -> 특수공격
    // 피격 -> 오른쪽 피격 OR 왼쪽피격
    // 죽음

    // Start is called before the first frame update
    void Start()
    {
        _monsterAnimator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        SetStateIdle();

    }

    void Update()
    {

        SetMotion();
        MonsWalk();
        PerceptionCheck();

    }

    IEnumerator AttackCoolTime()
    {
        if (IsAttackable == false)
        {
            Debug.Log(IsAttackable);
            SetStateIdle();
            yield break;
        }
        SetStateAttack1();

        IsAttackable = false;
        yield return new WaitForSeconds(mons[0].AttackSpeed);
        IsAttackable = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Sword")
        {
            Debug.Log(col.transform.position);
        }
    }

    void SetStateIdle()
    {
        ResetAnimationParameters();
        monsstate = MansState.idle;
        MonsterAnimationControl();
    }

    void SetStateWalk()
    {
        ResetAnimationParameters();
        monsstate = MansState.walk;
        MonsterAnimationControl();
    }

    void SetStateChange()
    {
        ResetAnimationParameters();
        monsstate = MansState.jump;
        MonsterAnimationControl();
    }

    void SetStateAttack1()
    {
        ResetAnimationParameters();
        monsstate = MansState.attack;
        MonsterAnimationControl();
    }

    void SetStateAttack2()
    {
        ResetAnimationParameters();
        monsstate = MansState.attack2;
        MonsterAnimationControl();
    }

    void SetStateAttack3()
    {
        ResetAnimationParameters();
        monsstate = MansState.attack3;
        MonsterAnimationControl();
    }

    void SetStateHit_L()
    {
        ResetAnimationParameters();
        monsstate = MansState.L_Hit;
        MonsterAnimationControl();
    }

    void SetStateHit_R()
    {
        ResetAnimationParameters();
        monsstate = MansState.R_Hit;
        MonsterAnimationControl();
    }

    void SetStateHit_M()
    {
        ResetAnimationParameters();
        monsstate = MansState.M_Hit;
        MonsterAnimationControl();
    }

    public void MonsterAnimationControl()
    {
        switch ((int)monsstate)
        {
            case 0:
                _monsterAnimator.SetTrigger("IDLE");
                break;
            case 1:
                _monsterAnimator.SetTrigger("WALK");
                break;
            case 2:
                _monsterAnimator.SetTrigger("DASH");
                break;
            case 3:
                _monsterAnimator.SetTrigger("CHANGE");
                break;
            case 4:
                _monsterAnimator.SetTrigger("ATTACK1");
                break;
            case 5:
                _monsterAnimator.SetTrigger("ATTACK2");
                break;
            case 6:
                _monsterAnimator.SetTrigger("ATTACK_SKILL");
                break;
            case 7:
                _monsterAnimator.SetTrigger("JUMP");
                break;
            case 8:
                _monsterAnimator.SetTrigger("HIT_L");
                break;
            case 9:
                _monsterAnimator.SetTrigger("HIT_R");
                break;
            case 10:
                _monsterAnimator.SetTrigger("HIT_M");
                break;
        }
    }
    void ResetAnimationParameters()
    {
        _monsterAnimator.ResetTrigger("IDLE");
        _monsterAnimator.ResetTrigger("ATTACK1");
        _monsterAnimator.ResetTrigger("ATTACK2");
        //_monsterAnimator.ResetTrigger("ATTACK_SKILL");
        _monsterAnimator.ResetTrigger("WALK");
        //_monsterAnimator.ResetTrigger("DASH");
        _monsterAnimator.ResetTrigger("JUMP");
    }
    float DistanceCheck()                               //거리확인
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        return distance;
    }

    void PerceptionCheck()                              //인지 확인
    {
        if (mons[0].PerceptionRange > DistanceCheck())
        {
            if (mons[0].Perception == true)
                return;

            SetStateChange();
            mons[0].Perception = true;
        }
        else
            mons[0].Perception = false;
    }

    void MonsWalk()                                 //몬스터가 앞으로가 가는함수
    {
        if (this._monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump")|| this._monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            return;

        if(monsstate == MansState.walk)
            this.transform.Translate(Vector3.forward * mons[0].MoveSpeed * Time.deltaTime);
    }
 
    void SetMotion()                                  //다음 동작 확인
    {
        if (mons[0].Perception == false)
            return;

        if (mons[0].PerceptionRange > DistanceCheck() && DistanceCheck() > mons[0].AttackRange)
        {
            SetStateWalk();
        }
        else if(DistanceCheck() <= mons[0].AttackRange)
        {
            
            
            StartCoroutine("AttackCoolTime");
            
        }


    }

    void SetAttack()                                //공격으로
    {
        if (mons[0].Perception == false)
            return;

        

        if (DistanceCheck() <= mons[0].AttackRange)
        {
            
        }

    }
    // Update is called once per frame
  
}
