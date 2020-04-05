using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState                                                          //상태
{
    Idle,
    Move,
    AVOID,
    ATTACK1,
    ATTACK2,
    ATTACK3,
    SMASH,
    HIT
}

public class FSMBase : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;


    public PlayerState PHState;

    public bool isNewState;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }
    protected virtual void OnEnable()
    {
        PHState = PlayerState.Idle;
        StartCoroutine(FSMMain());
    }

    IEnumerator FSMMain()
    {
        while(true)
        {
            isNewState = false;
            yield return StartCoroutine(PHState.ToString());
        }

    }
    public void SetState(PlayerState newState)
    {
        isNewState = true;
        PHState = newState;

        anim.SetInteger("state", (int)PHState);
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
            if(Input.GetKeyUp(KeyCode.A))
                SetState(PlayerState.Idle);
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
