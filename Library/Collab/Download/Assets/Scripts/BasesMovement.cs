using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasesMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = -50.0f; // basical move speed of bases
    private float increaseSpeed = -1f; // increase move speed
    public int timeScore = 0;
   
    void Start()
    {
        //currentTime = Time.deltaTime;
        // call IncreaseSpeed after 5 seconds and then repeat it every 2 seconds
        //InvokeRepeating("IncreaseSpeed", 5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(0, moveSpeed*Time.deltaTime,0);
        //timeScore += Mathf.FloorToInt(10 * (int)Time.deltaTime);
    }
    // increase move speed of bases over basical move speed
    void IncreaseSpeed()
    {
        moveSpeed = moveSpeed + increaseSpeed;
    }
    public void BasesMoveDown()
    {
        transform.position = transform.position + new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }
}
