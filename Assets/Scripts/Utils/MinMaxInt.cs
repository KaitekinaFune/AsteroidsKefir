using UnityEngine;

namespace Utils
{
    [System.Serializable]
    public struct MinMaxInt
    {
        [SerializeField] private int min;
        [SerializeField] private int max;

        public int Min => min;
        public int Max => max;

        public MinMaxInt(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public int GetRandom()
        {
            return Random.Range(min, max);
        }
    }
}