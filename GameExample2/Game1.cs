using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace GameExample2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D Fondo;

        //INSTANCIA DE CLASES
        EventoMouse Mouse;
        MovimientoCohete Cohete;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //ACTUALIZA LA PANTALLA CADA SEGUNDO ESTABLECIDO
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 40.0f);
            base.Initialize();
        }

        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Fondo = Content.Load<Texture2D>("img/Fondo");

            Mouse = new EventoMouse(Content);
            Cohete = new MovimientoCohete(Content, graphics);
        }


        protected override void UnloadContent()
        {         
        }

        //ESTE METODO PERMITE QUE CADA CAMBIO QUE SE DEBE EN PANTALLA SE ACTUALIZA CADA MICROSEGUNDO
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //OBTIENE EL ANGULO SEGUN LAS COORDENADAS DE POSICION
            float angulo = (float)Math.Atan2(Mouse.posicion.Y - Cohete.posicion.Y, Mouse.posicion.X - Cohete.posicion.X);

            //SE ACTUALIZA CADA MOVIMIENTO
            Mouse.Update(gameTime);
            Cohete.Update(gameTime, Mouse.posicion, angulo);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //INICIA EL SPRITE
            spriteBatch.Begin();

            // INGRESA IMAGEN AL FONDO DE LA PANTALLA
            spriteBatch.Draw(Fondo, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            
            //HACE VISIBLE CADA UNO DE LOS SPRIT INCLUIDOS EN LAS CLASES COHETE Y MOUSE
            Cohete.Draw(gameTime, spriteBatch);
            Mouse.Draw(gameTime, spriteBatch);
            
            //FINALIZA EL SPRITE
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
