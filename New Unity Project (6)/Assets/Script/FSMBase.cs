using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState                                                          //상태
{
    Idle,
    Move,
    Avoid,
    Attack1,
    Attack2,
    Attack3,
    Skill1,
    SMASH,
    Hit
}

public class FSMBase : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;


    public PlayerState PState;

    public bool isNewState;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }
    protected virtual void OnEnable()
    {
        PState = PlayerState.Idle;
        StartCoroutine(FSMMain());
    }

    IEnumerator FSMMain()
    {
        while(true)
        {
            isNewState = false;
            yield return StartCoroutine(PState.ToString());
        }

    }
    public void SetState(PlayerState newState)
    {
        isNewState = true;
        PState = newState;

        anim.SetInteger("state", (int)PState);
    }
    protected virtual IEnumerator Idle()
    {
        do
        {
            yield return null;
        } while (!isNewState);


    }
    protected virtual IEnumerator Move()
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
        
    }
}
