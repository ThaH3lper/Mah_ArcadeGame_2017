using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ae3210_LitJump
{
    class HeroBilboard : Box
    {
        public HeroBilboard(int x, int y, PlayerIndex index, PlayerInput input) : base(x, y, 64, 19, Color.White, "control")
        {
            if(index == PlayerIndex.One && input == PlayerInput.A){
                SetSourceBox(new Rectangle(0, 30 * 5, 100, 30));
            }
            else if (index == PlayerIndex.One && input == PlayerInput.B){
                SetSourceBox(new Rectangle(0, 30 * 4, 100, 30));
            }
            else if (index == PlayerIndex.One && input == PlayerInput.Red){
                SetSourceBox(new Rectangle(0, 30 * 0, 100, 30));
            }
            else if (index == PlayerIndex.One && input == PlayerInput.Blue){
                SetSourceBox(new Rectangle(0, 30 * 2, 100, 30));
            }
            else if (index == PlayerIndex.One && input == PlayerInput.Yellow){
                SetSourceBox(new Rectangle(0, 30 * 1, 100, 30));
            }
            else if (index == PlayerIndex.One && input == PlayerInput.Green){
                SetSourceBox(new Rectangle(0, 30 * 3, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.A){
                SetSourceBox(new Rectangle(0, 30 * 5, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.B){
                SetSourceBox(new Rectangle(0, 30 * 10, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.Red){
                SetSourceBox(new Rectangle(0, 30 * 6, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.Blue){
                SetSourceBox(new Rectangle(0, 30 * 8, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.Yellow){
                SetSourceBox(new Rectangle(0, 30 * 7, 100, 30));
            }
            else if (index == PlayerIndex.Two && input == PlayerInput.Green){
                SetSourceBox(new Rectangle(0, 30 * 9, 100, 30));
            }
        }

        public void SetYPos(int y)
        {
            drawBox.Y = y - 30;
        }

    }
}
