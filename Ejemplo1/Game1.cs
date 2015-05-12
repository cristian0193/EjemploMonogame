using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ejemplo1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D balaHorizontal;
        private Texture2D balaVertial;
        private Texture2D mundoMario;
        private int xBala1 = 0;
        private int yBala1 = 180;
        private int xBala2 = 240;
        private int yBala2 = 0;
        private int velocidadRecorrido1 = 10;
        private int velocidadRecorrido2 = 10;
        private Vector2 origen1;
        private Vector2 origen2;
        private SpriteEffects efecto1;
        private SpriteEffects efecto2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mundoMario = Content.Load<Texture2D>("imag/MundoMario");
            balaHorizontal = Content.Load<Texture2D>("imag/BalaHorizontal");
            balaVertial = Content.Load<Texture2D>("imag/BalaVertical");
            origen1.X = 0;
            origen1.Y = 0;
            origen2.X = 0;
            origen2.Y = 0;
            efecto1 = SpriteEffects.FlipHorizontally;
            efecto2 = SpriteEffects.None;
        }


        protected override void UnloadContent()
        {            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ManejoTeclado(Keyboard.GetState(), gameTime);

            base.Update(gameTime);
        }


        private void ManejoTeclado(KeyboardState KeyState, GameTime gameTime)
        {
            //EVENTO AL PRESIONAR TECLA HACIA LA DERECHA
            if (KeyState.IsKeyDown(Keys.Right))
            {
                if ((xBala1 + velocidadRecorrido1) <= 600)
                {
                    xBala1 = xBala1 + velocidadRecorrido1;
                }
                else
                {
                    efecto1 = SpriteEffects.None;
                }
            }

            //EVENTO AL PRESIONAR TECLA HACIA LA IZQUIERDA
            if (KeyState.IsKeyDown(Keys.Left))
            {
                if ((xBala1 - velocidadRecorrido1) > 0)
                {
                    xBala1 = xBala1 - velocidadRecorrido1;
                }
                else
                {
                    efecto1 = SpriteEffects.FlipHorizontally;
                }
            }

            //EVENTO AL PRESIONAR TECLA HACIA LA ARRIBA
            if (KeyState.IsKeyDown(Keys.Up))
            {
                if ((xBala2 - velocidadRecorrido2) > 0)
                {
                    xBala2 = xBala2 - velocidadRecorrido2;
                }
                else
                {
                    efecto2 = SpriteEffects.FlipVertically;
                }
            }

            //EVENTO AL PRESIONAR TECLA HACIA LA ABAJO
            if (KeyState.IsKeyDown(Keys.Down))
            {
                if ((xBala2 + velocidadRecorrido2) <= 300)
                {
                    xBala2 = xBala2 + velocidadRecorrido2;
                }
                else
                {
                    efecto2 = SpriteEffects.None;
                }
            }            
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Dibujar el Sprite backgroud
            spriteBatch.Draw(mundoMario, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            
            // Dibujar el Sprite de mario - MUEVE HORIZONTAL LA BALA
            spriteBatch.Draw(balaHorizontal, new Vector2(xBala1,yBala1), null, Color.White, 0, origen1, 1.0f, efecto1, 0f);

            // Dibujar el Sprite de mario - MUEVE VERITCAL LA BALA
            spriteBatch.Draw(balaVertial, new Vector2(yBala2, xBala2), null, Color.White, 0, origen2, 1.0f, efecto2, 0f);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
