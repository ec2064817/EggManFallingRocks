using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggMan
{
    internal class Egg_Man
    {
        //Class var declarations
        Texture2D _art;
        Vector2 _position;
        public Rectangle HitBox;

        //Constuctor
        public Egg_Man(Texture2D art, Vector2 position)
        {
            _art = art;
            _position = position;
            HitBox = new Rectangle((int)position.X - 12, (int)position.Y - 12, art.Width - 24, art.Height - 24);
        }
        public void UpdateMe(int mouseX, int screenWidth)
        {
            if(_position.X > screenWidth -_art.Width)
            {
               _position.X = screenWidth - _art.Width;
            }

            if (_position.X < 0)
            {
                _position.X = 0;
            }
            // if mouse x is less than PC's X pos
            if (mouseX < _position.X)
                // subtract 4 from PC's x
                _position.X-=4;
            else if (mouseX > _position.X) //else if greater than PC's X 
                // Add 4 to PC's pos
                _position.X+=4;

            HitBox.X = (int)_position.X + 12;
            HitBox.Y = (int)_position.Y + 12;
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_art, _position, Color.White);
            sb.Draw(Game1.debugPixel, HitBox, Color.Red * 0.5f); 
        }
    }
}
