using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump.Object {
    class MovingObject : Box{

        public static float SPEED = 400f;
        private static float ORGINAL_SPEED = 400;
        public MovingObject() : base(0, 0, 10, 10, Color.White, "plank"){
            drawBox.Width = ContentManager.R.Next(1, 5) * 40 - 3;
            drawBox.Height = ContentManager.R.Next(50, 180);
            sourceBox.Width = drawBox.Width;
            sourceBox.Height = drawBox.Height;
            drawBox.X = ContentManager.SCREEN_WIDTH;

            if (SPEED >= 1200 && ContentManager.R.Next(1, 10) > 7)
            {
                drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height - 100;
            }
            else
            {
                drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height;
            }
        }

        public override void Update(float delta) {
            drawBox.X -= (int)(delta * SPEED);
        }

        public static void Clear() {
            SPEED = ORGINAL_SPEED; 
        }
    }
}
