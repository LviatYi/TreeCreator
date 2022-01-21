using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主 Controller 类。
/// </summary>
/// <author>LviatYi</author>
public class MainController : MonoBehaviour {
    [Header("Manager")]
    [SerializeField]
    private ViewController viewController;
    [SerializeField]
    private MapGenerator mapGenerator;
    [SerializeField]
    private MeaningRecorder meaningRecorder;

    // Start is called before the first frame update
    void Start() {
        this.viewController = GameObject.Find("ViewController").GetComponent<ViewController>();

    }

    // Update is called once per frame
    void Update() {

    }
}
