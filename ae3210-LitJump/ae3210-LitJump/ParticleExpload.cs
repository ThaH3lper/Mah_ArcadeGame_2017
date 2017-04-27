using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump
{
    class ParticleExpload : Particle
    {
        public ParticleExpload(Vector2 position, Vector2 velocity, bool under) : base(position, velocity, under, 20)
        {
            lifeTime = 0.3f;
            opacityFade = 3;
            sourceBox = new Rectangle(0, 0, 10, 10);
        }
    }
}
