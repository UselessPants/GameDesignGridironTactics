using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Unit"))
        {
            Debug.Log("COLLIDE");
            Destroy(this.gameObject);
        }
    }
}
