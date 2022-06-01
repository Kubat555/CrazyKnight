using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsCoun : MonoBehaviour
{

    public Text kills;

    // Update is called once per frame
    void Update()
    {
        kills.text = Player.kills.ToString();
    }
}
