using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    private GameObject objectToFollow;
    public float followSpeed = 10f;
    public float followOffset = 0f;

    public float cameraSpeed = 1.0f;

    private float increaseSpeed = 0.1f; // increase move speed

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {       
        objectToFollow = GameManager.GetInstance().characterObject;
        playerMovement = objectToFollow.GetComponent<PlayerMovement>();
        //call IncreaseSpeed after 10 seconds and then repeat it every 10 seconds
        InvokeRepeating("IncreaseSpeed", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        objectToFollow = GameManager.GetInstance().characterObject;
        if (objectToFollow.transform.position.y >= transform.position.y)
        {
            Vector3 positionToFollow = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, positionToFollow, followSpeed * Time.deltaTime);
        }
        transform.position += Vector3.up * Time.deltaTime * cameraSpeed;
        
    }

    void IncreaseSpeed()
    {
        cameraSpeed = cameraSpeed + increaseSpeed;
        Debug.Log(cameraSpeed);
        followSpeed = followSpeed + increaseSpeed;
        Debug.Log(followSpeed);
    }
}
