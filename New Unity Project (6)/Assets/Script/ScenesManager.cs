using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using LitJson;

public class ScenesManager : MonoBehaviour
{
    JsonData UserData;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeoutplay());
    }
   
    IEnumerator fadeoutplay()
    {
       
        yield return new WaitForSeconds(2.5f);
        GameObject.Find("UI").transform.Find("MainScreen").gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
