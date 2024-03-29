using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WalloutStudio.Screens.UI;

namespace WalloutStudio.Screens.Managers
{
    public class BaseScreenManager : MonoBehaviour
    {
        protected static BaseScreenManager instance;

        public float AspectRation = 0.57f;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private CanvasScaler scaler;
        [SerializeField] private List<BaseScreen> screens = new();

        private readonly List<BaseScreen> instantiatedScreens = new();
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            if (instance == null)
            {
                instance = this;
                
                scaler.matchWidthOrHeight = GetScalerMatch();
                DontDestroyOnLoad(canvas);
            }
        }

        public static void UpdateCanvas()
        {
            var cameraComponent = FindObjectOfType<Camera>();
            instance.canvas.worldCamera = cameraComponent;
            instance.scaler.matchWidthOrHeight = instance.GetScalerMatch();
        }

        private float GetScalerMatch()
        {
            var ration = (float)Screen.width / Screen.height;
            return ration < AspectRation ? 0 : 1;
        }
        
        public void ShowScreen<T>(BaseScreenParameters parameters = null, BaseScreen hideCurrent = null) where T : BaseScreen
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

        public static void HideAll()
        {
            instance.HideAll_INTERNAL();
        }
        
        private void HideAll_INTERNAL()
        {
            foreach (var screen in instantiatedScreens)
            {
                if (!screen.gameObject.activeSelf) continue;
                
                screen.Hide();
            }
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