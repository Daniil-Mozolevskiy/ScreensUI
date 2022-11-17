using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WalloutStudio.Screens.UI
{
    public class BaseButtonComponent : BaseComponent
    {
        public Button ButtonComponent;
        
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
            ButtonComponent.interactable = false;
        }
        
        public virtual void Unblock()
        {
            ButtonComponent.interactable = true;
        }

        public void ResetCallbacks()
        {
            ButtonComponent.onClick.RemoveAllListeners();
        }
        
        public void SetCallback(UnityAction callback)
        {
            ResetCallbacks();
            AddCallback(callback);
        }

        public void AddCallback(UnityAction callback)
        {
            ButtonComponent.onClick.AddListener(callback);
        }

        public void RemoveCallback(UnityAction callback)
        {
            ButtonComponent.onClick.RemoveListener(callback);
        }
    }
}