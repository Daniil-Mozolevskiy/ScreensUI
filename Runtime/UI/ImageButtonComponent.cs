using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WalloutStudio.Screens.UI
{
    public class ImageButtonComponent : BaseButtonComponent
    {
        [Serializable]
        public class ImageTheme
        {
            public Graphic Graphic;
            public Color BlockColor;
            public Color UnblockColor;
        }

        [SerializeField] private List<ImageTheme> interactableObjects;

        public override void Block()
        {
            base.Block();

            foreach (var obj in interactableObjects)
            {
                obj.Graphic.color = obj.BlockColor;
            }
        }

        public override void Unblock()
        {
            base.Unblock();
            
            foreach (var obj in interactableObjects)
            {
                obj.Graphic.color = obj.UnblockColor;
            }
        }
    }
}