using UnityEngine;

namespace Ship
{
    [System.Serializable]
    public struct ShipSettings
    {
        [SerializeField] private float turnSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] private bool ai;

        public float TurnSpeed => turnSpeed;
        public float MoveSpeed => moveSpeed;
        public bool Ai => ai;
    }
}