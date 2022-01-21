using Kit;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Map 生成类。
/// </summary>
/// <author>LviatYi</author>
public class MapGenerator : MonoBehaviour {
    [Header("Tilemap")]
    [SerializeField]
    private Tilemap map;

    [Header("Tile type")]
    [SerializeField]
    private Tile dirtTile;
    [SerializeField]
    private Tile waterTile;
    [SerializeField]
    private Tile pTile;
    [SerializeField]
    private Tile nTile;
    [SerializeField]
    private Tile kaTile;

    [Header("Seed")]
    [SerializeField]
    private float nSeed;
    [SerializeField]
    private float pSeed;
    [SerializeField]
    private float kaSeed;
    [SerializeField]
    private float waterSeed;

    private float nTileProbability;
    private float pTileProbability;
    private float kaTileProbability;
    private float waterTileProbability;

    //public float NSeed {
    //    get {
    //        return this.nSeed;
    //    }
    //    set {
    //        this.nSeed = value;
    //    }
    //}
    //public float PSeed {
    //    get {
    //        return this.pSeed;
    //    }
    //    set {
    //        this.pSeed = value;
    //    }
    //}
    //public float KaSeed {
    //    get {
    //        return this.kaSeed;
    //    }
    //    set {
    //        this.kaSeed = value;
    //    }
    //}
    //public float WaterSeed {
    //    get {
    //        return this.waterSeed;
    //    }
    //    set {
    //        this.waterSeed = value;
    //    }
    //}

    void Start() {
        map = GameObject.Find("UndergroundTilemap").GetComponent<Tilemap>();

        //以下数据建议从配置文件中获取
        this.nSeed = 100.1F;
        this.pSeed = 151.15F;
        this.kaSeed = 145.65F;
        this.waterSeed = 156.35F;

        this.nTileProbability = 70F;
        this.pTileProbability = 70F;
        this.kaTileProbability = 70F;
        this.waterTileProbability = 70F;

        //Test();
    }

    /// <summary>
    /// 目标 Tile 生成。
    /// 高价值 Tile 优先。
    /// </summary>
    /// <param name="vec">生成 Tile 的坐标。</param>
    /// <returns>在 vec 位置应该生成的 Tile 类型。</returns>
    Tile Generate(Vector2 vec) {
        Tile tile = null;

        if (tile == null) {
            // Water generate
            tile = WaterTileGenerate(vec);
        }

        if (tile == null) {

            // Base elems generate
            tile = TriElemTileGenerate(vec);
        }

        return tile;
    }

    /// <summary>
    /// 基本元素 Tile 生成。
    /// 包括 N P Ka 以及 Dirty。
    /// </summary>
    /// <param name="vec">生成 Tile 的坐标。</param>
    /// <returns>在 vec 位置应该生成的 Tile 类型。</returns>
    Tile TriElemTileGenerate(Vector2 vec) {
        Tile tile = null;

        if (vec.y <= 0) {
            tile = dirtTile;
        }


        if (NoiseKit.PerlinNoise(vec.x, vec.y, kaSeed, 100, 3) >= kaTileProbability) {
            tile = kaTile;
        }
        if (NoiseKit.PerlinNoise(vec.x, vec.y, pSeed, 100, 3) >= pTileProbability) {
            tile = pTile;
        }
        if (NoiseKit.PerlinNoise(vec.x, vec.y, nSeed, 100, 3) >= nTileProbability) {
            tile = nTile;
        }

        return tile;
    }


    /// <summary>
    /// Water Tile 生成。
    /// </summary>
    /// <param name="vec">生成 Tile 的坐标。</param>
    /// <returns>若返回 null 则不生成 Tile，反之生成。</returns>
    Tile WaterTileGenerate(Vector2 vec) {
        Tile tile = null;

        if (NoiseKit.PerlinNoise(vec.x, vec.y, waterSeed, 100, 15) >= waterTileProbability) {
            tile = waterTile;
        }

        return tile;
    }

    void Test() {
        for (int i = -50; i <= 50; i++) {
            for (int j = 0; j >= -100; j--) {
                Tile tile = Generate(new Vector2(i, j));
                this.map.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
    }
}
