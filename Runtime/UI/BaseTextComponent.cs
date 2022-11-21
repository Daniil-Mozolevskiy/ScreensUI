using TMPro;
using UnityEngine;

namespace WalloutStudio.Screens.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BaseTextComponent : BaseComponent
    {
        [SerializeField] protected TextMeshProUGUI Component;

        public virtual void SetText(string text)
        {
            Component.text = text;
        }

        private void OnValidate()
        {
            if (Component == null)
            {
                Component = GetComponent<TextMeshProUGUI>();
            }
        }
    }
}