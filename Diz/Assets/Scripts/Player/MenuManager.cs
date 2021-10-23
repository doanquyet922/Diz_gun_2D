using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    

    
    public void bStart()
    {
        SceneManager.LoadScene("MenuScenes");

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ChangePlayer()
    {
        SceneManager.LoadScene("PlayerEditer");

    }
}
