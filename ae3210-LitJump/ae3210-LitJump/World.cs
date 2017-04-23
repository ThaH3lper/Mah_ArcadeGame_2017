using ae3210_LitJump.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ae3210_LitJump {
    class World {

        List<Hero> heroes = new List<Hero>();
        List<Hero> deleteHeros = new List<Hero>();
        List<Box> gameObjects = new List<Box>();

        int players = 0;
        float slowmotion;
        Box clearScreen, top, bg;
        bool gameStarted;

        float slowmotionTime;

        float INTERVAL = 3, current = 0;

        public ParticleManager particleManager;

        public Dog dog;
        public Poop poop;
        private GameScreen screen;

        public World(GameScreen screen) {
            this.screen = screen;
            bg = new Box(0, 0, ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT, Color.White, "bg");
            gameObjects.Add(new Box(0, ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT, ContentManager.SCREEN_WIDTH, ContentManager.FLOOR_HEIGHT, Color.White, "ground"));
            top = new Box(0, ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - 48, ContentManager.SCREEN_WIDTH, 48, Color.White, "top");
            clearScreen = new Box(0, 0, ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT, Color.FromNonPremultiplied(255, 255, 255, 50));
            slowmotion = 1f;
            dog = new Dog();
            poop = new Poop();
            particleManager = new ParticleManager();
        }

        public void Update(float delta) {

            //if (slowmotionTime > 0) {
            //    slowmotion = 0.3f;
            //    slowmotionTime -= delta;
            //} else
            //    slowmotion = 1f;

            //delta *= slowmotion;
            if (dog.GetState() == DogState.FLY_AWAY || dog.GetState() == DogState.IDLE) {
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

            foreach (Hero h in heroes) {
                h.IsColliding();
                if (h.IsDead())
                    deleteHeros.Add(h);
            }
            foreach (Hero h in deleteHeros) {
                heroes.Remove(h);
                if (heroes.Count == 0) {
                    GameOver(h);
                }
            }
            deleteHeros.Clear();

            dog.Update(delta);
            poop.Update(delta);
            particleManager.Update(delta);
        }

        private void GameOver(Hero hero) {
            screen.ClearControllers();
            players = 0;
            MovingObject.Clear();
            poop.Start(hero.GetBilBoard(), Restart);
        }

        public void Restart()
        {
            dog.setNextState(DogState.SLIDE_IN);
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

            bg.Render(spriteBatch);
            foreach (Hero h in heroes)
                h.Render(spriteBatch);
            foreach (Box b in gameObjects)
                b.Render(spriteBatch);

            if (dog.GetState() != DogState.SLIDE_IN &&
                dog.GetState() != DogState.EYEBROW &&
                dog.GetState() != DogState.SLIDE_OUT) {
                dog.Render(spriteBatch);
            }
            particleManager.Render(spriteBatch);
            top.Render(spriteBatch);
            if(dog.GetState() == DogState.SLIDE_IN ||
                dog.GetState() == DogState.EYEBROW ||
                dog.GetState() == DogState.SLIDE_OUT) {
                dog.Render(spriteBatch);
            }
            poop.Render(spriteBatch);
        }

        public void AddPlayer(PlayerIndex pindex, PlayerInput pinput) {
            heroes.Add(new Hero(this, new Vector2(100 + players * 70, ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - 150), pindex, pinput));
            dog.Pooping(100 + players * 70);
            players++;
        }
    }
}
