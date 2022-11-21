using WalloutStudio.Screens.Controllers;

namespace WalloutStudio.Screens.UI
{
    public class BaseScreen : BaseController
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