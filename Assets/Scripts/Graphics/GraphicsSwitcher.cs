using UnityEngine;

namespace Graphics
{
    public class GraphicsSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject Graphics2D;
        [SerializeField] private GameObject Graphics3D;

        private void OnEnable()
        {
            if (GraphicsManager.Instance.is3DOn)
            {
                SetTo3D();
            }
            else
            {
                SetTo2D();
            }
            
            GraphicsManager.Instance.OnChangeGraphicsTo2D += SetTo2D;
            GraphicsManager.Instance.OnChangeGraphicsTo3D += SetTo3D;
        }

        private void OnDisable()
        {
            GraphicsManager.Instance.OnChangeGraphicsTo2D -= SetTo2D;
            GraphicsManager.Instance.OnChangeGraphicsTo3D -= SetTo3D;
        }

        private void SetTo2D()
        {
            Graphics2D.SetActive(true);
            Graphics3D.SetActive(false);
        }

        private void SetTo3D()
        {
            Graphics2D.SetActive(false);
            Graphics3D.SetActive(true);
        }
    }
}