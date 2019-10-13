using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AstarPath))]
public class MapManager : MonoBehaviour
{
    private static MapManager mapManager;
    private static GameObject GridObject;
    private static Tilemap Ground;
    private static Tilemap Obstacles;
    public static readonly int SizeX = 1000;
    public static readonly int SizeY = 1000;

    [SerializeField] public Tile[] Tiles;
    public GridBrushBase[] ResourceNodes;
    public int NumResourceSpawn = 1000;

    private bool Scanned = false;

    public static MapManager Instance
    {
        get
        {
            if (mapManager == null)
            {
                var Instance = FindObjectOfType<MapManager>();
                if (Instance == null)
                {
                    Instance = GameObject.FindGameObjectWithTag("GameController").AddComponent<MapManager>();
                }
                mapManager = Instance;
            }
            return mapManager;
        }
    }

    public void Awake()
    {
        if (mapManager == null) mapManager = this;
        //Generate the map itself
        if(GridObject == null)
        {
            //Setup the grid
            GridObject = new GameObject();
            GridObject.name = "Grid";
            GridObject.transform.parent = gameObject.transform;
            GridObject.AddComponent<Grid>();

            //Setup the Obstacle layer
            var ObstaclesObject = new GameObject();
            ObstaclesObject.transform.parent = GridObject.transform;
            ObstaclesObject.name = "Obstacles";
            ObstaclesObject.layer = 13;
            Obstacles = ObstaclesObject.AddComponent<Tilemap>();
            ObstaclesObject.AddComponent<TilemapRenderer>();
            ObstaclesObject.AddComponent<TilemapCollider2D>();

            //Setup the Ground layer
            var GroundObject = new GameObject();
            GroundObject.transform.parent = GridObject.transform;
            GroundObject.name = "Ground";
            GroundObject.layer = 0;
            Ground = GroundObject.AddComponent<Tilemap>();
            GroundObject.AddComponent<TilemapRenderer>().sortingOrder = -1;

            //Make the ground layer
            for (int x = -SizeX/2; x < SizeX/2; x++)
            {
                for(int y = -SizeY/2; y < SizeY/2; y++)
                {
                    Ground.SetTile(new Vector3Int(x, y, 0), Tiles[0]);
                }
            }

            //Add Resource Nodes
            for(int i = 0; i < ResourceNodes.Length; i++)
            {
                for(var n = 0; n < NumResourceSpawn; n++)
                {
                    var Pos = new Vector3Int(Random.Range(-SizeX / 2, SizeX / 2), Random.Range(-SizeY / 2, SizeY / 2), 0);
                    ResourceNodes[i].Paint(GridObject.GetComponent<Grid>(), Obstacles.gameObject, Pos);
                }
            }
        }
    }

    public void Update()
    {
        if (!Scanned)
        {
            AstarPath.active.Scan();
            Scanned = true;
        }
    }
}
