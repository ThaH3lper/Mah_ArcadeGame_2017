using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ae3210_LitJump {
    class Hero : Box{
        float GRAVITY = 50;
        int WIDTH = 64, HEIGHT = 64;
        Vector2 position;
        float velocity;

        World world;
        PlayerIndex playerIndex;
        PlayerInput playerInput;

        public Hero(World world, Vector2 position, PlayerIndex pindex, PlayerInput pinput) : base(0, 0, 64, 64, Color.Green) {
            this.world = world;
            this.position = position;
            playerIndex = pindex;
            playerInput = pinput;
        }

        public void Update(float delta) {

            //CheckY
            velocity = velocity + GRAVITY * delta;
            position.Y += velocity;

            drawBox.X = (int)(position.X - WIDTH / 2f);
            drawBox.Y = (int)(position.Y - HEIGHT);

            Rectangle result = new Rectangle();
            if(world.IsColliding(drawBox, ref result)) {
                position.Y = result.Top;
                velocity = 0;
            }

            if (InputHandler.GetButtonState(playerIndex, playerInput) == InputState.Pressed) {
                velocity = -25;
            }


            drawBox.X = (int)(position.X - WIDTH / 2f);
            drawBox.Y = (int)(position.Y - HEIGHT);
        }

        public override void Render(SpriteBatch spriteBatch) {
            base.Render(spriteBatch);
        }
    }
}
