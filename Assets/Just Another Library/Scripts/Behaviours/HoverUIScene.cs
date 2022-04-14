using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace JAL
{
    public class HoverUIScene : MonoBehaviour
    {
        public UnityEvent<GameObject> hoverOnSceneEvent = new UnityEvent<GameObject>();
        
        [SerializeField]
        GraphicRaycaster graphicRaycaster;

        Vector3 previous;

        private void Awake()
        {
            hoverOnSceneEvent.AddListener((x) => Debug.Log(x));
        }

        private void Update()
        {
            if (Input.mousePosition != previous)
            {
                var go = GetGameObject();
                hoverOnSceneEvent?.Invoke(go);
            }
            previous = Input.mousePosition;
        }

        GameObject GetGameObject()
        {
            List<RaycastResult> results = new List<RaycastResult>();

            graphicRaycaster.Raycast(
                new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                },
                results);

            if (results.Count < 1)
                return null;

            var firstGameObject = results[0].gameObject;

            return
                firstGameObject?.GetComponent<UI_GetGameObject>()?.EscapeTo ??
                firstGameObject;
        }
    }
}
