using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int width, height;
    [SerializeField] private Tile grassTile, rockTile;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;
    private void Awake()
    {
        Instance = this;
    }
    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {

            for (int y = 0; y < height; y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ? rockTile : grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(x,y);

                tiles[new Vector2 (x, y)] = spawnedTile;
            }
        }
        cam.transform.position = new Vector3((float)width/2 - 0.5f,(float) height/2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }
    public Tile GetTilePosition(Vector2 position)
    {
        if(tiles.TryGetValue(position, out var tile))
        {
            return tile;
        }
        return null;
    }
}
