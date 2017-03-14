using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    interface BaseScreen {

        void Show();

        void Hide();

        void Update(float delta);

        void Render(SpriteBatch spriteBatch);
    }
}
