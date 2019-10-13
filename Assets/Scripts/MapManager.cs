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

    private int frame = 0;

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

    IEnumerator StartScan()
    {
        for(var x = -SizeX/2; x < SizeX/2; x+=10)
        {
            for(var y = -SizeY/2; y < SizeY/2; y+=10)
            {
                AstarPath.active.UpdateGraphs(new Bounds(new Vector3(x, y), new Vector3(10, 10)));
                yield return null;
            }
        }

        GameManager.Instance.StartGame();
    }

    public void Update()
    {
        if (frame == 10)
        {
            AstarPath.active.Scan();
            GameManager.Instance.StartGame();
            frame++;
        } else { frame++; }
    }
    
    public bool Build(GridBrushBase Brush, int x, int y)
    {
        var pos = new Vector3Int(x, y, 0);
        if (!AstarPath.active.graphs[0].GetNearest(pos).node.Walkable) return false;

        Brush.Paint(GridObject.GetComponent<Grid>(), Obstacles.gameObject, pos);
        //AstarPath.active.graphs[0].GetNearest(new Vector3(x, y)).node.Walkable = false;
        return true;
    }

    public void Clear(int x, int y)
    {
        AstarPath.active.graphs[0].GetNearest(new Vector3(x, y)).node.Walkable = true;
    }
}
