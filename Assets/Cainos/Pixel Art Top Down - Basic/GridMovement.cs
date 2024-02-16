using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    int field_length = 100;
    int field_width = 37;
    int left_field = -51;
    int bottom_field = -20;
    int tile_size = 1;
    [SerializeField] Sprite tiles;
    int[,] nodeSet;


    // Start is called before the first frame update
    void Start()
    {
        nodeSet = new int[field_length,field_width];
    }

    void SetUpNodeSet() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
