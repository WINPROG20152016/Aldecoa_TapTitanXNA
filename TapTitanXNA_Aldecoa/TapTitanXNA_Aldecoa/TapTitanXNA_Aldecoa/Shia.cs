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
    public class Shia
    {
        #region Properties
        Vector2 ShiaPosition;
        Texture2D shia;
        ContentManager content;
        Level level;
        
  

        #endregion

        public Shia(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {

            shia = content.Load<Texture2D>("HeroSprite/hero");

          
            int positionX = (Level.windowWidth / 2) - (shia.Width /2);
            int positionY = (Level.windowHeight / 2) - (shia.Height / 3);
            ShiaPosition = new Vector2((float)positionX, (float)positionY);
          

        }
        public void Update(GameTime gameTime)
        {

            ShiaPosition.Y += 1;
           


        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shia, ShiaPosition, Color.White);
            
        }
    }
}
