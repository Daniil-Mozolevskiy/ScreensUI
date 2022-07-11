using UnityEngine.UI;

namespace WalloutStudio.Screens.UI
{
    public class BaseSliderComponent : BaseComponent
    {
        public Slider SliderComponent;

        public void SetValue(float value)
        {
            SliderComponent.value = value;
        }

        public float GetValue()
        {
            return SliderComponent.value;
        }
    }
}