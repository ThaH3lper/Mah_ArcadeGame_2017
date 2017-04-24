using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump {
    class InputController {


        /*
        *       Player 1    Player2
        *   A       0           6           
        *   B       1           7
        *   RED     2           8
        *   BLUE    3           9
        *   YELLOW  4           10
        *   GREEN   5           11
        */

        World world;
        ArcadeButton[] buttons = new ArcadeButton[12];

        Point player1buttons = new Point(ContentManager.SCREEN_WIDTH / 4 * 3 - 250, 150);
        Point player2buttons = new Point(ContentManager.SCREEN_WIDTH / 4 * 3 + 150, 150);

        bool activated = true;
        public InputController(World world) {
            this.world = world;
            init();
        }

        public void init() {
            buttons[4] = new ArcadeButton(player1buttons + new Point(0, +20 + 70), Color.Yellow);
            buttons[2] = new ArcadeButton(player1buttons + new Point(0, +20), Color.Red);
            buttons[5] = new ArcadeButton(player1buttons + new Point(70, +70), Color.Green);
            buttons[3] = new ArcadeButton(player1buttons + new Point(70, 0), Color.Blue);
            buttons[0] = new ArcadeButton(player1buttons + new Point(140, +70), Color.White);
            buttons[1] = new ArcadeButton(player1buttons + new Point(140, 0), Color.White);

            buttons[10] = new ArcadeButton(player2buttons + new Point(0, +20 + 70), Color.Yellow);
            buttons[8] = new ArcadeButton(player2buttons + new Point(0, +20), Color.Red);
            buttons[11] = new ArcadeButton(player2buttons + new Point(70, +70), Color.Green);
            buttons[9] = new ArcadeButton(player2buttons + new Point(70, 0), Color.Blue);
            buttons[6] = new ArcadeButton(player2buttons + new Point(140, +70), Color.White);
            buttons[7] = new ArcadeButton(player2buttons + new Point(140, 0), Color.White);
        }

        public void Render(SpriteBatch spriteBatch) {
            foreach (ArcadeButton a in buttons)
                a.Render(spriteBatch);
        }

        public void Clear() {
            foreach (ArcadeButton a in buttons)
                a.setActive(false);
        }

        public void Update() {
            if (!activated)
                return;

            check(0, PlayerIndex.One, PlayerInput.A);
            check(1, PlayerIndex.One, PlayerInput.B);
            check(2, PlayerIndex.One, PlayerInput.Red);
            check(3, PlayerIndex.One, PlayerInput.Blue);
            check(4, PlayerIndex.One, PlayerInput.Yellow);
            check(5, PlayerIndex.One, PlayerInput.Green);

            check(6, PlayerIndex.Two, PlayerInput.A);
            check(7, PlayerIndex.Two, PlayerInput.B);
            check(8, PlayerIndex.Two, PlayerInput.Red);
            check(9, PlayerIndex.Two, PlayerInput.Blue);
            check(10, PlayerIndex.Two, PlayerInput.Yellow);
            check(11, PlayerIndex.Two, PlayerInput.Green);
        }

        public void check(int index, PlayerIndex pindex, PlayerInput pinput) {
            if (InputHandler.GetButtonState(pindex, pinput) == InputState.Pressed) {
                if (!buttons[index].IsActivate()) {
                    buttons[index].setActive(true);
                    world.AddPlayer(pindex, pinput);
                    World.oneJoined = true;
                }
                buttons[index].Pressed();
            }
            else if(InputHandler.GetButtonState(pindex, pinput) == InputState.Released)
                buttons[index].Relesed();
        }
    }
}
