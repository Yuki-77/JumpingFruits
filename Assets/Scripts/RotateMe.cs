using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    //AudioSource audio;
    public GameObject starPrefab;
    public float rotateSpeed = 1000;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        

        angle += rotateSpeed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0,angle);

        GameObject starEffect = Instantiate(starPrefab, transform.position + new Vector3(0, 0, -1), Quaternion.identity); // StartPrefab wird in GameObject (Base) gesetzt
        Destroy(starEffect, 5);

        //if (!audio.isPlaying)
        //    audio.Play();
    }
}
