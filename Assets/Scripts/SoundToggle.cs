using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    AudioSource audio;

    //Play the music
    bool playMusic;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool toggleChange;

    /*
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    */

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audio = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        //if(GameManager.GetInstance().bgSoundOn == true)
        playMusic = true;
        /*
        if (PlayerPrefs.GetInt("BGmusic") == 1)
        {
            
        }
        */
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        //if (playMusic == true && toggleChange == true)
        if (playMusic == true && toggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            audio.Play();
            //PlayerPrefs.SetInt("BGmusic", 1);
            //Ensure audio doesn’t play more than once
            toggleChange = false;
        }
        //Check if you just set the toggle to false
        if (playMusic == false && toggleChange == true)
        {
            //Stop the audio
            audio.Stop();
            //PlayerPrefs.SetInt("BGmusic", 0);
            //Ensure audio doesn’t play more than once
            toggleChange = false;
        }
    }

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        playMusic = GUI.Toggle(new Rect(10, 10, 100, 30), playMusic, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            toggleChange = true;
        }
    }

}