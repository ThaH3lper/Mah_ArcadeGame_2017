using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class JoinOverlay {

        Box halfSide;
        public JoinOverlay() {
            halfSide = new Box(ContentManager.SCREEN_WIDTH / 2, 0, ContentManager.SCREEN_WIDTH / 2, ContentManager.SCREEN_HEIGHT, Color.Black);
        }

        public void Update(float delta) {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            //halfSide.Render(spriteBatch);
        }
    }
}
