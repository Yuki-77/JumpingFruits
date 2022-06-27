using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject popUpMenuCanvas;
    public SpriteRenderer[] basePrefabSpriteRenderer;
    public GameObject starEffekt;
    public GameObject mainMenuCanvas;
    public GameObject popUpMenuButton; 
    public GameObject gameCanvas;
    public GameObject canvasMenuBarPanel;
    public GameObject yourScoreMenuBar;
    public GameObject popUpMenuBackground;
    public GameObject gameOverBackground;
    public GameObject brokenBaseRed, brokenBaseYellow, brokenBasePurple;
    public GameObject toggleBGSoundMainMenu;
    public GameObject toggleSoundEffMainMenu;
    public GameObject toggleBGSoundPopUpMenu;
    public GameObject toggleSoundEffPopUpMenu;
    public bool bgSoundOn = true;
    public bool soundEffectOn = true;

    public GameObject characterObject;
    static GameManager instance;
    public Character player;
    public PlayerMovement playerMovement;
    public GameObject mainCamera;
    public int currentScore = 0;
    public int highScore;
    public string chosenCharacter = "strawberry"; //"strawberry" / "pinapple" / "grape" (THEME)

    public float timeLeftDung;
    
    public float timeLeftLevel = 10.0f; //timer for 1 Level
    //public float level = 1;
    public int level = 1;
                      
    public float firstBaseYPosition = 0.0f; //the Y position of the base, which the character first jump on
    public float secondBaseYPosition = 0.0f; //the Y position of the base, which the character second jump on

    public bool gameOver = false;

    //set timer for creating dung, spring, worm, snail
    public float timeLeftCreateDung;
    public float timeLeftCreateSpring;
    public float timeLeftCreateWorm;
    public float timeLeftCreateSnail;
    public float timeLeftCreateMovingBase;

    private void Awake()
    {
        timeLeftCreateSpring = 50f * Time.deltaTime;
        timeLeftCreateDung = 300.0f * Time.deltaTime;
        timeLeftCreateWorm = 500.0f * Time.deltaTime;
        timeLeftCreateSnail = 800.0f * Time.deltaTime;
        timeLeftCreateMovingBase = 65f * Time.deltaTime;
        Time.timeScale = 0;
        instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        //timer -1
        timeLeftCreateSpring -= Time.deltaTime;
        timeLeftCreateDung -= Time.deltaTime;
        timeLeftCreateWorm -= Time.deltaTime;
        timeLeftCreateSnail -= Time.deltaTime;
        timeLeftCreateMovingBase -= Time.deltaTime;
        timeLeftLevel -= Time.deltaTime;
        
        if(timeLeftLevel <= 0) //level up after 10s
        {
            timeLeftLevel = 10.0f;
            level++;
        }

        if (gameOver)
        {
            gameCanvas.gameObject.GetComponent<AudioSource>().Stop();
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
}

