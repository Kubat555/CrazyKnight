using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    private Text HP;
    void Start()
    {
        HP = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "" + enemyScript.liveCount;
    }
}
