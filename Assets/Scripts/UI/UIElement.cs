using UnityEngine;

namespace UI
{
    public class UIElement
    {
        private GameObject gameObject;

        public void SetGameObject(GameObject obj)
        {
            gameObject = obj;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}