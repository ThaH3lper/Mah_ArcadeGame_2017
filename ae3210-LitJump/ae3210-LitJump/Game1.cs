using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ae3210_LitJump {

    public class Game1 : Game {
#if (!ARCADE)
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
#else
		public override string GameDisplayName { get { return "ae3210-LitJump"; } }
#endif
        public Game1() {
#if (!ARCADE)
            graphics = new GraphicsDeviceManager(this);
#endif
        }

        protected override void Initialize() {
            Content.RootDirectory = "Content";

            ScreenManager.AddScreen("load", new LoadingScreen());
            ScreenManager.AddScreen("game", new GameScreen());

            ScreenManager.SetCurrentScreen("load");
            ScreenManager.graphicDevice = GraphicsDevice;

            base.Initialize();
        }

        protected override void LoadContent() {
#if (!ARCADE)
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
#endif
            ContentManager.AddTexture("pixel", Content.Load<Texture2D>("pixel"));
            ContentManager.AddTexture("abutton", Content.Load<Texture2D>("abuttons"));
            ContentManager.AddTexture("dog", Content.Load<Texture2D>("dog"));
            ContentManager.AddTexture("eyebrow", Content.Load<Texture2D>("eyebrow"));
            ContentManager.AddTexture("ground", Content.Load<Texture2D>("ground"));
            ContentManager.AddTexture("poop", Content.Load<Texture2D>("poop"));
            ContentManager.AddTexture("top", Content.Load<Texture2D>("top"));
            ContentManager.AddTexture("particle", Content.Load<Texture2D>("particle"));
            ContentManager.AddTexture("bg", Content.Load<Texture2D>("bg"));
            ContentManager.AddTexture("chain", Content.Load<Texture2D>("chain"));
            ContentManager.AddTexture("glass", Content.Load<Texture2D>("glass"));
            ContentManager.AddTexture("gun", Content.Load<Texture2D>("gun"));
            ContentManager.AddTexture("control", Content.Load<Texture2D>("control"));
            ContentManager.AddTexture("plank", Content.Load<Texture2D>("plank"));
            ContentManager.AddTexture("logo", Content.Load<Texture2D>("steak_arts_mega"));

            ContentManager.AddTexture("jointxt", Content.Load<Texture2D>("jointxt"));
            ContentManager.AddTexture("restarttxt", Content.Load<Texture2D>("restarttxt"));
            ContentManager.AddTexture("starttxt", Content.Load<Texture2D>("starttxt"));
            ContentManager.AddTexture("tutorialtxt", Content.Load<Texture2D>("tutorialtxt"));
            ContentManager.AddTexture("webtxt", Content.Load<Texture2D>("webtxt"));
            ContentManager.AddTexture("wintxt", Content.Load<Texture2D>("wintxt"));

            ContentManager.AddSound("uzi", Content.Load<SoundEffect>("uzi"));
            ContentManager.AddSound("win", Content.Load<SoundEffect>("win"));
            ContentManager.AddSound("bow", Content.Load<SoundEffect>("wistle"));
            ContentManager.AddSound("jump", Content.Load<SoundEffect>("jump"));
            ContentManager.AddSound("land", Content.Load<SoundEffect>("land"));
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime) {
#if (!ARCADE)
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
#endif
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ScreenManager.Update(time);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            ScreenManager.Render(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
