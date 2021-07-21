using UnityEngine;

namespace Obstacles
{
    public class UfoTarget : MonoBehaviour
    {
        public static UfoTarget Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}