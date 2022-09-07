using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EggMan
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D rockTex;
        Vector2 rockPos;

        Texture2D eggmanTex;
        Vector2 eggmanPos;

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

            rockPos = new Vector2(screenSize.Width / 2, 100);
            eggmanPos = new Vector2(screenSize.Width / 2, screenSize.Height - 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            rockTex = Content.Load<Texture2D>("eggman_rock");
            eggmanTex = Content.Load<Texture2D>("eggman_sir_eggalot");
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(rockTex, rockPos, Color.White);
            _spriteBatch.Draw(eggmanTex, eggmanPos, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}