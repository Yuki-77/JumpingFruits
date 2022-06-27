using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBarObject : MonoBehaviour
{
    private float resetPosition = 12.0f; // reset the y value of base
    AudioSource audio;
    public GameObject brokenBarPrefabPink, brokenBarPrefabYellow, brokenBarPrefabPurple;
    float randomX = 0.0f;



    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
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

        float level = GameManager.GetInstance().level;
        if (transform.position.y < GameManager.GetInstance().mainCamera.transform.position.y - 5.2f)
        {
            ResetPosition();
        }

    }
    //reset the position of base
    void ResetPosition()
    {
        //choose random x value of bases
        if (transform.position.x > 0.0f && transform.position.x <= 6.0f)
        {
            randomX = Random.Range(-2.0f, 0.0f);

        }
        else if (transform.position.x <= 0.0f && transform.position.x >= -6.0f)
        {
            randomX = Random.Range(0.0f, 2.0f);
        }
        transform.position = transform.position + new Vector3(randomX, resetPosition, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0) //when character meets collider from y>0 (von unten nach oben)
            return;

        //when character meets collider from y<0 (von oben nach unten)
        //GameManager.GetInstance().newBrokenBar = true;
        Rigidbody2D[] rbds = GetComponentsInChildren<Rigidbody2D>(); //2 children (members) in Array: barBrokenLeft and barBrokenright
        for (int i = 0; i < rbds.Length; ++i)
        {
            //Rigidbody2D is simulated (bar falls down) when it meets collision
            //and AddRandomForce enable
            rbds[i].simulated = true;
            rbds[i].gameObject.GetComponent<AddRandomForce>().enabled = true;
        }

        if (!audio.isPlaying)
            audio.Play();
        GetComponent<Collider2D>().enabled = false; //delete collider, if not the character can always jump on colider
        GameManager.GetInstance().brokenBarPosition = transform.position;
        Destroy(gameObject, 2.0f); //destroy BrokenBase (and new generate)
        GameManager.GetInstance().brokenBarDestroyed = true;
        /*
        if (PlayerPrefs.GetInt("character") == 1)
        {
            Instantiate(brokenBarPrefabPink, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("character") == 2)
        {
            Instantiate(brokenBarPrefabYellow, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("character") == 3)
        {
            Instantiate(brokenBarPrefabPurple, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
        */
    }

    /*
    public void OnTriggerExit2D(Collider2D collision)
    {
        //new broken bar object
        if (PlayerPrefs.GetInt("character") == 1)
        {
            Instantiate(brokenBarPrefabPink, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("character") == 2)
        {
            Instantiate(brokenBarPrefabYellow, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("character") == 3)
        {
            Instantiate(brokenBarPrefabPurple, transform.position + new Vector3(randomX, 12.0f, 0), Quaternion.identity);
        }
    }
    */
}