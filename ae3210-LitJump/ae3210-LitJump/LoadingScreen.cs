using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ae3210_LitJump {
    class LoadingScreen : BaseScreen {
        float currentTime;
        public void Hide() {
        }

        public void Render(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentManager.GetTexture("pixel"), new Rectangle(0, 0, 100, 100), Color.Red);
        }

        public void Show() {
        }

        public void Update(float delta) {
            currentTime += delta;
            if (currentTime >= 1f)
                ScreenManager.SetCurrentScreen("game");
        }
    }
}
