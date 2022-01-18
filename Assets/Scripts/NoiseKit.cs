namespace Kit {
    /// <summary>
    /// Noise 工具包。
    /// 包含一些 Noise 函数。
    /// 依赖于 UnityEngine.Mathf。
    /// 若有其他需求请向 LviatYi 反馈。
    /// </summary>
    public static class NoiseKit {
        /// <summary>
        /// 生成 Perlin Noise。
        /// 最高可生成 二维 Noise。
        /// </summary>
        /// <param name="x">变量 x</param>
        /// <param name="y">变量 y</param>
        /// <param name="seed">种子</param>
        /// <param name="frequency">
        /// 频率。
        /// 反映 Noise 的变化频率。
        /// 默认为 3。
        /// </param>
        /// <param name="amplitude">
        /// 振幅。
        /// 反映 Noise 的变化幅度。
        /// 默认为 100。
        /// </param>
        public static float PerlinNoise(float x, float y, float seed, float amplitude, float frequency) {
            return UnityEngine.Mathf.PerlinNoise((x + seed) / frequency, (y + seed) / frequency) * amplitude;
        }
    }
}
