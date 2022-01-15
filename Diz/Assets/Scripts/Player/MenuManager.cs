using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : Photon.MonoBehaviour
{
    [SerializeField] private string versionName = "1.0";
    [SerializeField] private InputField createGameInput;
    [SerializeField] private InputField joinGameInput;
    [SerializeField] private Text nameText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text halfHealText;
    [SerializeField] private Text fullHealText;
    [SerializeField] private Text BoomText;
    [SerializeField] private GameObject MapCanvas;
    public Transform playerPoint;
    string nameSceneMap;
    GameObject player;
    Data data;
    int coin;
    int halfHeal;
    int fullHeal;
    int booms;
    public GameObject editNamepanel;
    private void Awake()
    {
       
        data = FindObjectOfType<Data>();
        DontDestroyOnLoad(data.gameObject);
    }

    private void Start()
    {
        nameText.text = Prefs.name;
        string name = Prefs.player.Substring(0, 7);

        player = (GameObject)LoadPrefabFromFile(name);
        if (player && playerPoint)
        {

            GameObject p = Instantiate(player, playerPoint.position, playerPoint.rotation);
            p.transform.localScale = playerPoint.localScale;
        }
    }
    private void FixedUpdate()
    {
        coin = Prefs.coin;
        coinText.text = coin.ToString();
        halfHeal = Prefs.halfHeal;
        fullHeal = Prefs.fullHeal;
        booms = Prefs.boom;
        halfHealText.text = "x" + halfHeal.ToString();
        fullHealText.text = "x" + fullHeal.ToString();
        BoomText.text = "x" + booms.ToString();
    }
    //public void OnConnectedToMaster()
    //{
    //    PhotonNetwork.JoinLobby(TypedLobby.Default);
    //    Debug.Log("Connected");
    //}
    //public void CreateGame()
    //{
    //    if (createGameInput.text.Length <= 0)
    //    {
    //        Debug.Log("Chưa đặt tên phòng");
    //    }
    //    else
    //    {
    //        MapCanvas.SetActive(true);
    //    }

        
        
    //}
    //public void ClickMap1()
    //{
    //    PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { maxPlayers = 2 }, null);
    //    PhotonNetwork.playerName = nameText.text;
    //    data.SetCreateRoom(true);
    //    data.SetNameSceneMap("GameScene");
    //}
    //public void ClickMap2()
    //{
    //    PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { maxPlayers = 2 }, null);
    //    PhotonNetwork.playerName = nameText.text;
    //    data.SetCreateRoom(true);
    //    data.SetNameSceneMap("Map2MonsidonScene");
    //}
    //public void JoinGame()
    //{   
    //    if (PhotonNetwork.JoinRoom(joinGameInput.text))
    //    {
    //        PhotonNetwork.playerName = nameText.text;

    //        data.SetCreateRoom(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Not name rôm");
    //    }
        
        

    //}

    //public void OnJoinedRoom()
    //{
    //    PhotonNetwork.LoadLevel("RoomGame");
    //}

    
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ChangePlayer()
    {
        SceneManager.LoadScene("ChangePlayerScene");

    }
    private UnityEngine.Object LoadPrefabFromFile(string filename)
    {
        //Debug.Log("Trying to load LevelPrefab from file (" + filename + ")...");
        var loadedObject = Resources.Load("Prefab/" + filename);
        if (loadedObject == null)
        {
            throw new FileNotFoundException("...no file found - please check the configuration");
        }
        return loadedObject;
    }
    public void BackToScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void EditName()
    {
        
        editNamepanel.SetActive(true);
    }
}
