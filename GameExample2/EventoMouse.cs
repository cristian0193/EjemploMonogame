using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameExample2
{
    class EventoMouse
    {
        private Texture2D cursor;
        public Vector2 posicion;

        // Constructor
        public EventoMouse(ContentManager content) 
        {
            this.cursor = content.Load<Texture2D>("img/Cursor");            
        }

        // Lógica del mouse
        public void Update(GameTime gametime)
        {
            this.posicion = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        // Dibujamos el cursor
        public void Draw(GameTime gametime, SpriteBatch spritebatch)
        {
            spritebatch.Draw(cursor, posicion, Color.White);
        }
    }
}
