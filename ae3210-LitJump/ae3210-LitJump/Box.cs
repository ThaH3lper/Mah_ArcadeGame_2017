using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ae3210_LitJump {
    class Box {

        protected Color color;
        protected Rectangle drawBox;
        protected Rectangle sourceBox;
        protected string texture;
        protected Vector2 origin;
        protected SpriteEffects effect;

        public Box(int x, int y, int width, int height, Color color) {
            drawBox = new Rectangle(x, y, width, height);
            sourceBox = new Rectangle(0, 0, width, height);
            this.color = color;
            texture = "pixel";
            origin = new Vector2(0, 0);
            effect = SpriteEffects.None;
        }

        public Box(int x, int y, int width, int height, Color color, string texture) {
            drawBox = new Rectangle(x, y, width, height);
            sourceBox = new Rectangle(0, 0, width, height);
            origin = new Vector2(0, 0);
            this.color = color;
            this.texture = texture;
            effect = SpriteEffects.None;
        }

        public virtual void Update(float delta) {

        }

        public void SetDrawBoxPos(int x, int y) {
            drawBox.X = x;
            drawBox.Y = y;
        }

        public Rectangle getDrawBox() {
            return drawBox;
        }

        public void SetEffect(SpriteEffects effect) {
            this.effect = effect;
        }

        public void SetTexture(string texture) {
            this.texture = texture;
        }

        public void SetSourceBox(Rectangle rec) {
            sourceBox = rec;
        }

        public virtual void Render(SpriteBatch spriteBatch) {
            spriteBatch.Draw(ContentManager.GetTexture(texture), drawBox, sourceBox, color, 0f, origin, effect, 0f);
        }
    }
}
