using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    float clickTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            Time.timeScale = 0.1F;
            Time.fixedDeltaTime = 0.7F * Time.timeScale;

    }
}
