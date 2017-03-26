using ae3210_LitJump.Object;
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
        bool gameStarted;

        float slowmotionTime;

        float INTERVAL = 3, current = 0;

        public World() {
            gameObjects.Add(new Box(0, ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT, ContentManager.SCREEN_WIDTH, ContentManager.FLOOR_HEIGHT, Color.Red));
            clearScreen = new Box(0, 0, ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT, Color.FromNonPremultiplied(255, 255, 255, 50));
            slowmotion = 1f;
        }

        public void Update(float delta) {

            if (slowmotionTime > 0) {
                slowmotion = 0.3f;
                slowmotionTime -= delta;
            } else
                slowmotion = 1f;

            delta *= slowmotion;
            if (gameStarted) {
                current += delta * MovingObject.SPEED / 300f;
                if (current > INTERVAL) {
                    current = 0;
                    gameObjects.Add(new MovingObject());
                    MovingObject.SPEED += 40;
                }
            }

            List<Hero> killed = new List<Hero>();
            foreach (Hero h in heroes) {
                h.Update(delta);
                if (h.IsDead()) {
                    killed.Add(h);
                    slowmotionTime = 5f;
                }       
            }
            foreach (Hero h in killed)
                heroes.Remove(h);
            killed.Clear();

            foreach (Box b in gameObjects)
            b.Update(delta);

            foreach (Hero h in heroes)
                h.IsColliding();
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

        public void StartGame() {
            gameStarted = true;
        }
    }
}
