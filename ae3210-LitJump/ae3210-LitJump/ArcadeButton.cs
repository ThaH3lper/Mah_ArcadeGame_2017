using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class ArcadeButton : Box{

        bool activated = false;
        Color startColor;

        public ArcadeButton(Point postion, Color color) : base(postion.X - 32, postion.Y - 32, 64, 64, color) {
            SetTexture("abutton");
            SetSourceBox(new Rectangle(0, 0, 64, 64));
            startColor = color;
            this.color = startColor * 0.2f;
        }

        public void setActive(bool activated) {
            this.activated = activated;
            if (activated)
                color = startColor;
            else
                color = startColor * 0.2f;
        }

        public void Pressed() {
            sourceBox.X = 64;
        }

        public void Relesed() {
            sourceBox.X = 0;
        }

        public bool IsActivate() {
            return activated;
        }
    }
}
