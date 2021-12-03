using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{

    public static string player
    {
        set
        {
            if (PlayerPrefs.GetString("Player", "Player4P") != value)
            {
                PlayerPrefs.SetString("Player", value);
            }
        }
        get => PlayerPrefs.GetString("Player", "Player4P");
    }
    public static string name
    {
        set
        {
            if (PlayerPrefs.GetString("Name", "Player") != value)
            {
                PlayerPrefs.SetString("Name", value);
            }
        }
        get => PlayerPrefs.GetString("Name", "Player");
    }
    public static int coin
    {
        set
        {
            if (PlayerPrefs.GetInt("Coin",0) != value)
            {
                PlayerPrefs.SetInt("Coin", value);
            }
        }
        get => PlayerPrefs.GetInt("Coin", 0);
    }
    public static void bestTime(string map,double time)
    {
        //PlayerPrefs.SetFloat(map, (float)time);
        if (PlayerPrefs.GetFloat(map, 99999999f) > (float)time)
        {
            PlayerPrefs.SetFloat(map, (float)time);
        }
    }
    public static double bestTime(string map)
    {
        
         return (double) PlayerPrefs.GetFloat(map, 0f);
        
    }
    public static string listPlayer
    {
        set
        {
            if (PlayerPrefs.GetString("listPlayer", "Player4P") != value)
            {
                PlayerPrefs.SetString("listPlayer", value);
            }
        }
        get => PlayerPrefs.GetString("listPlayer", "Player4P");
    }
    public static int halfHeal
    {
        set
        {
            if (PlayerPrefs.GetInt("HalfHeal", 0) != value)
            {
                PlayerPrefs.SetInt("HalfHeal", value);
            }
        }
        get => PlayerPrefs.GetInt("HalfHeal", 0);
    }
    public static int fullHeal
    {
        set
        {
            if (PlayerPrefs.GetInt("FullHeal", 0) != value)
            {
                PlayerPrefs.SetInt("FullHeal", value);
            }
        }
        get => PlayerPrefs.GetInt("FullHeal", 0);
    }
    public static int boom
    {
        set
        {
            if (PlayerPrefs.GetInt("Boom", 0) != value)
            {
                PlayerPrefs.SetInt("Boom", value);
            }
        }
        get => PlayerPrefs.GetInt("Boom", 0);
    }
}
