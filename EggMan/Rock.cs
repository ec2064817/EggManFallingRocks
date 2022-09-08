using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggMan
{
    internal class Rock
    {
        //Class Variable declerations
        Texture2D _art;
        Vector2 _position;
        Vector2 _velocity;
        public Rectangle HitBox;

        // Constructor
        public Rock(Texture2D art, Vector2 position)
        {
            _art = art;
            _position = position;
            _velocity = Vector2.Zero; // Same as doing "new Vector2(0,0)
            HitBox = new Rectangle((int)position.X - 15, (int)position.Y - 15, art.Width - 30, art.Height - 30);
        }
        public void UpdateMe(int screenHeight, int screenWidth)
        {
            _velocity.Y = _velocity.Y + 0.09f; // simulates gravity
            _position.Y = _position.Y + _velocity.Y;

            if(_position.Y > screenHeight) //if Y < screen height
            {
                _position.Y = Game1.RNG.Next(-_art.Height*2, -_art.Height);// set Y to off the screen and gives it a random delay
                _velocity.Y = 0;
                _position.X = Game1.RNG.Next(0, screenWidth - _art.Width);
            }
            HitBox.X = (int)_position.X + 15;
            HitBox.Y = (int)_position.Y + 15;    
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_art, _position, Color.White);
            sb.Draw(Game1.debugPixel, HitBox, Color.Red * 0.5f);
        }

    }
}
