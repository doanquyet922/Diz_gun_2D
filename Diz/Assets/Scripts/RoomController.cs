using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController :MonoBehaviour
{
    public PhotonView photonView;
    Data data;
    public Transform playerPoint1;
    public Transform playerPoint2;
    public Text pingText;
    public Text Player1Text;
    public Text Player2Text;
    public Button playButton;

    bool isPlaying = false;
    string nameSceneMap="";
    // Start is called before the first frame update

    void Start()
    {
        
        Player2Text.gameObject.SetActive(false);
        string name = Prefs.player.Substring(0, 7);
        GameObject player = (GameObject)Resources.Load("Prefab/" + name);
        player.transform.localScale = new Vector3(1, 1, 1);
        data = FindObjectOfType<Data>();
        nameSceneMap = data.GetNameSceneMap();
        if (data.getCreateRoom())
        {  
            GameObject player1 = PhotonNetwork.Instantiate(player.name,playerPoint1.position,Quaternion.identity,0);
            
            
                //photonView.RPC("NamePlayer1", PhotonTargets.Others);
            
            
        }
        else
        {
            playButton.gameObject.SetActive(false);
            //GameObject player = (GameObject)Resources.Load("Prefab/" + Prefs.player);
            //player.transform.localScale = new Vector3(-1, 1, 1);
            GameObject player2=  PhotonNetwork.Instantiate(player.name, playerPoint2.position, Quaternion.identity, 0);
            
                //photonView.RPC("NamePlayer2", PhotonTargets.Others);
               
            
        }
    }
    
    [PunRPC]
    public void NamePlayer1()
    {
        Player1Text.text = PhotonNetwork.playerName;
        Player1Text.color = Color.cyan;
    }
    [PunRPC]
    public void NamePlayer2()
    {
        
        Player2Text.gameObject.SetActive(true);
        Player2Text.text = PhotonNetwork.playerName;
        Player2Text.color = Color.red;
    }
    
    // Update is called once per frame
    void Update()
    {
        pingText.text = "ms:" + PhotonNetwork.GetPing();
       
    }
    public void Play()
    {
        photonView.RPC("SendPlay", PhotonTargets.All, true);
    }
    public void Back()
    {
        SceneManager.LoadScene("MenuScenes");
    }
    [PunRPC]
    void SendPlay(bool play)
    {
        isPlaying = play;
        if (isPlaying==true)
        {
            PhotonNetwork.LoadLevel(nameSceneMap);
        }
    }
}
