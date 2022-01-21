using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tile 信息类。
/// </summary>
/// <author>LviatYi</author>
public class TileInfo {
    private Vector3 coordinate;
    private string name;
    private string description;
    private UndergroundTileType type;
    private List<Vector3Int> floodSameCoordinate;

    /// <summary>
    /// 坐标。
    /// </summary>
    public Vector3 Coordinate { get => coordinate; set => coordinate = value; }

    /// <summary>
    /// Tile 名称。
    /// </summary>
    public string Name { get => name; set => name = value; }

    /// <summary>
    /// 描述。
    /// </summary>
    public string Description { get => description; set => description = value; }

    /// <summary>
    /// 类型。
    /// </summary>
    public UndergroundTileType Type { get => type; set => type = value; }

    /// <summary>
    /// 同类 Tile 块坐标。
    /// </summary>
    public List<Vector3Int> FloodSameCoordinate { get => floodSameCoordinate; set => floodSameCoordinate = value; }
}
