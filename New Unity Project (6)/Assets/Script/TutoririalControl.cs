using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoririalControl : MonoBehaviour
{
    bool Tutorial_Move = false;
    bool Tutorial_Avoid = false;
    bool Tutorial_Attack = false;
    bool Tutorial_SkillAttack = false;
    bool Tutorial_Tab = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeoutplay());
    }

    IEnumerator fadeoutplay()
    {
        Tutorial_Move = true;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        transform.Find("Move").gameObject.SetActive(true);
    }
    IEnumerator avoid()
    {
        Tutorial_Avoid = true;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        transform.Find("Avoid").gameObject.SetActive(true);
    }
    IEnumerator Attack()
    {
        Tutorial_Attack = true;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        transform.Find("Attack").gameObject.SetActive(true);
    }
    IEnumerator Attack_skill()
    {
        
        yield return new WaitForSeconds(5.5f);
        Tutorial_SkillAttack = true;
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        transform.Find("Skill").gameObject.SetActive(true);
    }
    IEnumerator Tap()
    {
        Tutorial_Tab = true;
        yield return new WaitForSeconds(5.5f);
        Time.timeScale = 0.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        transform.Find("Tab").gameObject.SetActive(true);
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(5.5f);
        transform.Find("Fadeout").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            if (Tutorial_Move == false)
                return;
            transform.Find("Move").gameObject.SetActive(false);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Tutorial_Move = false;
            StartCoroutine(avoid());
        }
        if((Input.GetKey(KeyCode.Space)))
        {
            if (Tutorial_Avoid == false)
                return;
            transform.Find("Avoid").gameObject.SetActive(false);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Tutorial_Avoid = false;
            StartCoroutine(Attack());
        }
        if ((Input.GetMouseButtonDown(0)))
        {
            if (Tutorial_Attack == true)
            {
                transform.Find("Attack").gameObject.SetActive(false);
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Tutorial_Attack = false;
                StartCoroutine(Attack_skill());
            }
        }
        if (Input.anyKey)
        { 
            if (Tutorial_SkillAttack == true)
            {
                transform.Find("Skill").gameObject.SetActive(false);
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Tutorial_SkillAttack = false;
                StartCoroutine(Tap());
            }
        }
        if ((Input.GetKey(KeyCode.Tab)))
        {
            if (Tutorial_Tab == true)
            {
                transform.Find("Tab").gameObject.SetActive(false);
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Tutorial_Tab = false;
                StartCoroutine(End());
            }
        }
    }
}
