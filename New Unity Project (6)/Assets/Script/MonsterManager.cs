using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterManager : MonoBehaviour
{
    public GameObject Player;
    private float _moveSpeed = 5.0f;
    private float _dashSpeed = 10.0f;
    private Animator _monsterAnimator;

    public enum MansState
    {
        idle, walk, dash, change, attack, attack2, attack3,Jump,
    }

    public MansState monsstate;

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
        public bool Perception;

        public MonsStats(string MonsHabitat,string MonsName, int MonsHP,int MonsPower, float MonsMoveSpeed, float MonsDashSpeed, float MonsAttackSpeed, float MonsPerceptionRange, bool MonsPerception)
        {
            Habitat = MonsHabitat;
            Name = MonsName;
            HP = MonsHP;
            Power = MonsPower;
            MoveSpeed = MonsMoveSpeed;
            DashSpeed = MonsDashSpeed;
            AttackSpeed = MonsAttackSpeed;
            PerceptionRange = MonsPerceptionRange;
            Perception = MonsPerception; 
        }

    }
    MonsStats[] mons = new MonsStats[]
         {
            new MonsStats("Snow","Ogre",1500,150,10f,20f,3f,35.0f,false),
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
        monsstate = MansState.idle;
        MonsterAnimationControl();
    }

    private void MonsterAnimationControl()
    {
        //ResetAnimationParameters();
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
        }
    }
    void ResetAnimationParameters()
    {
        _monsterAnimator.ResetTrigger("IDLE");
        _monsterAnimator.ResetTrigger("ATTACK1");
        _monsterAnimator.ResetTrigger("ATTACK2");
        _monsterAnimator.ResetTrigger("ATTACK_SKILL");
        _monsterAnimator.ResetTrigger("WALK");
        _monsterAnimator.ResetTrigger("DASH");
        _monsterAnimator.ResetTrigger("JUMP");
    }
    float DistanceCheck()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        Debug.Log(distance);
        return distance;
    }
    void MonsWalk()
    {
        if (this._monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
            return;

        if(monsstate == MansState.walk)
            this.transform.Translate(Vector3.forward * mons[0].MoveSpeed * Time.deltaTime);
    }
    void SetWalk()
    {
        if (mons[0].PerceptionRange > DistanceCheck() && DistanceCheck() > 5.0)
        {
            mons[0].Perception = true;
            ResetAnimationParameters();
            monsstate = MansState.walk;
            MonsterAnimationControl();
        }
    }

    void MotionCheck()
    {
        if (mons[0].Perception == true)
            return;

        if (mons[0].PerceptionRange > DistanceCheck() && DistanceCheck() > 5.0f)
        {
            monsstate = MansState.Jump;
            MonsterAnimationControl();
        }
        else
            mons[0].Perception = false;
    }
    void SetAttack()
    {
        if (mons[0].Perception == false)
            return;

        if (DistanceCheck() <= 5.0f)
        {
            ResetAnimationParameters();
            monsstate = MansState.attack;
            MonsterAnimationControl();
        }
        else
        {
            Debug.Log("ff");
            SetWalk();

        }
            


    }
    // Update is called once per frame
    void Update()
    {
        MotionCheck();
       // MonsterAnimationControl();
        MonsWalk();
        SetAttack();


    }
}
