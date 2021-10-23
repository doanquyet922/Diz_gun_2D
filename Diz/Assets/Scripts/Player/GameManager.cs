using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public GameObject playerPrefab;
    public GameObject parentPlayer;

    public List<Bullets> bullets = new List<Bullets>();
    public int Bullet = 0;
    public int Rocket = 0;
    public int PlasmaBlue = 0;
    public int PlasmaGreen = 0;
    public int PlasmaPurple = 0;
    public int PlasmaRed = 0;
    public int PlasmaYellow = 0;

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
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //if (playerPrefab)
        //{
        //    playerPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        //    GameObject player= Instantiate(playerPrefab,parentPlayer.transform.position,Quaternion.identity) as GameObject;
            
        //    player.transform.parent = parentPlayer.transform;
            
        //    //player.AddComponent<CharacterController2D>();
            
        //    Animator animator = player.GetComponentInChildren<Animator>();
            
        //   PlayerMovement  playerMovement = parentPlayer.GetComponent<PlayerMovement>();
        //    playerMovement.animator = animator;
        //    //player.transform.position = Vector3.zero;


        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Ins()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    
}
