using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int priceHalfHeal=1;
    public int priceFullHeal=1;
    public int priceBoom=1;
    public InputField halfHealInput;
    
    public InputField fullHealInput;
    public InputField boomInput;

    public Text priceText;

    int halfHeal;
    int fullHeal;
    int boom;
    int price;
    // Start is called before the first frame update
    void Start()
    {
        halfHeal = 0;
        fullHeal = 0;
        boom = 0;
        price = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (int.TryParse(halfHealInput.text.ToString(), out halfHeal)==false)
        {
            halfHeal = 0;
        }
        if(int.TryParse(fullHealInput.text.ToString(), out fullHeal)==false)
        {
            fullHeal = 0;
        }
        if (int.TryParse(boomInput.text.ToString(), out boom) == false)
        {
            boom = 0;
        }

        price = halfHeal * priceHalfHeal + fullHeal * priceFullHeal+ boom*priceBoom;
        priceText.text ="Giá:"+ price.ToString();

    }
    public void ReduceHalfHeal ()
    {
        if (halfHeal > 0)
        {
            halfHeal--;
            halfHealInput.text = halfHeal.ToString();
        }
        
        
    }
    public void ReduceFullHeal()
    {
        if (fullHeal > 0)
        {
            fullHeal--;
            fullHealInput.text = fullHeal.ToString();
        }


    }
    public void ReduceBoom()
    {
        if (boom > 0)
        {
            boom--;
            boomInput.text = boom.ToString();
        }


    }
    public void Submit()
    {
        int coin = Prefs.coin;
        coin -= price;
        Prefs.coin = coin;
        Prefs.halfHeal =Prefs.halfHeal+ halfHeal;
        Prefs.fullHeal =Prefs.fullHeal+ fullHeal;
        Prefs.boom =Prefs.boom+ boom;
        gameObject.SetActive(false);
    }
    public void CounttingHalfHeal()
    {
        halfHeal++;
        halfHealInput.text = halfHeal.ToString();
        
    }
    public void CounttingFullHeal()
    {
        fullHeal++;
        fullHealInput.text = fullHeal.ToString();
        
    }
    public void CounttingBoom()
    {
        boom++;
        boomInput.text = boom.ToString();

    }
    public void Cancel()
    {
        gameObject.SetActive(false);
    }
    public void ShowShop()
    {
        gameObject.SetActive(true);
    }
}
