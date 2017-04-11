using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class ParticleManager {

        List<Box> particles = new List<Box>();
        List<Box> deadParticles = new List<Box>();
        public ParticleManager() {

        }

        public void SpawnUp(Vector2 position)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 velocity = new Vector2((float)(ContentManager.R.NextDouble() * 2f) - 1f, (float)(ContentManager.R.NextDouble() * 0.5f) - 1f);
                particles.Add(new Particle(position, velocity));
            }
        }

        public void Update(float delta)
        {
            foreach (Particle p in particles)
            {
                p.Update(delta);
                if (p.IsDead())
                    deadParticles.Add(p);
            }
            foreach (Particle p in deadParticles)
                particles.Remove(p);
            deadParticles.Clear();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (Particle p in particles)
                p.Render(spriteBatch);
        }
    }
}
