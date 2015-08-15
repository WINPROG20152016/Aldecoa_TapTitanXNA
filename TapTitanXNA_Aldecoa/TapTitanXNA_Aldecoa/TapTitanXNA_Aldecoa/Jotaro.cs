using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_Aldecoa
{
    class Jotaro
    {
        #region Properties
        Vector2 JojoPosition;
        Texture2D jotaro;
        ContentManager content;
        Level level;
    

        #endregion

        public Jotaro(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {

            jotaro = content.Load<Texture2D>("HeroSprite/Jotaro");


            int positionX = (Level.windowWidth / 2) - (jotaro.Width);
            int positionY = (Level.windowHeight / 2) - (jotaro.Height / 3);
            JojoPosition = new Vector2((float)positionX, (float)positionY);

           
            }
        public void Update(GameTime gameTime)
        {


            JojoPosition.X += 1;
           


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(jotaro,JojoPosition, Color.White);
            
        }
    }
}
