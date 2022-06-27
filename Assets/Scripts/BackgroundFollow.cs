using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float followSpeed = 10f;
    public float followOffset = 0f;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = objectToFollow.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.y >= followOffset)
        {
            Vector3 positionToFollow = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, positionToFollow, followSpeed * Time.deltaTime);
        }
    }
}
