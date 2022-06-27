using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;
    public int highScore;
    string highScoreKey = "HighScore";
    public GameObject strawberry, pineapple, grape; //initial state = deactive
    private string chosenCharacter; //"strawberry", "pineapple", "grape"
    public Character charStrawberry, charPineapple, charGrape;
    public PlayerMovement movementStrawberry, movementPineapple, movementGrape;
    public Sprite redBaseSprite, purpleBaseSprite, yellowBaseSprite;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        Debug.Log("highscore:" + highScore);
        highScoreText.text = "HIGH SCORE : " + highScore;
    }

    private void Update()
    {
        chosenCharacter = "pineapple";
    }

    public void StartGame()
    {
        if (chosenCharacter == "strawberry")
        {
            GameManager.GetInstance().characterObject = strawberry;
            Debug.Log("chosen : strawberry");
            strawberry.SetActive(true);
            GameManager.GetInstance().player = charStrawberry;
            GameManager.GetInstance().playerMovement = movementStrawberry;

            foreach (SpriteRenderer spriteRend in GameManager.GetInstance().basePrefabSpriteRenderer)
            {
                spriteRend.sprite = redBaseSprite;
            }
        }

        else if (chosenCharacter == "pineapple")
        {
            GameManager.GetInstance().characterObject = pineapple;
            Debug.Log("chosen : pineapple");
            pineapple.SetActive(true);
            GameManager.GetInstance().player = charPineapple;
            GameManager.GetInstance().playerMovement = movementPineapple;
            
            foreach (SpriteRenderer spriteRend in GameManager.GetInstance().basePrefabSpriteRenderer)
            {
                Debug.Log(spriteRend.sprite);
                spriteRend.sprite = yellowBaseSprite;
                Debug.Log(spriteRend.sprite);
            }
        }

        else if (chosenCharacter == "grape")
        {
            GameManager.GetInstance().characterObject = grape;
            Debug.Log("chosen : grape");
            grape.SetActive(true);
            GameManager.GetInstance().player = charGrape;
            GameManager.GetInstance().playerMovement = movementGrape;

            foreach (SpriteRenderer spriteRend in GameManager.GetInstance().basePrefabSpriteRenderer)
            {
                spriteRend.sprite = purpleBaseSprite;
            }
        }

            GameManager.GetInstance().mainMenuCanvas.SetActive(false);
            GameManager.GetInstance().gameCanvas.SetActive(true);
            Time.timeScale = 1;
    }
    
}
