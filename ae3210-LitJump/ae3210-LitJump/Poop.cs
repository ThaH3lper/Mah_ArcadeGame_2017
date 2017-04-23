using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump
{


    class Poop
    {
        public enum State
        {
            NONE,
            FADE_IN,
            ROTATE_FIRE,

        }

        public delegate void RestartCallback();
        RestartCallback callback;

        State currentState;
        Box poop, chain, glass;

        Gun gun1, gun2;
        float fireDelay;

        int SIZE = 200;
        int SPEED = 1000;

        Box winHeroBilBoard;

        public Poop()
        {
            poop = new Box(0, 0, SIZE, SIZE, Color.White, "poop");
            poop.SetSourceBox(new Rectangle(0, 0, 100, 100));

            chain = new Box(0, 0, SIZE, (int)(SIZE * 1.5f), Color.White, "chain");
            chain.SetSourceBox(new Rectangle(0, 0, 100, 150));

            glass = new Box(0, 0, SIZE, (int)(SIZE * 1.5f), Color.White, "glass");
            glass.SetSourceBox(new Rectangle(0, 0, 100, 150));
            gun1 = new Gun(SpriteEffects.None);
            gun2 = new Gun(SpriteEffects.FlipHorizontally);

        }

        public void SetState(State state)
        {
            LeaveState(currentState);
            currentState = state;
            EnterState(currentState);
        }

        public void EnterState(State state)
        {
            switch (currentState)
            {
                case State.FADE_IN:
                    poop.SetDrawBoxPos(ContentManager.SCREEN_WIDTH/2 - SIZE / 2, ContentManager.SCREEN_HEIGHT/ 2 - (int)(SIZE * 1.5) / 2 - 1000);
                    chain.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - SIZE / 2 - 1000, ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 1.5) / 2);
                    glass.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - SIZE / 2 + 1000, ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 1.5) / 2);
                    break;
            }
        }

        public void LeaveState(State state)
        {
            switch (currentState)
            {
                case State.FADE_IN:
                    poop.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - SIZE / 2, ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 1.5) / 2);
                    chain.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - SIZE / 2, ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 1.5) / 2);
                    glass.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - SIZE / 2, ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 1.5) / 2);
                    break;
            }
        }

        public void Update(float delta)
        {
            switch (currentState)
            {
                case State.FADE_IN:
                    poop.SetDrawBoxPos(poop.getDrawBox().X, (int)(poop.getDrawBox().Y + SPEED * delta));
                    chain.SetDrawBoxPos((int)(chain.getDrawBox().X + SPEED * delta), chain.getDrawBox().Y);
                    glass.SetDrawBoxPos((int)(glass.getDrawBox().X - SPEED * delta), glass.getDrawBox().Y);
                    if (poop.getDrawBox().Y > ContentManager.SCREEN_HEIGHT / 2 - (int)(SIZE * 2) / 2)
                        SetState(State.ROTATE_FIRE);
                    break;
                case State.ROTATE_FIRE:
                    fireDelay -= delta;
                    if(fireDelay <= 0)
                    {
                        fireDelay = (float)ContentManager.R.NextDouble() * 0.5f + 0.3f;
                        gun1.Fire();
                        gun2.Fire();
                        ContentManager.GetSound("uzi").Play();
                    }
                    gun1.Update(delta);
                    gun2.Update(delta);
                    if(InputHandler.GetButtonState(PlayerIndex.One, PlayerInput.Start) == InputState.Pressed)
                    {
                        SetState(State.NONE);
                        callback();
                    }
                    break;
            }
        }

        public void Start(Box bilBoard, RestartCallback callback)
        {
            this.callback = callback;
            winHeroBilBoard = bilBoard;
            winHeroBilBoard.SetDrawBoxSize(200, 60);
            winHeroBilBoard.SetDrawBoxPos(ContentManager.SCREEN_WIDTH / 2 - 100, ContentManager.SCREEN_HEIGHT / 2 + 130);
            ContentManager.GetSound("win").Play();
            SetState(State.FADE_IN);
        }

        public void Render(SpriteBatch spriteBatch)
        {

            if (currentState == State.ROTATE_FIRE)
            {
                winHeroBilBoard.Render(spriteBatch);
                gun1.Render(spriteBatch);
                gun2.Render(spriteBatch);
            }

            if (currentState != State.NONE)
            {
                poop.Render(spriteBatch);
                chain.Render(spriteBatch);
                glass.Render(spriteBatch);
            }
        }
    }
}
