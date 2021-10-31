using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
        
    }

    public bool HasFlameSword { get; set; }

    public bool HasBootsofFlight { get; set; }

    public bool HasKeyToCastle { get; set; }

    public Player Player { get; private set; }

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No Audio Manager found in scene");
        }

    }

    private AudioManager audioManager;

    

    private void Start()
    {

    
    }

    public void DeathPlayer()
    {
        audioManager.PlaySound("DeathPlayer");
    }

    public void WalkPlayer()
    {
        audioManager.PlaySound("WalkPlayer");
    }

    public void JumpPlayer()
    {
        audioManager.PlaySound("JumpPlayer");
    }

    public void AttackPlayer()
    {
        audioManager.PlaySound("AttackPlayer");
    }

    public void SpiderSound()
    {
        audioManager.PlaySound("Spider");
    }

    public void SkeletonSound()
    {
        audioManager.PlaySound("Skeleton");
    }

    public void WalkGiant()
    {
        audioManager.PlaySound("WalkMossGiant");
    }

    public void DeathMonster()
    {
        audioManager.PlaySound("DeathMonster");
    }



}
