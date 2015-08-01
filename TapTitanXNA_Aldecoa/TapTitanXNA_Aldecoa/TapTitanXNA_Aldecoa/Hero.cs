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
    public class Hero
    {
        #region Properties
        Vector2 playerPosition;
        Texture2D player;
        ContentManager content;
        Level level;
       
        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }


        public void LoadContent()
        {
            
            player = content.Load<Texture2D>("HeroSprite/Ralph");

            idleAnimation = new Animation(player, 0.1f, true);

            int positionX = (Level.windowWidth/2) - (player.Width / 2);
            int positionY = (Level.windowHeight / 2) - (player.Height / 3);
            playerPosition = new Vector2((float)positionX, (float)positionY);
            spritePlayer.PlayAnimation(idleAnimation);

        }
        public void Update(GameTime gameTime)
        {
            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("HeroSprite/RalphAttack"), 0.1f, false));
                
            }
            if (level.mouseState.LeftButton == ButtonState.Released)
            {

                spritePlayer.PlayAnimation(idleAnimation);

            }
 
          
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
        }
    }
}
