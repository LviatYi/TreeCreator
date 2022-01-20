using System.Collections.Generic;
using UnityEngine;

public class TileInfo {
    /// <summary>
    /// 坐标。
    /// </summary>
    private Vector3 coordinate;

    /// <summary>
    /// Tile 名称。
    /// </summary>
    private string name;

    /// <summary>
    /// 描述。
    /// </summary>
    private string description;

    /// <summary>
    /// 类型。
    /// </summary>
    private UndergroundTileType type;

    /// <summary>
    /// 同类 Tile 块坐标。
    /// </summary>
    private List<Vector3Int> bloodSameCoordinate;

    public Vector3 Coordinate { get => coordinate; set => coordinate = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public UndergroundTileType Type { get => type; set => type = value; }
    public List<Vector3Int> BloodSameCoordinate { get => bloodSameCoordinate; set => bloodSameCoordinate = value; }
}
