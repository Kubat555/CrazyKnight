using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume(){
        Time.timeScale = 1f;
    }
    public void Pause(){
        Time.timeScale = 0f;
    }
}
