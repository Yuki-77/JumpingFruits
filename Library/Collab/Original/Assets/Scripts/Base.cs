using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Base : MonoBehaviour
{
    private GameObject starPrefab;
    [Range(0.0f, 1000.0f)]
    public float jumpForce = 380.0f;

    AudioSource audio;
    public string type = "normal"; //"spring", "dung", "worm", "snail", "fragile", "moving", "brokenBar"
    private float resetPosition = 12.0f; // reset the y value of bases
    public string direction = "left";
    public GameObject dungPrefab, wormPrefab, snailPrefab, springPrefab;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        starPrefab = GameManager.GetInstance().starEffekt;
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

        float level = GameManager.GetInstance().level;
        level = GameManager.GetInstance().level;
        if (transform.position.y < GameManager.GetInstance().mainCamera.transform.position.y - 5.2f)
        {
            if (GameManager.GetInstance().timeLeftCreateSpring <= 0)
            {
                ResetPosition("spring");
                GameManager.GetInstance().timeLeftCreateSpring = 500f * Time.deltaTime;
            }

            else if (GameManager.GetInstance().timeLeftCreateDung <= 0)
            {
                ResetPosition("dung");
                GameManager.GetInstance().timeLeftCreateDung = (800f - Mathf.Min(200f,90*level)) * Time.deltaTime;
            }

            else if (GameManager.GetInstance().timeLeftCreateWorm <= 0)
            {
                ResetPosition("worm");
                GameManager.GetInstance().timeLeftCreateWorm = (900f - Mathf.Min(400f, 70*level)) * Time.deltaTime;
            }

            else if (GameManager.GetInstance().timeLeftCreateSnail <= 0)
            {
                ResetPosition("snail");
                GameManager.GetInstance().timeLeftCreateSnail = (1000f - (60f * level)) * Time.deltaTime;
            }

            else if (GameManager.GetInstance().timeLeftCreateMovingBase <= 0)
            {
                ResetPosition("moving");
                GameManager.GetInstance().timeLeftCreateMovingBase = 6.0f;
            }

            else
            {
                ResetPosition("normal");
            }
        }
        
        //movingBase
        if(type == "moving")
        {

            Vector3 position = transform.position;
            if (Time.timeScale == 1)
            {
                if (position.x > -2f && direction == "left")
                {
                    transform.position = transform.position - new Vector3(0.03f, 0.0f, 0.0f);
                }
                else if (position.x <= -2f)
                {
                    direction = "right";
                    transform.position = transform.position + new Vector3(0.03f, 0.0f, 0.0f);
                }
                else if (position.x < 2f && direction == "right")
                {
                    transform.position = transform.position + new Vector3(0.03f, 0.0f, 0.0f);
                }
                else if (position.x >= 2f)
                {
                    direction = "left";
                    transform.position = transform.position - new Vector3(0.03f, 0.0f, 0.0f);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Character player = GameManager.GetInstance().player;
        player.animationState = "jump";
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        //when character is on the air (velocity.y > 0) then collider2D return nothing
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            return;

        

        Character player = GameManager.GetInstance().player;
        player.animationState = "idle";

        if (collision.GetComponent<RotateMe>().enabled) //stop rotation from springEffect
        {
            collision.GetComponent<RotateMe>().angle = 0;
            collision.transform.rotation = Quaternion.identity;
            collision.GetComponent<RotateMe>().enabled = false;
        }

        if (!audio.isPlaying)
        {
            audio.Play();
        }

        Rigidbody2D rigidBody = GameManager.GetInstance().playerMovement.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0.0f);
        rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        player.animationState = "jump";

        GameObject starEffect = Instantiate(starPrefab, transform.position + new Vector3(0,0,-1), Quaternion.identity); // StartPrefab wird in GameObject (Base) gesetzt
        Destroy(starEffect,2);
        
        GameManager.GetInstance().secondBaseYPosition = Mathf.Abs(transform.position.y);
        CalculateScore(GameManager.GetInstance().firstBaseYPosition, GameManager.GetInstance().secondBaseYPosition);
        GameManager.GetInstance().firstBaseYPosition = GameManager.GetInstance().secondBaseYPosition;      
    }
    
    //reset the position of bases
    void ResetPosition(string setType)
    {
        float randomX = 0.0f; //choose random x value of bases
        if(transform.position.x > 0.0f && transform.position.x <= 6.0f)
        {
            randomX = Random.Range(-2.0f, 0.0f);

        }else if (transform.position.x <= 0.0f && transform.position.x >= -6.0f)
        {
            randomX = Random.Range(0.0f, 2.0f);
        }
        transform.position = transform.position + new Vector3(randomX, resetPosition, 0);

        type = setType;

        //dung base
        if (setType == "dung")
        {
            GameObject dungObject = Instantiate(dungPrefab, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity); // dungPrefab wird in GameObject (Base) gesetzt
            Destroy(dungObject, 30f);
        }

        //worm base
        else if (type == "worm")
        {
            GameObject wormObject = Instantiate(wormPrefab, transform.position + new Vector3(0.3f, 0.45f, 0), Quaternion.identity); // dungPrefab wird in GameObject (Base) gesetzt
            Destroy(wormObject, 30f);
        }

        //snail base
        else if (type == "snail")
        {
            GameObject snailObject = Instantiate(snailPrefab, transform.position + new Vector3(0.3f, 0.35f, 0), Quaternion.identity); // dungPrefab wird in GameObject (Base) gesetzt
            Destroy(snailObject, 30f);
        }

        //spring base
        else if (type == "spring")
        {
            GameObject springObject = Instantiate(springPrefab, transform.position + new Vector3(0, 0.35f, 0), Quaternion.identity); // dungPrefab wird in GameObject (Base) gesetzt
            Destroy(springObject, 30f);
        }
    }

    private void CalculateScore(float firstBasePosition, float secondBasePosition)
    {
        GameManager.GetInstance().currentScore += 10 * Mathf.FloorToInt(Mathf.Abs(secondBasePosition - firstBasePosition));
        if (GameManager.GetInstance().currentScore > GameManager.GetInstance().highScore)
            GameManager.GetInstance().highScore = GameManager.GetInstance().currentScore;
    }
}