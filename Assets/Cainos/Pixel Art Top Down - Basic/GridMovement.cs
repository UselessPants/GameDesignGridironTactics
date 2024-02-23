using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : MonoBehaviour
{

    int field_length = 100;
    int field_width = 37;
    int left_field = -51;
    int bottom_field = -20;
    [SerializeField] Sprite tiles;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] Tilemap tilemap;
    [SerializeField] TileBase tile;
    [SerializeField] TileBase tileUnpassable;
    public static Node[,] nodeGrid;


    // Start is called before the first frame update
    void Start()
    {
        nodeGrid = new Node[field_length,field_width];
        SetUpNodeGrid();

    }

    private Vector3 generateWorldPosition(int x, int y)
    {
        return new Vector3(transform.position.x + x + left_field, transform.position.y + y + bottom_field, 0);
    }

    void SetUpNodeGrid() {
        for (int i = 0; i < field_length; i++) {
            for (int j = 0; j < field_width; j++) {
                Vector3 worldPosition = generateWorldPosition(i, j);
                nodeGrid[i, j] = new Node(worldPosition)
                {
                    passable = !Physics2D.OverlapBox(worldPosition, Vector2.one/2, 0),
                    tile = Instantiate(tile)
                };
                if (!nodeGrid[i,j].passable) {
                    nodeGrid[i,j].tile = Instantiate(tileUnpassable);
                }
                tilemap.SetTile(Vector3Int.FloorToInt(nodeGrid[i,j].coordinates), nodeGrid[i,j].tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
