using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump.Object {
    class MovingObject : Box{

        public static float SPEED = 300f;
        public MovingObject() : base(0, 0, 10, 10, Color.Red){
            drawBox.Width = ContentManager.R.Next(300, 400);
            drawBox.Height = ContentManager.R.Next(50, 200);
            drawBox.X = ContentManager.SCREEN_WIDTH;
            drawBox.Y = ContentManager.SCREEN_HEIGHT - ContentManager.FLOOR_HEIGHT - drawBox.Height;
        }

        public override void Update(float delta) {
            drawBox.X -= (int)(delta * SPEED);
        }
    }
}
