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

        public Hero(Vector2 position) : base(0, 0, 64, 64, Color.Green) {
            this.position = position;
        }

        public void Update(float delta) {

            velocity = velocity + GRAVITY * delta;
            position.Y += velocity;
            if (position.Y >= ContentManager.SCREEN_HEIGHT - 100) {
                velocity = 0;
                position.Y = ContentManager.SCREEN_HEIGHT - 100;
            }
            Console.WriteLine(velocity + " ");

            if (InputHandler.GetButtonState(PlayerIndex.One, PlayerInput.A) == InputState.Pressed) {
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
