using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    }

    int tempi = -3;
    int tempj = 1;

    void Update() {

    }

    void UpdateView(Vector2 position, int sight) {
        for (int i = (int)position.x - sight; (int)i < position.x + sight; i++) {
            for (int j = (int)position.y - sight; (int)j < position.y + sight; j++) {
                UpdateTileView(new Vector2(i, j));
            }
        }
    }

    /// <summary>
    /// 更新指定 Tile 的 Fog 或 
    /// </summary>
    /// <param name="vec">指定 Tile 的坐标。</param>
    void UpdateTileView(Vector2 vec) {

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
}
