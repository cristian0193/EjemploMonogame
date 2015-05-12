using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameExample2
{
    class MovimientoCohete
    {
        private Texture2D textura;
        public Vector2 posicion;
        private Vector2 velocidad;
        private float anguloRadianes;

        private ContentManager content;
        private GraphicsDeviceManager graficos;

        public MovimientoCohete(ContentManager content, GraphicsDeviceManager graficos) 
        {
            this.content = content;
            this.graficos = graficos;

            this.textura = content.Load<Texture2D>("img/Cohete");
            this.posicion = new Vector2((graficos.GraphicsDevice.Viewport.Width / 2)- this.textura.Width/2 , (graficos.GraphicsDevice.Viewport.Height / 2) - this.textura.Height / 2);
        }

        public void Update(GameTime gametime, Vector2 direccion, float anguloRadianes) 
        {   
            this.anguloRadianes = anguloRadianes;

            if (Vector2.Distance(posicion, direccion) > 60)
            {
                float velocidadUnitaria = 3.0f;

                this.velocidad.X = (float)Math.Cos(anguloRadianes) * velocidadUnitaria;
                this.velocidad.Y = (float)Math.Sin(anguloRadianes) * velocidadUnitaria;

                this.posicion += this.velocidad;
            }
        }

        public void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.textura, this.posicion, null, Color.White, anguloRadianes + MathHelper.ToRadians(90), new Vector2(this.textura.Width / 2, this.textura.Height / 2), 1.0f, SpriteEffects.None, 1);            
        }

    }
}
