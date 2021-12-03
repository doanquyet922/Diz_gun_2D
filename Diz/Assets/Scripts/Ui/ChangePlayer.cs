using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public static ChangePlayer ins;
    public Text coinText;
    int coin;
    int price;
    string namePlayer;
    public GameObject confirmUI;
    public Text contentText;
    public Button confirmButton;
    // Start is called before the first frame update
    private void Awake()
    {
        Ins();
        Debug.Log(Prefs.listPlayer);
        coin = Prefs.coin;
        coinText.text = coin.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Buy(string namePlayer1,int price1)
    {
        confirmUI.SetActive(true);
        price = price1;
        namePlayer = namePlayer1;
        //Debug.Log("name1:" + namePlayer1 + "price:" + price);
        if (namePlayer1.Equals("") || coin<price)
        {
            confirmButton.gameObject.SetActive(false);
        }
        else
        {
            confirmButton.gameObject.SetActive(true);
        }
        contentText.text = "Bạn có muốn mua nhân vật này với giá " + price + "vàng.";
    }
    public void Confirm()
    {
        coin -= price;
        Prefs.coin = coin;
        Prefs.listPlayer = Prefs.listPlayer + "," + namePlayer;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Cancel()
    {
        confirmUI.SetActive(false);
    }
    void Ins()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
}
