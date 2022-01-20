using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// MapManager 类。
/// 用于获取 Map 包含的各种元素的信息。
/// </summary>
/// <author>LviatYi</author>
public class MapManager : MonoBehaviour {
    Tilemap map;

    // Start is called before the first frame update
    void Start() {
        this.map = GameObject.Find("UndergroundTilemap").GetComponent<Tilemap>();
    }

    /// <summary>
    /// 获取指定坐标的 Tile。
    /// </summary>
    /// <param name="vec">指定坐标。</param>
    /// <returns>指定坐标的 Tile 。若无 Tile 或 越界则返回 null。</returns>
    public Tile GetTile(Vector3Int vec) {
        Tile tile = (Tile)map.GetTile(new Vector3Int(vec.x, vec.y, vec.z));

        return tile;
    }

    /// <summary>
    /// 获取指定坐标 Tile 的 TileName。
    /// </summary>
    /// <param name="vec">指定坐标。</param>
    /// <returns>指定坐标 Tile 的 TileName。若无 Tile 或 越界则返回 ""。</returns>
    public string GetTileName(Vector3Int vec) {
        Tile tile = GetTile(vec);

        if (tile != null) {
            return tile.name;
        } else {
            return "";
        }

    }

    /// <summary>
    /// 获取指定坐标 Tile 的 TileInfo。
    /// </summary>
    /// <param name="vec">指定坐标。</param>
    /// <returns>指定坐标 Tile 的 TileInfo。若无 Tile 或 越界则返回 null。</returns>
    public TileInfo GetTileInfo(Vector3Int vec) {
        TileInfo result = null;
        Tile tile = GetTile(vec);
        if (tile != null) {
            switch (tile.name) {
                case "DirtTile":
                    result = new TileInfo() { Name = "DirtTile", Coordinate = vec, Description = "泥土...", Type = UndergroundTileType.Dirt, BloodSameCoordinate = BloodCompare(vec) };
                    break;
                case "NTile":
                    result = new TileInfo() { Name = "NTile", Coordinate = vec, Description = "石...", Type = UndergroundTileType.N, BloodSameCoordinate = BloodCompare(vec) };
                    break;
                case "PTile":
                    result = new TileInfo() { Name = "PTile", Coordinate = vec, Description = "粦...", Type = UndergroundTileType.P, BloodSameCoordinate = BloodCompare(vec) };
                    break;
                case "KaTile":
                    result = new TileInfo() { Name = "KaTile", Coordinate = vec, Description = "甲...", Type = UndergroundTileType.Ka, BloodSameCoordinate = BloodCompare(vec) };
                    break;
                default:
                    break;
            }
        }

        return result;
    }

    /// <summary>
    /// 四格洪泛法获取相同类型的 Tile。
    /// 请尽量避免过大的连续 Tile，可能会有性能问题。
    /// </summary>
    /// <param name="vec">起始坐标。</param>
    /// <returns>返回同类型的 Tile 坐标集合。</returns>
    private List<Vector3Int> BloodCompare(Vector3Int vec) {
        List<Vector3Int> result = new List<Vector3Int>();
        Stack<Vector3Int> compareStack = new Stack<Vector3Int>();
        List<Vector3Int> visited = new List<Vector3Int>();

        visited.Add(vec);

        string originName = GetTile(vec).name;
        if (!string.IsNullOrEmpty(originName)) {
            compareStack.Push(vec);
        }

        Vector3Int[] judgementGrid = {
                new Vector3Int(1, 0, 0) ,
                new Vector3Int(-1, 0, 0) ,
                new Vector3Int(0, 1, 0) ,
                new Vector3Int(0, -1, 0)
            };

        while (compareStack.Count > 0) {
            Vector3Int coord = compareStack.Pop();
            result.Add(coord);
            Vector3Int newCoord;

            foreach (Vector3Int offset in judgementGrid) {
                newCoord = coord + offset;
                if (!visited.Contains(newCoord)) {
                    visited.Add((newCoord));
                    if (GetTileName(newCoord).Equals(originName)) {
                        compareStack.Push(newCoord);
                    }
                }
            }
        }
        return result;
    }
}
