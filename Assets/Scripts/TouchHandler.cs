using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public List<PlayerMovement> characters = new List<PlayerMovement>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float axis = 0;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width * 0.5f)
            {
                axis = -1;
            }
            else
            {
                axis = 1;
            }
        }
        foreach(PlayerMovement pm in characters)
        {
            pm.inputAxisX = axis;
        }
    }
}
