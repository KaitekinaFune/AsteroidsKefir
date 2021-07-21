using UnityEngine;

namespace Utils
{
    public class Boundary : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var boundaryExitedObject = other.GetComponent<IDestroyableByBoundary>();
            boundaryExitedObject?.OnBoundaryTouch();
        }
    }
}