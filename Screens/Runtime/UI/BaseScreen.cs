namespace WalloutStudio.Screens.UI
{
    public class BaseScreen : BaseComponent
    {
        private BaseScreenParameters parameters;

        public virtual void OnParameterPass(BaseScreenParameters parameters)
        {
            this.parameters = parameters;
        }

        protected override void OnHide()
        {
            parameters?.OnHide?.Invoke();
        }
    }
}