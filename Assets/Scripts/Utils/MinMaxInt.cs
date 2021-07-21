using UnityEngine;

namespace Utils
{
    [System.Serializable]
    public struct MinMaxInt
    {
        public int min;
        public int max;

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