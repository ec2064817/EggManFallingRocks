using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EggMan
{
    public class Game1 : Game
    {
        // Class var declaerations
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();

        MouseState ms;

        Rock lavaRock;
        Rock lavaRock2;
        Rock lavaRock3;
        Egg_Man PC;

        public static Texture2D debugPixel;

        /*Texture2D rockTex;
        Vector2 rockPos;

        Texture2D eggmanTex;
        Vector2 eggmanPos;*/

        Rectangle screenSize;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screenSize = GraphicsDevice.Viewport.Bounds;



            /*rockPos = new Vector2(screenSize.Width / 2, 100);
            eggmanPos = new Vector2(screenSize.Width / 2, screenSize.Height - 100);*/

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            lavaRock = new Rock(Content.Load<Texture2D>("eggman_rock"), new Vector2(100,0));
            lavaRock2 = new Rock(Content.Load<Texture2D>("eggman_rock"), new Vector2(100, 0));
            lavaRock3 = new Rock(Content.Load<Texture2D>("eggman_rock"), new Vector2(100, 0));
            PC = new Egg_Man(Content.Load<Texture2D>("eggman_sir_eggalot"), new Vector2(300,400));
            debugPixel = Content.Load<Texture2D>("pixel");

            /*rockTex = Content.Load<Texture2D>("eggman_rock");
            eggmanTex = Content.Load<Texture2D>("eggman_sir_eggalot");*/
        }

        protected override void Update(GameTime gameTime)
        {

            ms = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))Exit();

            lavaRock.UpdateMe(screenSize.Height, screenSize.Width);
            lavaRock2.UpdateMe(screenSize.Height, screenSize.Width);
            lavaRock3.UpdateMe(screenSize.Height, screenSize.Width);
            PC.UpdateMe(ms.X, screenSize.Width);

            if(lavaRock.HitBox.Intersects(PC.HitBox))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            _spriteBatch.Begin();
            lavaRock.DrawMe(_spriteBatch);
            lavaRock2.DrawMe(_spriteBatch);
            lavaRock3.DrawMe(_spriteBatch);
            PC.DrawMe(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}