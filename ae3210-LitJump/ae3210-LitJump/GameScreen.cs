using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class GameScreen : BaseScreen{

        Box floor;
        Hero hero;
        public GameScreen() {
            floor = new Box(0, ContentManager.SCREEN_HEIGHT - 100, ContentManager.SCREEN_WIDTH, 100, Color.Red);
            hero = new Hero(new Vector2(ContentManager.SCREEN_WIDTH/2, ContentManager.SCREEN_HEIGHT/2));
        }
        public void Hide() {
        }

        public void Render(SpriteBatch spriteBatch) {
            floor.Render(spriteBatch);
            hero.Render(spriteBatch);
        }

        public void Show() {
        }

        public void Update(float delta) {
            hero.Update(delta);
        }
    }
}
