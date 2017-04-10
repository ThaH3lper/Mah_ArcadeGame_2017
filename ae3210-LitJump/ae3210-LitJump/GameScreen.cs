using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class GameScreen : BaseScreen{

        World world;
        InputController inputController;
        JoinOverlay joinOverlay;

        public GameScreen() {
            world = new World(this);
            inputController = new InputController(world);
            joinOverlay = new JoinOverlay();
        }
        public void Hide() {

        }

        public void Render(SpriteBatch spriteBatch) {
            world.Render(spriteBatch);
            if (world.dog.GetState() == DogState.POOPING) {
                joinOverlay.Render(spriteBatch);
                inputController.Render(spriteBatch);
            }
        }

        public void Show() {

        }

        public void ClearControllers() {
            inputController.Clear();
        }

        public void Update(float delta) {
            world.Update(delta);
            if (InputHandler.GetButtonState(PlayerIndex.One, PlayerInput.Start) == InputState.Pressed) {
                world.dog.setNextState(DogState.FLY_AWAY);
            }
            if (world.dog.GetState() == DogState.POOPING) {
                joinOverlay.Update(delta);
                inputController.Update();
            }
        }
    }
}
