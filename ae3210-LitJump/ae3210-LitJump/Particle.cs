using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class Particle : Box {

        private static int size = 10;

        float lifeTime = 0.2f, opacityFade = 4;
        Vector2 velocity, position;
        float speed;
        float opacity;

        public Particle(Vector2 position, Vector2 velocity) : base(0, 0, size, size, Color.White, "particle") {
            opacity = 1f;
            speed = (float)(ContentManager.R.NextDouble() * 50) + 100;
            this.velocity = velocity;
            this.position = position;
        }

        public override void Update(float delta) {
            base.Update(delta);

            position.X += velocity.X * delta * speed;
            position.Y += velocity.Y * delta * speed;

            drawBox.X = (int)position.X;
            drawBox.Y = (int)position.Y;

            lifeTime -= delta;
            if(lifeTime < 0)
            {
                opacity -= delta * opacityFade;
                color.A = (byte)(opacity * 255);
            }
            
        }

        public bool IsDead() { return (opacity < 0); }
    }
}
