using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class ScreenManager {

        static Dictionary<string, BaseScreen> screens = new Dictionary<string, BaseScreen>();

        static BaseScreen currentScreen;

        public static void AddScreen(string key, BaseScreen screen) {
            screens.Add(key, screen);
        }

        public static void SetCurrentScreen(string key) {
            if(currentScreen != null) {
                currentScreen.Hide();
            }
            screens.TryGetValue(key, out currentScreen);
            currentScreen.Show();
        }

        public static void Update(float delta) {
            if (currentScreen != null)
                currentScreen.Update(delta);
        }

        public static void Render(SpriteBatch spriteBatch) {
            if (currentScreen != null)
                currentScreen.Render(spriteBatch);
        }
    }
}
