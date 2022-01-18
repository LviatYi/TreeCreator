using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraController : MonoBehaviour
{
    private static List<Transform> followList = new List<Transform>();

    [Header("可调整参数")]
    [SerializeField]
    [Range(70, 100)] private int MaxFOV = 85;
    [SerializeField]
    [Range(10, 40)] private int MinFOV = 20;
    [SerializeField]
    [Range(0, 100)] private int MaxOffSetX = 40;
    [SerializeField]
    [Range(0, 100)] private int MaxOffSetY = 40;
    [SerializeField] private float MaxReturnTime =1.5f;
    [SerializeField]
    private float FOVChangeSpeed = 5;
    [SerializeField]
    private float PanSpeed = 20;

    [Header("组件")]
    [SerializeField] public InputActionReference KeyBoardInputE;
    [SerializeField] public InputActionReference KeyBoardInputQ;
    public Transform tree;

    [Header("私有属性")]
    private Transform currentFollow;
    private int currentIndex;
    private float returnTime = 0;
    
    [Header("私有组件")]
    private CinemachineInputProvider InputProvider;
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private CinemachineCameraOffset CameraOffset;

    [Header("单元测试用(记得删")]
    public Transform point1;
    public Transform point2;
    public Transform point3;
    private void Awake()
    {
        //组件获取
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        InputProvider = GetComponent<CinemachineInputProvider>();
        CameraOffset = GetComponent<CinemachineCameraOffset>();
        //初始化
        addRootPosition(tree);
        addRootPosition(point1);
        addRootPosition(point2);
        addRootPosition(point3);
    }

    private void Start()
    {
        CinemachineVirtualCamera.Follow = tree;
        currentFollow = tree;
        currentIndex = 0;
    }

    private void Update()
    {
        Pan();
        ZoomScreen();
    }



    private void Pan()
    {
        float x = InputProvider.GetAxisValue(0);
        float y = InputProvider.GetAxisValue(1);
        if (x != 0 || y != 0)
        {
            PanScreen(x,y);
        }
    }
    
    private Vector2 PanDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        if (y >= Screen.height * 0.98f)
        {
            direction.y += 1;
        }
        else if (y <= Screen.height * 0.02f)
        {
            direction.y -= 1;
        }
        if (x >= Screen.width * 0.98f)
        {
            direction.x += 1;
        }
        else if (x <= Screen.width * 0.02f)
        {
            direction.x -= 1;
        }

        return direction;
    }

    private void PanScreen(float x, float y)
    {
        Vector2 direction = PanDirection(x, y);
        if (Math.Abs(CameraOffset.m_Offset.x) >= MaxOffSetX)
        {
            direction.x = 0;
        }
        if (Math.Abs(CameraOffset.m_Offset.y)>= MaxOffSetY)
        {
            direction.y = 0;
        }
        
        CameraOffset.m_Offset = Vector3.Lerp
            (CameraOffset.m_Offset,
            CameraOffset.m_Offset+(Vector3)direction*PanSpeed,
            Time.deltaTime);
        
        if (direction.Equals(Vector2.zero))
        {
            returnTime += Time.deltaTime;
            if (returnTime > MaxReturnTime)
            {
                CameraOffset.m_Offset = Vector3.Lerp
                (CameraOffset.m_Offset,
                    Vector3.zero, Time.deltaTime);
            }
        }
        else
        {
            returnTime = 0;
        }
    }

    private void ZoomScreen()
    {
        float z = InputProvider.GetAxisValue(2);
        if (z != 0)
        {
            float fov = CinemachineVirtualCamera.m_Lens.FieldOfView;
            float target = Mathf.Clamp(fov - z, MinFOV, MaxFOV);
            CinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, FOVChangeSpeed * Time.deltaTime);
        }
    }
    public void KeyDownE()
    {
        if (currentIndex + 1 > followList.Count-1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex += 1;
        }
        changeFollowRoot(currentIndex);
        currentFollow = followList.ElementAt(currentIndex);
    }

    public void KeyDownQ()
    {
        if (currentIndex - 1 < 0)
        {
            currentIndex = followList.Count-1;
        }
        else
        {
            currentIndex -= 1;
        }
        changeFollowRoot(currentIndex);
        currentFollow = followList.ElementAt(currentIndex);
    }

    /// <summary>
    /// 更改目前追踪对象
    /// </summary>
    /// <param name="set">更改为第int个追踪对象</param>
    public void changeFollowRoot(int set)
    {
        CinemachineVirtualCamera.Follow = followList.ElementAt(set);
        currentFollow = followList.ElementAt(set);
        currentIndex = set;
        CameraOffset.m_Offset = Vector3.zero;
    }
    
    /// <summary>
    /// 增加追踪对象
    /// </summary>
    /// <param name="set">添加的追踪对象的transform</param>
    public static void addRootPosition(Transform set)
    {
        followList.Add(set);
    }
    
    /// <summary>
    /// 删除追踪对象
    /// </summary>
    /// <param name="set">删除第几个追踪对象,0号对象是树</param>
    public static void delRootPosition(int set)
    {
        followList.RemoveAt(set);
    }
}
