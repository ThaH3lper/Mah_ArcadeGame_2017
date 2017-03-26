using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class Particle : Box {

        private static int size = 10;

        float lifeTime = 3;

        public Particle() : base(0, 0, size, size, Color.Green) {

        }

        public override void Update(float delta) {
            base.Update(delta);

            lifeTime -= delta;
            
        }

        public bool IsDead() { return (lifeTime < 0); }
    }
}
