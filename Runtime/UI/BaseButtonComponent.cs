using UnityEngine;
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
    }
}