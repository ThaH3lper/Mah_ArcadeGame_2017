using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump.Object {
    class MovingObject : Box{

        public static float SPEED = 900f;
        private static float ORGINAL_SPEED = 900;
        private static int LAST_HEIGHT = 1;
        public MovingObject() : base(0, 0, 10, 10, Color.White, "plank"){
            drawBox.Width = ContentManager.R.Next(1, 5) * 40 - 3;
            drawBox.Height = ContentManager.R.Next(50, 180);
            sourceBox.Width = drawBox.Width;
            sourceBox.Height = drawBox.Height;
            drawBox.X = ContentManager.SCREEN_WIDTH;

            switch(ContentManager.R.Next(1, 6))
            {
                case 3:
                case 1:
                    drawBox.Width = 5 * 40 - 3;
                    drawBox.Height = 150 * LAST_HEIGHT;
                    sourceBox.Width = drawBox.Width;
                    drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height;
                    LAST_HEIGHT++;
                    if (LAST_HEIGHT >= 4)
                        LAST_HEIGHT = 3;
                    break;

                case 2:
                    drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height - 100;
                    LAST_HEIGHT = 1;
                    break;

                default:
                    drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height;
                    LAST_HEIGHT = 1;
                    break;
            }
        }

        public override void Update(float delta) {
            drawBox.X -= (int)(delta * SPEED);
        }

        public static void Clear() {
            SPEED = ORGINAL_SPEED;
            LAST_HEIGHT = 1;
        }
    }
}
