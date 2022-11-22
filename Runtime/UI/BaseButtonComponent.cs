using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WalloutStudio.Screens.UI
{
    public class BaseButtonComponent : BaseComponent
    {
        public Button Component;
        
        [SerializeField] protected bool isInteractableOnStart = true;

        protected override void OnAwake()
        {
            base.OnAwake();

            if (isInteractableOnStart)
            {
                Unblock();
            }
            else
            {
                Block();
            }
        }

        public virtual void Block()
        {
            Component.interactable = false;
        }
        
        public virtual void Unblock()
        {
            Component.interactable = true;
        }

        public void ResetCallbacks()
        {
            Component.onClick.RemoveAllListeners();
        }
        
        public void SetCallback(UnityAction callback)
        {
            ResetCallbacks();
            AddCallback(callback);
        }

        public void AddCallback(UnityAction callback)
        {
            Component.onClick.AddListener(callback);
        }

        public void RemoveCallback(UnityAction callback)
        {
            Component.onClick.RemoveListener(callback);
        }

        private void OnValidate()
        {
            if (Component == null)
            {
                Component = GetComponent<Button>();
            }
        }
    }
}