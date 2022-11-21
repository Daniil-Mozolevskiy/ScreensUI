using System;
using UnityEngine;

namespace WalloutStudio.Screens.UI
{
    public class BaseComponent : MonoBehaviour
    {
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake() { }

        public virtual void Init() { }
    }
}