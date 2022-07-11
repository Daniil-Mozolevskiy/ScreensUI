using System.Collections.Generic;
using UnityEngine;

namespace WalloutStudio.Screens.UI
{
    public class BaseScreenManager : MonoBehaviour
    {
        protected static BaseScreenManager instance;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private List<BaseScreen> screens = new();

        private readonly List<BaseScreen> instantiatedScreens = new();
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            
            DontDestroyOnLoad(canvas);
        }

        public static void UpdateCanvas()
        {
            var cameraComponent = FindObjectOfType<Camera>();
            instance.canvas.worldCamera = cameraComponent;
        }
        
        public void ShowScreen<T>(BaseScreenParameters parameters = null, BaseComponent hideCurrent = null) where T : BaseScreen
        {
            if (hideCurrent)
            {
                hideCurrent.Hide();
            }

            var targetScreen = instantiatedScreens.Find(screen => screen is T);

            if (targetScreen == null)
            {
                var targetScreenPrefab = screens.Find(screen => screen is T);
                targetScreen = Instantiate(targetScreenPrefab, canvas.transform);
                instantiatedScreens.Add(targetScreen);
            }

            if (parameters != null)
            {
                targetScreen.OnParameterPass(parameters);
            }
                    
            targetScreen.Show();
            targetScreen.Init();
        }
        
        public void HideScreen<T>() where T : BaseScreen
        {
            var targetScreen = instantiatedScreens.Find(screen => screen is T);

            if (targetScreen == null) return;
            
            targetScreen.Hide();
        }
        
        public static BaseScreen GetInstantiatedScreenByType<T>() where T : BaseScreen
        {
            return instance.GetInstantiatedScreenByType_INTERNAL<T>();
        }

        private BaseScreen GetInstantiatedScreenByType_INTERNAL<T>() where T : BaseScreen
        {
            return instantiatedScreens.Find(screen => screen is T);
        }
    }
}