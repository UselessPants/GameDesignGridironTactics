using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pointer : MonoBehaviour
{

    [SerializeField] Grid grid;
    [SerializeField] Tilemap selectMap;
    [SerializeField] TileBase hoverTile;
    int left_field = -51;
    int bottom_field = -20;
    
    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos)) {
            if (GridMovement.nodeGrid[mousePos.x-left_field, mousePos.y-bottom_field].passable) {
                Debug.Log(mousePos);
                selectMap.SetTile(previousMousePos, null); // Remove old hoverTile
                selectMap.SetTile(mousePos, hoverTile);
                previousMousePos = mousePos;
            } else {
                selectMap.SetTile(previousMousePos, null);
                previousMousePos = mousePos;
            }
        }
    }


    Vector3Int GetMousePosition () {
        Vector3 mouseWorld = Input.mousePosition;
        mouseWorld.z = 15f;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseWorld);
        Debug.Log("x = " + mouseWorldPos.x + " y = " + mouseWorldPos.y);
        return grid.WorldToCell(mouseWorldPos);
    }
}
