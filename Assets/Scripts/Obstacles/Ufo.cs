using Managers;

namespace Obstacles
{
    public class Ufo : Obstacle
    {
        public override void TryDamage()
        {
            DestroyObstacle();
        }

        public override void DestroyObstacle()
        {
            ScoreManager.Instance.OnUfoDestroyed();
            UfosPool.Instance.ReturnObstacleToPool(this);
        }
    }
}