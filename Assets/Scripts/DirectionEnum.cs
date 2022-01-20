using System;

/// <summary>
/// 方向 枚举类。
/// </summary>
[Flags]
public enum DirectionEnum : sbyte {
    /// <summary>
    /// 上
    /// </summary>
    Up = 0,
    /// <summary>
    /// 下
    /// </summary>
    Down = 1,
    /// <summary>
    /// 左
    /// </summary>
    Right = 2,
    /// <summary>
    /// 右
    /// </summary>
    Left = 4
}
