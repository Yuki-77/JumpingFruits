using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
        }

        else if (!GameManager.GetInstance().soundEffectOn)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
        }
    }
}
