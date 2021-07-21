using UnityEngine;

namespace Utils
{
    [System.Serializable]
    public struct MinMaxFloat
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min => min;
        public float Max => max;

        public MinMaxFloat(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public float GetRandom()
        {
            return Random.Range(min, max);
        }
    }
}