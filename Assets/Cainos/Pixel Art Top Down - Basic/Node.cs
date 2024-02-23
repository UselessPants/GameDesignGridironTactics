using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node
{
    public Vector3 coordinates;
    public float zSpace;
    public bool passable;
    public TileBase tile;

    public Node(Vector3 vector3) {
        coordinates = vector3;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
