using UnityEngine;

namespace Weapons
{
    public class LaserPooler : ProjectilePooler<Laser>
    {
        public LaserPooler(GameObject objectPrefab) : base(objectPrefab)
        {
        }
    }
}