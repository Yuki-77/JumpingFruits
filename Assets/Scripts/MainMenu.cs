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
    public GameObject popupMenuButtonStrawberry, popupMenuButtonPineapple, popupMenuButtonGrape;
    public GameObject redStarEffect, greenStarEffect, purpleStarEffect;
    private string chosenCharacter; //"strawberry", "pineapple", "grape"
    public Character charStrawberry, charPineapple, charGrape;
    public PlayerMovement movementStrawberry, movementPineapple, movementGrape;
    public Sprite redBaseSprite, purpleBaseSprite, yellowBaseSprite;
    private List<string> characters;
    


    void Start()
    {
        gameObject.GetComponent<SoundOnOff>().ChangeStateBGMusic(bool.Parse(PlayerPrefs.GetString("BGmusic", "false")));
        gameObject.GetComponent<SoundOnOff>().ChangeStateSoundEffect(bool.Parse(PlayerPrefs.GetString("SoundEffect", "false")));
        chosenCharacter = GameManager.GetInstance().chosenCharacter;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "HIGH SCORE : " + highScore;
        characters = new List<string> { "strawberry", "pineapple", "grape" };
    }

    private void Update()
    {

    }

    //Button onClick()
    public void chooseStrawberry()
    {
        chosenCharacter = "strawberry";
        PlayerPrefs.SetInt("character", 1);
    }

    public void choosePineapple()
    {
        chosenCharacter = "pineapple";
        PlayerPrefs.SetInt("character", 2);
    }

    public void chooseGrape()
    {
        chosenCharacter = "grape";
        PlayerPrefs.SetInt("character", 3);
    }

    public void ShowHighScore()
    {
        GameManager.GetInstance().highScoreCanvas.SetActive(true);
    }

    public void StartGame()
    {
        GameManager.GetInstance().level = 1;
        GameManager.GetInstance().timeLeftCreateSpring = 5.0f;
        GameManager.GetInstance().timeLeftCreateDung = 10.0f;
        GameManager.GetInstance().timeLeftCreateWorm = 25.0f;
        GameManager.GetInstance().timeLeftCreateSnail = 30.0f;
        GameManager.GetInstance().timeLeftCreateMovingBase = 6.5f;
        GameManager.GetInstance().timeLeftLevel = 9.0f;

        PlayerPrefs.SetInt("skipMainMenu", 0);

        //change colors and sprites for each theme
        if (chosenCharacter == "strawberry")
        {
            popupMenuButtonStrawberry.SetActive(true);
            GameManager.GetInstance().starEffekt = redStarEffect;
            Color strawberryColor = new Color32(229, 19, 97, 255);
            Color strawberryBackgroundColor = new Color32(77, 10, 26, 223);
            PlayerPrefs.SetInt("character", 1);
            strawberry.SetActive(true);
            GameManager.GetInstance().characterObject = strawberry;
            strawberry.SetActive(true);
            GameManager.GetInstance().player = charStrawberry;
            GameManager.GetInstance().playerMovement = movementStrawberry;
            GameManager.GetInstance().brokenBaseRed.SetActive(true);

            //change color of menu bar and score
            GameManager.GetInstance().canvasMenuBarPanel.GetComponent<Image>().color = strawberryColor;
            GameManager.GetInstance().yourScoreMenuBar.GetComponent<Text>().color = strawberryColor;

            //change background color of pop up menu and game over canvas
            GameManager.GetInstance().popUpMenuBackground.GetComponent<Image>().color = strawberryBackgroundColor;
            GameManager.GetInstance().gameOverBackground.GetComponent<Image>().color = strawberryBackgroundColor;

            foreach (SpriteRenderer spriteRend in GameManager.GetInstance().basePrefabSpriteRenderer)
            {
                spriteRend.sprite = redBaseSprite;
            }
        }

        else if (chosenCharacter == "pineapple")
        {
            popupMenuButtonPineapple.SetActive(true);
            GameManager.GetInstance().starEffekt = greenStarEffect;
            Color pineappleColor = new Color32(243, 180, 77, 255);
            Color pineappleBackgroundColor = new Color32(97, 79, 37, 223);
            PlayerPrefs.SetInt("character", 2);
            pineapple.SetActive(true);
            GameManager.GetInstance().characterObject = pineapple;
            pineapple.SetActive(true);
            GameManager.GetInstance().player = charPineapple;
            GameManager.GetInstance().playerMovement = movementPineapple;
            GameManager.GetInstance().brokenBaseYellow.SetActive(true);

            //change color of menu bar and score
            GameManager.GetInstance().canvasMenuBarPanel.GetComponent<Image>().color = pineappleColor;
            GameManager.GetInstance().yourScoreMenuBar.GetComponent<Text>().color = pineappleColor;

            //change background color of pop up menu and game over canvas
            GameManager.GetInstance().popUpMenuBackground.GetComponent<Image>().color = pineappleBackgroundColor;
            GameManager.GetInstance().gameOverBackground.GetComponent<Image>().color = pineappleBackgroundColor;
            
            foreach (SpriteRenderer spriteRend in GameManager.GetInstance().basePrefabSpriteRenderer)
            {
                spriteRend.sprite = yellowBaseSprite;
            }
        }

        else if (chosenCharacter == "grape")
        {
            popupMenuButtonGrape.SetActive(true);
            GameManager.GetInstance().starEffekt = purpleStarEffect;
            Color grapeColor = new Color32(146, 89, 187, 255); //Color32(121, 66, 161, 255)
            Color grapeBackgroundColor = new Color32(55, 25, 68, 223);
            PlayerPrefs.SetInt("character", 3);
            grape.SetActive(true);
            GameManager.GetInstance().characterObject = grape;
            grape.SetActive(true);
            GameManager.GetInstance().player = charGrape;
            GameManager.GetInstance().playerMovement = movementGrape;
            GameManager.GetInstance().brokenBasePurple.SetActive(true);

            //change color of menu bar and score
            GameManager.GetInstance().canvasMenuBarPanel.GetComponent<Image>().color = grapeColor;
            GameManager.GetInstance().yourScoreMenuBar.GetComponent<Text>().color = grapeColor;

            //change background color of pop up menu and game over canvas
            GameManager.GetInstance().popUpMenuBackground.GetComponent<Image>().color = grapeBackgroundColor;
            GameManager.GetInstance().gameOverBackground.GetComponent<Image>().color = grapeBackgroundColor;

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
