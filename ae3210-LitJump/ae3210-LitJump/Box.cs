using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ae3210_LitJump {
    class Box {

        protected Color color;
        protected Rectangle drawBox;
        protected Rectangle sourceBox;
        protected string texture;

        public Box(int x, int y, int width, int height, Color color) {
            drawBox = new Rectangle(x, y, width, height);
            sourceBox = drawBox;
            this.color = color;
            texture = "pixel";
        }

        public Box(int x, int y, int width, int height, Color color, string texture) {
            drawBox = new Rectangle(x, y, width, height);
            sourceBox = drawBox;
            this.color = color;
            this.texture = texture;
        }

        public virtual void Update(float delta) {

        }

        public Rectangle getDrawBox() {
            return drawBox;
        }

        public void SetTexture(string texture) {
            this.texture = texture;
        }

        public void SetSourceBox(Rectangle rec) {
            sourceBox = rec;
        }

        public virtual void Render(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentManager.GetTexture(texture), drawBox, sourceBox, color);
        }
    }
}
