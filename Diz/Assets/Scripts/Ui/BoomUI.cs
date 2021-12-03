using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomUI : MonoBehaviour
{
    public double timeBoom;
    public double m_CurrentTimeBoom;
    public Text timeBoomText;
    public Text BoomsText;
    public bool useBoom = false;
    GameObject player;
     int m_booms;
    // Start is called before the first frame update
    void Start()
    {
        m_booms = Prefs.boom;
        BoomsText.text = m_booms.ToString()+ "x" ;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_CurrentTimeBoom <= 0)
        {
            timeBoomText.gameObject.SetActive(false);
        }
    }
    
    public void ReduceTime()
    {
        
            m_booms--;
            Prefs.boom = m_booms;
            BoomsText.text = Prefs.boom.ToString()+ "x" ;
            m_CurrentTimeBoom = timeBoom;
            timeBoomText.text = m_CurrentTimeBoom.ToString();
            timeBoomText.gameObject.SetActive(true);
            StartCoroutine(IE_ReduceTime());
        
        
    }
   public IEnumerator IE_ReduceTime()
    {
        yield return new WaitForSeconds(1);
        m_CurrentTimeBoom--;
        //TimeSpan t = TimeSpan.FromSeconds(m_CurrentTimeBoom);
        //string str = t.ToString(@"mm\:ss");
        timeBoomText.text = m_CurrentTimeBoom.ToString();
        if(m_CurrentTimeBoom>0)
        StartCoroutine(IE_ReduceTime());
    }
    public void UseBoom()
    {
        if (useBoom == false)
        {
            useBoom = true;
            player = GameManager.ins.parentPlayer;
            GameObject characterBoom = player.transform.GetChild(player.transform.childCount - 1).gameObject;
            GameObject characterGun = player.transform.GetChild(player.transform.childCount - 2).gameObject;
            characterBoom.SetActive(true);
            characterGun.SetActive(false);
        }
        else
        {
            useBoom = false;
            player = GameManager.ins.parentPlayer;
            GameObject characterBoom = player.transform.GetChild(player.transform.childCount - 1).gameObject;
            GameObject characterGun = player.transform.GetChild(player.transform.childCount - 2).gameObject;
            characterBoom.SetActive(false);
            characterGun.SetActive(true);
        }
    }

}
