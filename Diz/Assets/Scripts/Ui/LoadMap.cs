using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadMap : MonoBehaviour
{
    public string nameScene;
    public Text bestTimeText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nameScene+"-"+Prefs.bestTime(nameScene));
        
        double time = Prefs.bestTime(nameScene);
        TimeSpan t = TimeSpan.FromSeconds(time);
        string str = t.ToString(@"mm\:ss");
        bestTimeText.text ="Best Time: "+ str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        SceneManager.LoadScene(nameScene);
    }
}
