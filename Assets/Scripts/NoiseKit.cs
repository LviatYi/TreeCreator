namespace Kit {
    public static class NoiseKit {
        public static float PerlinNoise(float x, float y, float seed, float frequency = 3, float amplitude = 100) {
            return UnityEngine.Mathf.PerlinNoise((x + seed) / frequency, (y + seed) / frequency) * amplitude;
        }
    }
}
