using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Bullets> bullets = new List<Bullets>();
    public int Bullet = 0;
    public int Rocket = 0;
    public int PlasmaBlue = 0;
    public int PlasmaGreen = 0;
    public int PlasmaPurple = 0;
    public int PlasmaRed = 0;
    public int PlasmaYellow = 0;
    public static GameManager ins;

    public Image avatar;
    public GameObject parentPlayer;

    public Transform startPoint;
    PlayerMovement playerMovement;
     bool GameIsPause;
      bool GameIsOver;
      bool GameIsWin;
    public GameObject PauseMenuUI;
    public GameObject SettingMenuUI;
    public GameObject GameOverUI;
    public GameObject GameWinUI;
    public int coinWin=10;
    public Text coinWinText;

    public Text  FullHealingText;
    public Text  HalfHealingText;
    int m_FullHeal;
    int m_HalfHeal;
    public Text timeText;
    double time;

    public Text coinText;
    int m_coin;
    bool drag = false;
    public bool GameIsPause1 { get => GameIsPause; set => GameIsPause = value; }
    public bool GameIsOver1 { get => GameIsOver; set => GameIsOver = value; }
    public bool GameIsWin1 { get => GameIsWin; set => GameIsWin = value; }

    void SetDamageBullet()
    {
        bullets.Add(new Bullets("Bullet", Bullet));
        bullets.Add(new Bullets("Rocket", Rocket));
        bullets.Add(new Bullets("PlasmaBlue", PlasmaBlue));
        bullets.Add(new Bullets("PlasmaGreen", PlasmaGreen));
        bullets.Add(new Bullets("PlasmaPurple", PlasmaPurple));
        bullets.Add(new Bullets("PlasmaRed", PlasmaRed));
        bullets.Add(new Bullets("PlasmaYellow", PlasmaYellow));
    }

    private void Awake()
    {
        
        Ins();
        SetDamageBullet();
        time = 0;
        m_coin = Prefs.coin;
        coinText.text = m_coin.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(CountingTime());
        m_FullHeal = Prefs.fullHeal;
        m_HalfHeal = Prefs.halfHeal;
        FullHealingText.text = m_FullHeal + "x";
        HalfHealingText.text = m_HalfHeal + "x";
        parentPlayer = (GameObject)LoadPrefabFromFile(Prefs.player);
        avatar.sprite = Resources.Load<Sprite>("Avatar/" + Prefs.player);
        playerMovement = parentPlayer.GetComponent<PlayerMovement>();
        if (parentPlayer)
        {
            parentPlayer = Instantiate(parentPlayer, startPoint.position, Quaternion.identity);
            //PhotonNetwork.Instantiate(parentPlayer.name, startPoint.position, Quaternion.identity, 0);


        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthEnemy[] enemys = GameObject.FindObjectsOfType<HealthEnemy>();
        if (enemys.Length <= 0 && GameIsWin==false)
        {
            Prefs.bestTime(gameObject.scene.name, time);
            Prefs.coin = Prefs.coin + coinWin;
            coinWinText.text = "+" + coinWin.ToString();
            GameWin();
        }
    }
    public void CounttingCoin()
    {
        m_coin++;
        Prefs.coin = m_coin;
        coinText.text = Prefs.coin.ToString();
    }
    public void DecreaseCoin(int coin)
    {
       
    }
    public void UsingFullHeal()
    {
        if (m_FullHeal>0)
        {
            m_FullHeal--;
            Prefs.fullHeal = m_FullHeal;
            FullHealingText.text = Prefs.fullHeal + "x";
            HealthPlayer he = parentPlayer.GetComponent<HealthPlayer>();
            he.AddHeal(100);
        }
        
    }
    public void UsingHalfHeal()
    {
        if (m_HalfHeal > 0)
        {
            m_HalfHeal--;
            Prefs.halfHeal = m_HalfHeal;
            HalfHealingText.text = Prefs.halfHeal + "x";
            HealthPlayer he = parentPlayer.GetComponent<HealthPlayer>();
            he.AddHeal(50);
        }
        
    }
    public void CountingFullHeal()
    {
        m_FullHeal++;
        FullHealingText.text = m_FullHeal + "x";
    }
    public void CountingHalfHeal()
    {
        m_HalfHeal++;
        HalfHealingText.text = m_HalfHeal + "x";
    }
    IEnumerator CountingTime()
    {
        if (GameIsOver1 == false && GameIsPause1==false && GameIsWin1==false)
        {
            yield return new WaitForSeconds(1);
            time += 1;
            TimeSpan t = TimeSpan.FromSeconds(time);
            string str = t.ToString(@"mm\:ss");       
            timeText.text = str ;
            StartCoroutine(CountingTime());
        }
        
    }
    void Ins()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    private UnityEngine.Object LoadPrefabFromFile(string filename)
    {
        Debug.Log("Trying to load LevelPrefab from file (" + filename + ")...");
        var loadedObject = Resources.Load("Prefab/" + filename);
        if (loadedObject == null)
        {
            throw new FileNotFoundException("...no file found - please check the configuration");
        }
        return loadedObject;
    }


    public GameObject GetPlayerPrefab()
    {
        return parentPlayer;
    }
    public void GameWin()
    {
        
        GameIsWin1 = true;
        
        GameWinUI.SetActive(true);
        
    }
    public void Pause()
    {
        if (PauseMenuUI)
            PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause1 = true;
    }
    public void Resume()
    {
        
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause1 = false;
    }
    public void Setting()
    {
        SettingMenuUI.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator GameOver()
    {
       
        GameIsOver1 = true;
        yield return new WaitForSeconds(2);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ShowGameOver()
    {
        StartCoroutine(GameOver());
        //Time.timeScale = 0f;
        //GameIsOver = true;
        
        //GameOverUI.SetActive(true);
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next()
    {
        Time.timeScale = 1f;
        if (SceneManager.sceneCountInBuildSettings > (SceneManager.GetActiveScene().buildIndex + 1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void NextToMap3Man2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map3Disidon2");
    }
    public void Drag()
    {
        drag = true;
    }
    public void Drop()
    {
        drag = false;
    }
    public bool isDrag()
    {
        return drag;
    }
}
