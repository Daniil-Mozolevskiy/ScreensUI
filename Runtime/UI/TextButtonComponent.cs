namespace WalloutStudio.Screens.UI
{
    public class TextButtonComponent : BaseButtonComponent
    {
        public BaseTextComponent TextComponent;

        public void SetText(string text)
        {
            TextComponent.SetText(text);
        }
    }
}