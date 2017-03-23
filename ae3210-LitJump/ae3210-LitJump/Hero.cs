using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ae3210_LitJump {
    class Hero : Box{
        float GRAVITY = 50;
        int WIDTH = 64, HEIGHT = 64;
        Vector2 position;
        float velocity;

        bool onGround;
        bool killed;

        World world;
        PlayerIndex playerIndex;
        PlayerInput playerInput;

        public Hero(World world, Vector2 position, PlayerIndex pindex, PlayerInput pinput) : base(0, 0, 64, 64, Color.Green) {
            this.world = world;
            this.position = position;
            playerIndex = pindex;
            playerInput = pinput;
        }

        public void IsColliding() {
            Rectangle result = new Rectangle();
            if (world.IsColliding(drawBox, ref result)) {
                killed = true;
            }
        }

        public void Update(float delta) {

            //CheckY
            velocity = velocity + GRAVITY * GRAVITY * delta;
            position.Y += velocity * delta;

            drawBox.X = (int)(position.X - WIDTH / 2f);
            drawBox.Y = (int)(position.Y - HEIGHT);

            Rectangle result = new Rectangle();
            if(world.IsColliding(drawBox, ref result)) {
                position.Y = result.Top;
                velocity = 0;
                onGround = true;
            } else if(velocity > 50){
                onGround = false;
            }

            //MoveX

            if (InputHandler.GetButtonState(playerIndex, playerInput) == InputState.Pressed && onGround) {
                velocity = -1200;
                onGround = false;
            }
            else if(InputHandler.GetButtonState(playerIndex, playerInput) == InputState.Pressed) {
                velocity += 1200;
            }

            drawBox.X = (int)(position.X - WIDTH / 2f);
            drawBox.Y = (int)(position.Y - HEIGHT);
        }

        public override void Render(SpriteBatch spriteBatch) {
            if (killed)
                return;
            base.Render(spriteBatch);
        }

        public bool IsDead() { return killed; }
    }
}
