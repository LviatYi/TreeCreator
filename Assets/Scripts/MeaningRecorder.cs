using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MeaningRecorder 类。
/// </summary>
/// <author>LviatYi</author>
public class MeaningRecorder : MonoBehaviour {
    List<Vector3Int> rootCoords;
    List<Vector3Int> rootEndings;
    // Start is called before the first frame update
    void Start() {

    }

    /// <summary>
    /// 向某方向生长一个单位的 root。
    /// </summary>
    /// <param name="growPoint">生长起始点。</param>
    /// <param name="direction">生长方向。无视向上的生长。</param>
    void rootGrow(Vector3Int growPoint, DirectionEnum direction) {
        if (rootEndings.Contains(growPoint)) {
            int index = rootEndings.FindIndex((Vector3Int root) => root == growPoint);

            switch (direction) {
                case DirectionEnum.Down:
                    addRoot(growPoint + new Vector3Int(0, -1, 0));
                    rootEndings[index] = rootEndings[index] + new Vector3Int(0, -1, 0);
                    break;
                case DirectionEnum.Right:
                    addRoot(growPoint + new Vector3Int(1, 0, 0));
                    rootEndings[index] = rootEndings[index] + new Vector3Int(1, 0, 0);
                    break;
                case DirectionEnum.Left:
                    addRoot(growPoint + new Vector3Int(-1, 0, 0));
                    rootEndings[index] = rootEndings[index] + new Vector3Int(-1, 0, 0);
                    break;
                case DirectionEnum.Up:
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 在指定坐标生成 root Tile。
    /// </summary>
    /// <param name="vec">指定坐标。</param>
    void addRoot(Vector3Int vec) {
        if (!rootCoords.Contains(vec)) {
            rootCoords.Add(vec);
        }
    }

    /// <summary>
    /// 将玩家数据保存至指定文件。
    /// </summary>
    void save() {
        //TODO_LviatYi 加载与保存
    }

    /// <summary>
    /// 将玩家数据加载自指定文件。
    /// </summary>
    void load() {

    }
}
