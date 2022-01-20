using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// View 控制类。
/// </summary>
/// <author>LviatYi</author>
public class ViewController : MonoBehaviour {
    [Header("Player attr")]
    [SerializeField]
    private int sight;
    [SerializeField]
    private Vector2 position;

    /// <summary>
    /// 已加载的 Fog 区域。
    /// </summary>
    private List<Vector2> fogField = new List<Vector2>();

    [Header("Field attr")]
    [SerializeField]
    private int fieldWidth = 10;
    [SerializeField]
    private int fieldHeight = 10;

    [SerializeField]
    private Tilemap undergroundMap;
    [SerializeField]
    private Tilemap fogMap;

    [Header("Tile type")]
    [SerializeField]
    private RuleTile fogTile;


    void Start() {
        // 挂载 Tilemap
        this.undergroundMap = GameObject.Find("UndergroundTilemap").GetComponent<Tilemap>();
        this.fogMap = GameObject.Find("FogTilemap").GetComponent<Tilemap>();


        fogField.Add(new Vector2(-1, 1));
        fogField.Add(new Vector2(-1, 0));
        fogField.Add(new Vector2(-1, -1));
        fogField.Add(new Vector2(0, 1));
        fogField.Add(new Vector2(0, 0));
        fogField.Add(new Vector2(0, -1));
        fogField.Add(new Vector2(1, 1));
        fogField.Add(new Vector2(1, 0));
        fogField.Add(new Vector2(1, -1));

        foreach (Vector2 item in fogField) {
            GenerateFog(item);
        }

        LightUp(new Vector2(0, 0), this.sight);
        //LightUp(new Vector2(1, 5));

        LightUp(new Vector2(0, 0), DirectionEnum.Down, 2);
    }

    /// <summary>
    /// 生成矩形迷雾。指定左下角为起始点。
    /// 具有覆盖特性。
    /// </summary>
    /// <param name="position">视野起始点坐标</param>
    /// <param name="width">生成宽度</param>
    /// <param name="height">生成高度</param>
    void GenerateFog(Vector2 position, int width, int height) {
        for (int i = (int)position.x; i < (int)position.x + width; i++) {
            for (int j = (int)position.y; j < (int)position.y + height; j++) {
                this.fogMap.SetTile(new Vector3Int(i, j, 0), this.fogTile);
            }
        }
    }

    /// <summary>
    /// 根据 Field 坐标成块生成矩形迷雾。
    /// 根据 fieldWidth fieldHeight 字段确定 Field 大小。
    /// 具有覆盖特性。
    /// </summary>
    /// <param name="newField">新的迷雾块坐标。</param>
    void GenerateFog(Vector2 newField) {
        int newX = (int)newField.x * fieldWidth - fieldWidth / 2;
        int newY = (int)newField.y * fieldHeight - fieldHeight / 2;

        GenerateFog(new Vector2(newX, newY), fieldWidth, fieldHeight);
    }

    /// <summary>
    /// 根据当前地图坐标与期待的迷雾生成方向生成迷雾 Field。
    /// </summary>
    /// <param name="position">地图坐标</param>
    /// <param name="direction">方向</param>
    void GenerateFog(Vector2 position, DirectionEnum direction) {
        // 计算 position 所在的 Field 坐标。
        int newX = ((int)position.x - fieldWidth / 2) / fieldWidth + 1;
        int newY = ((int)position.y - fieldHeight / 2) / fieldHeight + 1;

        switch (direction) {
            case DirectionEnum.Up:
                newY++;
                break;
            case DirectionEnum.Right:
                newX++;
                break;
            case DirectionEnum.Left:
                newX--;
                break;
            case DirectionEnum.Down:
            default:
                newY--;
                break;
        }

        GenerateFog(new Vector2(newX, newY));
    }

    /// <summary>
    /// 照亮一块 Tile。
    /// </summary>
    /// <param name="vec"></param>
    void LightUp(Vector2 vec) {
        this.fogMap.SetTile(new Vector3Int((int)vec.x, (int)vec.y, 0), null);
    }


    /// <summary>
    /// 照亮坐标视野范围外的一片 Tile。
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="sight"></param>
    void LightUp(Vector2 vec, int sight) {
        LightUp(vec);

        for (int i = (int)vec.x - sight; i <= vec.x; i++) {
            for (int j = (int)vec.y - sight; j < vec.y; j++) {
                int disX = (int)vec.x - i;
                int disY = (int)vec.y - j;

                //四分算法 效率提升
                if (Vector2.Distance(new Vector2(i, j), vec) < sight) {
                    this.LightUp(new Vector2(i, j));
                    this.LightUp(new Vector2(i + 2 * disX, j + 2 * disY));
                    this.LightUp(new Vector2(i + disX + disY, j + disY - disX));
                    this.LightUp(new Vector2(i + disX - disY, j + disX + disY));
                }
            }
        }
    }

    /// <summary>
    /// 沿某个方向照亮指定步数视野范围内的一片 Tile。
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="direction"></param>
    /// <param name="step"></param>
    void LightUp(Vector2 vec, DirectionEnum direction, int step) {
        Vector2 increase;
        switch (direction) {
            case DirectionEnum.Up:
                increase = new Vector2(0, 1);
                break;
            case DirectionEnum.Right:
                increase = new Vector2(1, 0);
                break;
            case DirectionEnum.Left:
                increase = new Vector2(-1, 0);
                break;
            case DirectionEnum.Down:
            default:
                increase = new Vector2(0, -1);
                break;
        }

        for (int i = 0; i < step; i++) {
            vec += increase;
            LightUp(vec, this.sight);
        }
    }
}
