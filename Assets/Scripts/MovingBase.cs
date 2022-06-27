using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBase : MonoBehaviour
{
    public GameObject starPrefab;
    [Range(0.0f, 1000.0f)]
    public float jumpForce = 380.0f;
    public string direction = "left";
   
    
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x > -6f)
        {
            direction = "left";
        }
        else
        {
            direction = "right";
        }
    }

    // Update is called once per frame  
    void Update()
    {
        Vector3 position = transform.position;
        if (Time.timeScale == 1)
        {
            if (position.x > -2f && direction == "left") //move to the left
            {
                transform.position = transform.position - new Vector3(0.03f, 0.0f, 0.0f);
            }

            else if (position.x <= -2f) //move to the right
            {
                direction = "right";
                transform.position = transform.position + new Vector3(0.03f, 0.0f, 0.0f);
            }

            else if (position.x < 2f && direction == "right")
            {
                transform.position = transform.position + new Vector3(0.03f, 0.0f, 0.0f);
            }

            else if (position.x >= 2f) //move to the right
            {
                direction = "left";
                transform.position = transform.position - new Vector3(0.03f, 0.0f, 0.0f);
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

        Rigidbody2D rigidBody = GameManager.GetInstance().playerMovement.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0.0f);
        rigidBody.AddForce(new Vector2(0.0f, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        player.animationState = "jump";

        GameObject starEffect = Instantiate(starPrefab, transform.position + new Vector3(0, 0, -1), Quaternion.identity); // StartPrefab wird in GameObject (Base) gesetzt
        Destroy(starEffect, 2);
        
        GameManager.GetInstance().secondBaseYPosition = Mathf.Abs(transform.position.y);
        CalculateScore(GameManager.GetInstance().firstBaseYPosition, GameManager.GetInstance().secondBaseYPosition);
        GameManager.GetInstance().firstBaseYPosition = GameManager.GetInstance().secondBaseYPosition;
    }

    private void CalculateScore(float firstBasePosition, float secondBasePosition)
    {
        GameManager.GetInstance().currentScore += 10 * Mathf.FloorToInt(Mathf.Abs(secondBasePosition - firstBasePosition));
        if (GameManager.GetInstance().currentScore > GameManager.GetInstance().highScore)
            GameManager.GetInstance().highScore = GameManager.GetInstance().currentScore;
    }
}
