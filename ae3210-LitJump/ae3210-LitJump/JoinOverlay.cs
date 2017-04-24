using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class JoinOverlay {

        Box join, tutorial, start;
        public JoinOverlay() {
            join = new Box(ContentManager.SCREEN_WIDTH/4 * 3 - 250, 20, 532, 82, Color.White, "jointxt");
            tutorial = new Box(ContentManager.SCREEN_WIDTH / 4 * 3 - (873 / 2), 300, 873, 262, Color.White, "tutorialtxt");
            start = new Box(ContentManager.SCREEN_WIDTH / 4 * 3 - (529 / 2), 650, 529, 75, Color.White, "starttxt");
        }

        public void Update(float delta) {
            
        }

        public void Render(SpriteBatch spriteBatch) {
            join.Render(spriteBatch);
            tutorial.Render(spriteBatch);
            if (World.oneJoined)
            {
                start.Render(spriteBatch);
            }
        }
    }
}
