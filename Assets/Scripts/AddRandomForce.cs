using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomForce : MonoBehaviour
{
    public Vector2 minForce;
    public Vector2 maxForce;
    public float minTorque;
    public float maxTorque;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rbd = GetComponent<Rigidbody2D>(); //barBrokenLeft and barBrokenright
        rbd.AddForce(new Vector2(Random.Range(minForce.x,maxForce.x), Random.Range(minForce.y, maxForce.y)));
        rbd.AddTorque(Random.Range(minTorque,maxTorque));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
