using TMPro;

namespace WalloutStudio.Screens.UI
{
    public class BaseTextComponent : BaseComponent
    {
        public TextMeshProUGUI TextComponent;

        public void SetText(string text)
        {
            TextComponent.text = text;
        }
    }
}