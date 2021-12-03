using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditName : MonoBehaviour
{
    public Text nameText;
    public InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        nameInputField.text = Prefs.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Confirm()
    {
        gameObject.SetActive(false);
        Prefs.name = nameInputField.text;
        nameText.text = Prefs.name;
    }
    public void Exit()
    {
        nameInputField.text = Prefs.name;
        gameObject.SetActive(false);
    }
}
