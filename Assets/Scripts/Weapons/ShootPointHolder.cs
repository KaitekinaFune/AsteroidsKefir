using UnityEngine;

namespace Weapons
{
    public class ShootPointHolder : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;

        public Transform ShootPoint => shootPoint;
    }
}