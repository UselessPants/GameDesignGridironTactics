using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
        public int Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        float yAxisValue = Input.GetAxis("Vertical") * Speed;
        if (transform.position.y >= 8 && yAxisValue > 0) yAxisValue = 0;
        if (transform.position.y <= -11 && yAxisValue < 0) yAxisValue = 0;
        if (transform.position.x >= 29 && xAxisValue > 0) xAxisValue = 0;
        if (transform.position.x <= -31 && xAxisValue < 0) xAxisValue = 0;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yAxisValue, transform.position.z);
        
    }
}
