using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        GameManager.GetInstance().toggleBGSoundMainMenu.GetComponent<Toggle>().onValueChanged.AddListener(ChangeStateBGMusic);
        GameManager.GetInstance().toggleBGSoundPopUpMenu.GetComponent<Toggle>().onValueChanged.AddListener(ChangeStateBGMusic);
        GameManager.GetInstance().toggleSoundEffMainMenu.GetComponent<Toggle>().onValueChanged.AddListener(ChangeStateSoundEffect);
        GameManager.GetInstance().toggleSoundEffPopUpMenu.GetComponent<Toggle>().onValueChanged.AddListener(ChangeStateSoundEffect);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeStateBGMusic(bool on)
    {
        GameManager.GetInstance().toggleBGSoundMainMenu.GetComponent<Toggle>().isOn = on;
        GameManager.GetInstance().toggleBGSoundPopUpMenu.GetComponent<Toggle>().isOn = on;
        GameManager.GetInstance().gameCanvas.GetComponent<AudioSource>().mute = on;
        GameManager.GetInstance().mainMenuCanvas.GetComponent<AudioSource>().mute = on;
        GameManager.GetInstance().gameOverCanvas.GetComponents<AudioSource>()[0].mute = on;
        GameManager.GetInstance().bgSoundOn = !on;
        PlayerPrefs.SetString("BGmusic", (on).ToString());
    }

    public void ChangeStateSoundEffect(bool on)
    {
        GameManager.GetInstance().toggleSoundEffMainMenu.GetComponent<Toggle>().isOn = on;
        GameManager.GetInstance().toggleSoundEffPopUpMenu.GetComponent<Toggle>().isOn = on;
        GameManager.GetInstance().gameOverCanvas.GetComponents<AudioSource>()[1].mute = on;
        GameManager.GetInstance().soundEffectOn = !on;
        PlayerPrefs.SetString("SoundEffect", (on).ToString());
    }
}
