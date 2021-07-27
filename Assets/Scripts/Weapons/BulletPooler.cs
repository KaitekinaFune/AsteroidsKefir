using UnityEngine;

namespace Weapons
{
    public class BulletPooler : ProjectilePooler<Bullet>
    {
        public BulletPooler(GameObject objectPrefab) : base(objectPrefab)
        {
        }
    }
}