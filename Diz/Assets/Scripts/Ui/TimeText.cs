using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public Text timeText;
    bool set=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.ins.GameIsWin1 && set==false)
        {
            set = true;
            timeText.text = GameManager.ins.timeText.text;
            
        }
        
    }
}
