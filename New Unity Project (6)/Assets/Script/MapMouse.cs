using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapMouse : MonoBehaviour
{
    
    Vector3 monsterIconSclse;
    public GameObject monsterIcon;

    // Start is called before the first frame update
    void Start()
    { 
        monsterIconSclse = new Vector3(1, 1, 1);
    }

    public void MapMouseHover()
    {
        monsterIconSclse = new Vector3(1.5f, 1.5f, 1f);
    }
    public void MapMouseUnHover()
    {
        monsterIconSclse = new Vector3(1.0f, 1.0f, 1f);
    }
    public void MapMouseClick()
    {
        //SceneManager.LoadScene("Tutorial");
    }
    // Update is called once per frame
    void Update()
    {
        monsterIcon.transform.localScale = monsterIconSclse;
    }
}
