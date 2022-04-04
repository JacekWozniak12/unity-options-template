using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace JAL
{
    public class SpriteSelector : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent onEndEdit;

        [SerializeField]
        private List<Sprite> sprites;
        
        private Image ComponentHolder;

        public enum SelectorState
        {
            EventSystem,
            Selecting
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}