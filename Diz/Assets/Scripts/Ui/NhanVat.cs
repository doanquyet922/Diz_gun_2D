using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NhanVat : MonoBehaviour
{
    public GameObject character;
    public Button saveButton;
    public Button buyButton;
    public int price=50;
    // Start is called before the first frame update
    void Start()
    {
        string tmp = Prefs.listPlayer;
        if (tmp.Contains(character.name))
        {
            saveButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            saveButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Buy()
    {
        ChangePlayer.ins.Buy(character.name,price);
        //Debug.Log("name1:" + character.name + "price:" + price);
    }
    
    public void Save()
    {
        Prefs.player = character.name;
        SceneManager.LoadScene("MenuScenes");
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuScenes");
    }
   
}
