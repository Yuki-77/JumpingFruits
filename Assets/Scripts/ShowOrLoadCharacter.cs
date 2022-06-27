using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrLoadCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("skipMainMenu") == 0)
        {
            return;
        }
        else
        {
            int selectedChar = PlayerPrefs.GetInt("character", 1);
            switch (selectedChar)
            {
                case 1:
                    GetComponent<MainMenu>().chooseStrawberry();
                    gameObject.SetActive(false);
                    GetComponent<MainMenu>().StartGame();
                    break;
                case 2:
                    GetComponent<MainMenu>().choosePineapple();
                    gameObject.SetActive(false);
                    GetComponent<MainMenu>().StartGame();
                    break;
                case 3:
                    GetComponent<MainMenu>().chooseGrape();
                    gameObject.SetActive(false);
                    GetComponent<MainMenu>().StartGame();
                    break;
            }
        }
        /*
        GameManager.GetInstance().level = 1;
        GameManager.GetInstance().timeLeftCreateSpring = 50f * Time.deltaTime;
        GameManager.GetInstance().timeLeftCreateDung = 300.0f * Time.deltaTime;
        GameManager.GetInstance().timeLeftCreateWorm = 500.0f * Time.deltaTime;
        GameManager.GetInstance().timeLeftCreateSnail = 800.0f * Time.deltaTime;
        GameManager.GetInstance().timeLeftCreateMovingBase = 65f * Time.deltaTime;
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
