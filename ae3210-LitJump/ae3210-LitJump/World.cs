using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ae3210_LitJump {
    class World {

        List<Hero> heroes = new List<Hero>();
        List<Box> gameObjects = new List<Box>();

        int players = 0;
        float slowmotion;
        Box clearScreen;

        public World() {
            gameObjects.Add(new Box(0, ContentManager.SCREEN_HEIGHT - 100, ContentManager.SCREEN_WIDTH, 100, Color.Red));
            clearScreen = new Box(0, 0, ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT, Color.FromNonPremultiplied(255, 255, 255, 50));
        }

        public void Update(float delta) {
            foreach (Hero h in heroes)
                h.Update(delta);

            foreach (Box b in gameObjects)
                b.Update(delta);

            foreach (Hero h in heroes)
                h.IsColliding();

            if (InputHandler.GetButtonState(PlayerIndex.One, PlayerInput.Start) == InputState.Down)
                slowmotion = 0.3f;
            else
                slowmotion = 1f;

        }

        public bool IsColliding(Rectangle rec, ref Rectangle collide) {
            foreach (Box b in gameObjects) {
                if (b.getDrawBox().Intersects(rec)) {
                    collide = b.getDrawBox();
                    return true;
                }
            }                
            return false;
        }

        public void Render(SpriteBatch spriteBatch) {
            if (slowmotion == 1.0f) {
                ScreenManager.graphicDevice.Clear(Color.White);
            } else
                clearScreen.Render(spriteBatch);
            foreach (Hero h in heroes)
                h.Render(spriteBatch);
            foreach (Box b in gameObjects)
                b.Render(spriteBatch);
        }

        public void AddPlayer(PlayerIndex pindex, PlayerInput pinput) {
            heroes.Add(new Hero(this, new Vector2(100 + players * 70, 100), pindex, pinput));
            players++;
        }
    }
}
