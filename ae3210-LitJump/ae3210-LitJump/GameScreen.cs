using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class GameScreen : BaseScreen{

        World world;
        InputController inputController;
        JoinOverlay joinOverlay;

        bool joinScreen = true;

        public GameScreen() {
            world = new World();
            inputController = new InputController(world);
            joinOverlay = new JoinOverlay();
        }
        public void Hide() {

        }

        public void Render(SpriteBatch spriteBatch) {
            world.Render(spriteBatch);
            if (joinScreen) {
                joinOverlay.Render(spriteBatch);
                inputController.Render(spriteBatch);
            }
        }

        public void Show() {

        }

        public void Update(float delta) {
            inputController.Update();
            world.Update(delta);
            if (joinScreen)
                joinOverlay.Update(delta);
        }
    }
}
