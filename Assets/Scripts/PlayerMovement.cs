using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    [Range(0.0f, 10.0f)]
    public float movementSpeed = 2;

    [Range(0f, 1f)]
    public float smoothingAir = 0.06f;

    [Range(0f,5000f)]
    public float jumpForce = 5000f;

    Rigidbody2D rigidBody;
    Vector2 wantedVelocity;

    [HideInInspector]
    public float y;

    public bool reverseControl = false;

    public float inputAxisX;

    // Start is called before the first frame update
    void Start()
    {
        Character character = GameManager.GetInstance().player;
        rigidBody = GetComponent<Rigidbody2D>();
        if (character.animationState == "jump")
        {
            //rigidBody.AddForce(Vector2.up * jumpForce);
            //rigidBody.AddForce(new Vector2(0.0f, movementForce * Time.deltaTime));
        }
    }

   
    // Update is called once per frame
    void FixedUpdate()
    {
        Character character = GameManager.GetInstance().player;
        float axisX = Input.GetAxis("Horizontal")+ inputAxisX;

        if (GameManager.GetInstance().timeLeftDung <= 0) //turn off dung effect
        {
            reverseControl = false;
        }
        if (reverseControl) //dung effect is on
        {
            GameManager.GetInstance().timeLeftDung -= Time.deltaTime;
            wantedVelocity.x = -1 * axisX * movementSpeed;
        }
        else
        {
            wantedVelocity.x = axisX * movementSpeed;
        }
        
        wantedVelocity.y = rigidBody.velocity.y;
        float smoothing = smoothingAir;
        rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, wantedVelocity, smoothing);
        y = GetComponent<Rigidbody2D>().velocity.y;
    }
}
