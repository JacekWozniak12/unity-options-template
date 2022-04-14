using UnityEngine;
using UnityEngine.Events;

namespace JAL
{
    public class Hover3DScene : MonoBehaviour
    {
        public UnityEvent<GameObject> hoverOnSceneEvent = new UnityEvent<GameObject>();
        public bool Active = false;

        [SerializeField]
        LayerMask layer;

        void FixedUpdate()
        {
            if (Active)
                hoverOnSceneEvent?.Invoke(GetObject());
        }

        GameObject GetObject()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.collider.gameObject;
            }
            return null;
        }
    }
}
