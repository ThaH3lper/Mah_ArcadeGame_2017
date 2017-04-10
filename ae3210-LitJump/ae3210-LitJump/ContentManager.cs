using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class ContentManager {

        public static int SCREEN_WIDTH = 1920;
        public static int SCREEN_HEIGHT = 1080;
        public static int FLOOR_HEIGHT = 188;

        public static Random R = new Random();

        public static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static void AddTexture(string key, Texture2D texture) {
            textures.Add(key, texture);
        }
        public static Texture2D GetTexture(string key) {
            Texture2D temp = null;
            textures.TryGetValue(key, out temp);
            return temp;
        }
    }
}
