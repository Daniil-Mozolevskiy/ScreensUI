using UnityEngine;

namespace WalloutStudio.Screens.Controllers
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField] protected bool hideOnStart;
        
        private void Awake()
        {
            if (hideOnStart)
            {
                if (gameObject.activeSelf)
                {
                    Hide();
                }
            }
            else
            {
                if (!gameObject.activeSelf)
                {
                    Show();
                }
                else
                {
                    OnShow();    
                }
                
            }
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }
        
        public void ShowHide(bool isActive)
        {
            if (isActive)
            {
                Show();
                return;
            }
            
            Hide();
        }
        
        public virtual void Init() { }
        
        protected virtual void OnShow() { }
        
        protected virtual void OnHide() { }
    }
}