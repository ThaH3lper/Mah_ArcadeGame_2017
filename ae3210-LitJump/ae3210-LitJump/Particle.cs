using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class Particle : Box {

        private static int Defaultsize = 10;

        protected float lifeTime = 0.1f, opacityFade = 4;
        Vector2 velocity, position;
        float speed;
        float opacity;
        bool under;
        public Particle(Vector2 position, Vector2 velocity, bool under) : base(0, 0, Defaultsize, Defaultsize, Color.White, "particle")
        {
            opacity = 1f;
            speed = (float)(ContentManager.R.NextDouble() * 50) + 200;
            this.velocity = velocity;
            this.position = position;
            this.under = under;
        }

        public Particle(Vector2 position, Vector2 velocity, bool under, int newSize) : base(0, 0, newSize, newSize, Color.White, "particle") {
            opacity = 1f;
            speed = (float)(ContentManager.R.NextDouble() * 50) + 200;
            this.velocity = velocity;
            this.position = position;
            this.under = under;
        }

        public bool isUnder()
        {
            return under;
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
                color = new Color(Color.White.ToVector4()) * opacity;
            }
            
        }

        public bool IsDead() { return (opacity < 0); }
    }
}
