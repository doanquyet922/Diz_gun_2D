using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEditerManager : MonoBehaviour
{
    public GameObject CyberpunkHeroesEditer;
    public GameObject MilitaryHeroesEditer;

    public void CyberpunkHeroes()
    {
        if(MilitaryHeroesEditer && CyberpunkHeroesEditer)
        {
            MilitaryHeroesEditer.SetActive(false);
            CyberpunkHeroesEditer.SetActive(true);
        }
      
    }
    public void MilitaryHeroes()
    {
        if (MilitaryHeroesEditer && CyberpunkHeroesEditer)
        {
            MilitaryHeroesEditer.SetActive(true);
            CyberpunkHeroesEditer.SetActive(false);
        }

    }
}
