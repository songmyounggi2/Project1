using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeoutplay());
    }
    IEnumerator fadeoutplay()
    {
        Debug.Log("성공");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("sjadjrka");
        GameObject.Find("UI").transform.Find("MainScreen").gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
