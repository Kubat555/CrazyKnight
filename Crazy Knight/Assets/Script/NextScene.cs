using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
   static public void Load(int i){
       SceneManager.LoadScene(i);
   } 

}
