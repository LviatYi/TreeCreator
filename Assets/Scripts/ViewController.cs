using UnityEngine;
using UnityEngine.Tilemaps;

public class ViewController : MonoBehaviour {
    [Header("Player attr")]
    [SerializeField]
    private int sight;

    [SerializeField]
    private Tilemap map;

    void Start() {
        this.map = GameObject.Find("UndergroundTilemap").GetComponent<Tilemap>();
    }

    void Update() {

    }
}
