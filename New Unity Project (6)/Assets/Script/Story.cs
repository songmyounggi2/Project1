using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    float clickTime = 0f;
    Text storytext;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void StoryScript()
    {
        
    }
    void SkipStory()
    {
         SceneManager.LoadScene("Pub");
    }
    //IEnumerator storyTime()
    //{


    //   // return 
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipStory();
        }

    }
}
