using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    public enum DogState{
        IDLE,
        SLIDE_IN,
        EYEBROW,
        SLIDE_OUT,
        SLIDE_IN_TO_START,
        POOPING,
        FLY_AWAY

    }

    public class Dog {

        private DogState currentState;

        private Box dog;
        private Box eyebrow;

        private Vector2 EYE_BROW_OFFSET;
        float eye_brow_delta;

        float currnetTime;

        public Dog() {
            dog = new Box(ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT - 450, 715, 758, Color.White, "dog");
            eyebrow = new Box(0, 0, 44, 25, Color.White, "eyebrow");
            EYE_BROW_OFFSET = new Vector2(255, 43);
            currentState = DogState.IDLE;
            setNextState(DogState.SLIDE_IN);
        }

        public void setNextState(DogState state) {
            LeaveState(state);
            currentState = state;
            EnterState(state);      
        }

        public DogState GetState() {
            return currentState;
        }

        private void EnterState(DogState state) {
            switch (currentState) {
                case DogState.EYEBROW:
                    ContentManager.GetSound("bow").Play();
                    currnetTime = 0;
                    break;
                case DogState.SLIDE_IN_TO_START:
                    dog.SetDrawBoxPos(dog.getDrawBox().X, ContentManager.SCREEN_HEIGHT - dog.getDrawBox().Height - ContentManager.FLOOR_HEIGHT + 10);
                    dog.SetEffect(SpriteEffects.FlipHorizontally);
                    eyebrow.SetEffect(SpriteEffects.FlipHorizontally);
                    EYE_BROW_OFFSET = new Vector2(dog.getDrawBox().Width - 255 - eyebrow.getDrawBox().Width, 43);
                    break;
                case DogState.POOPING:
                    Pooping(0);
                    break;
                case DogState.SLIDE_IN:
                    EYE_BROW_OFFSET = new Vector2(255, 43);
                    dog.SetEffect(SpriteEffects.None);
                    eyebrow.SetEffect(SpriteEffects.None);
                    dog.SetDrawBoxPos(ContentManager.SCREEN_WIDTH, ContentManager.SCREEN_HEIGHT - 450);
                    break;
            }
        }

        private void LeaveState(DogState state) {
            switch (currentState) {
                case DogState.EYEBROW:
                    eye_brow_delta = 0;
                    break;
            }
        }
        public void Pooping(int amount) {
            dog.SetDrawBoxPos((int)(amount - 150), (int)(dog.getDrawBox().Y));
        }

        public void Update(float delta) {

            switch (currentState) {
                case DogState.SLIDE_IN:
                    dog.SetDrawBoxPos((int)(dog.getDrawBox().X - delta * 1000), (int)(dog.getDrawBox().Y));
                    if (dog.getDrawBox().X < ContentManager.SCREEN_WIDTH / 2 - 300)
                        setNextState(DogState.EYEBROW);
                    break;
                case DogState.EYEBROW:
                    eye_brow_delta = (float)Math.Sin(currnetTime * 50) * 10f;
                    currnetTime += delta;
                    if (currnetTime > 1.4f)
                        setNextState(DogState.SLIDE_OUT);
                    break;
                case DogState.SLIDE_OUT:
                    dog.SetDrawBoxPos((int)(dog.getDrawBox().X - delta * 1000), (int)(dog.getDrawBox().Y));
                    if (dog.getDrawBox().X < 0 - dog.getDrawBox().Width)
                        setNextState(DogState.SLIDE_IN_TO_START);
                    break;
                case DogState.SLIDE_IN_TO_START:
                    dog.SetDrawBoxPos((int)(dog.getDrawBox().X + delta * 1000), (int)(dog.getDrawBox().Y));
                    if (dog.getDrawBox().X > -150)
                        setNextState(DogState.POOPING);
                    break;
                case DogState.POOPING:
                    if (World.oneJoined && (InputHandler.GetButtonState(PlayerIndex.One, PlayerInput.Start) == InputState.Pressed ||
                       InputHandler.GetButtonState(PlayerIndex.Two, PlayerInput.Start) == InputState.Pressed))
                    {
                        setNextState(DogState.FLY_AWAY);
                    }
                    break;
                case DogState.FLY_AWAY:
                    dog.SetDrawBoxPos((int)(dog.getDrawBox().X + delta * 3000), (int)(dog.getDrawBox().Y));
                    if (dog.getDrawBox().X > ContentManager.SCREEN_WIDTH)
                        setNextState(DogState.IDLE);
                    break;
            }
            eyebrow.SetDrawBoxPos((int)(dog.getDrawBox().X + EYE_BROW_OFFSET.X), (int)(dog.getDrawBox().Y + EYE_BROW_OFFSET.Y + eye_brow_delta));
        }

        public void Render(SpriteBatch spriteBatch) {
            dog.Render(spriteBatch);
            eyebrow.Render(spriteBatch);
        }
    }
}
