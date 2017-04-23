using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump
{
    class Gun
    {

        Rectangle recDraw, recSource;
        Vector2 offset;
        float rotation;
        string texture = "gun";
        SpriteEffects effect;
        float currentTime;
        float fireDelay;
        bool fire;
        Box flash;

        public Gun(SpriteEffects effect)
        {
            this.effect = effect;
            if(effect == SpriteEffects.FlipHorizontally)
            {
                offset = new Vector2(400 - 307, 113f);
                recDraw = new Rectangle(ContentManager.SCREEN_WIDTH / 2 + 100, ContentManager.SCREEN_HEIGHT / 2, 400, 233);
            } else
            {
                recDraw = new Rectangle(ContentManager.SCREEN_WIDTH/2 - 100, ContentManager.SCREEN_HEIGHT /2, 400, 233);
                offset = new Vector2(307, 113);
            }
            recSource = new Rectangle(0, 233, 400, 233);
            flash = new Box(0, 0, ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT, Color.Yellow);
            flash.SetOpacity(0);
        }

        public void Fire()
        {
            fireDelay = 0.1f;
            fire = true;
            recSource = new Rectangle(0, 0, 400, 233);
            if (effect == SpriteEffects.FlipHorizontally)
            {
                flash.SetOpacity(fireDelay * 5);
            }
        }

        public void Update(float delta)
        {
            currentTime += delta;
            if (effect == SpriteEffects.FlipHorizontally)
            {
                rotation = (float)(Math.Sin((currentTime + 1) * 3f) * 0.4f);
            }
            else
            {
                rotation = (float)(Math.Sin(currentTime * 3f) * 0.4f);
            }

            if (fireDelay <= 0 && fire)
            {
                fire = false;
                fireDelay = 0;
                flash.SetOpacity(0); 
                recSource = new Rectangle(0, 233, 400, 233);
            }
            else if (fire)
            {
                flash.SetOpacity(fireDelay * 5);
                fireDelay -= delta;
            }
        }

        public void Render(SpriteBatch spriteBatch)
        {
            flash.Render(spriteBatch);
            spriteBatch.Draw(ContentManager.GetTexture(texture), recDraw, recSource, Color.White, rotation, offset, effect, 1.0f);
        }
        
    }
}
