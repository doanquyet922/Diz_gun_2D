using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject parentPlayer;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (playerPrefab)
        {
            playerPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            GameObject player= Instantiate(playerPrefab,parentPlayer.transform.position,Quaternion.identity) as GameObject;
            
            player.transform.parent = parentPlayer.transform;
            
            //player.AddComponent<CharacterController2D>();
            
            Animator animator = player.GetComponentInChildren<Animator>();
            
           PlayerMovement  playerMovement = parentPlayer.GetComponent<PlayerMovement>();
            playerMovement.animator = animator;
            //player.transform.position = Vector3.zero;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
