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
            spriteBatch.Draw(ContentManager.GetTexture("logo"), new Rectangle(ContentManager.SCREEN_WIDTH/2 - 1407/2, 
                ContentManager.SCREEN_HEIGHT/2 - 329/2, 1407, 329), Color.White);
        }

        public void Show() {
        }

        public void Update(float delta) {
            currentTime += delta;
            if (currentTime >= 3.5f)
                ScreenManager.SetCurrentScreen("game");
        }
    }
}
