using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_Aldecoa
{
    public class Level
    {
       public static int windowWidth = 1280;
       public static int windowHeight = 720;
       #region Properties
       ContentManager content;

       Texture2D background;
       public MouseState oldMouseState;
       public MouseState mouseState;
       bool mpressed, prev_mpressed = false;
       int mouseX, mouseY;

       SpriteFont shiaHealth;
       SpriteFont GameOver;
       String Over="";
       int shiaOuch = 100;
       int shiaH=500, shiaW=150;
       Shia shia;

       Game1 game;
      
       Button attackButton;
       
       Hero hero;
       #endregion

       public Level(ContentManager content, Game1 game)
	{
        this.content = content;
        this.game = game;

        hero = new Hero(content, this);
        shia = new Shia(content, this);
	}

    public void LoadContent()
    {
        background = content.Load<Texture2D>("Background/universe");
        shiaHealth = content.Load<SpriteFont>("SpriteFont1");
        GameOver = content.Load<SpriteFont>("SpriteFont2");

        attackButton = new Button(content, "Button/buton",new Vector2(500,550));
        shia.LoadContent();
        hero.LoadContent();
    }

     public void Update(GameTime gameTime)
     {
          mouseState = Mouse.GetState();
          mouseX = mouseState.X;
          mouseY = mouseState.Y;
          prev_mpressed = mpressed;
          mpressed = mouseState.LeftButton == ButtonState.Pressed;

          hero.Update(gameTime);
          shia.Update(gameTime);

         oldMouseState = mouseState;

         if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
         {
            shiaOuch -= 5;

         }
         if (shiaOuch <= 0)
         {
             Over = "Game Over";
             
         }
         if (shiaOuch < -1)
         {
             game.Exit();

         }
     }

     public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
     {

         spriteBatch.Draw(background, Vector2.Zero, Color.White);
         shia.Draw(gameTime, spriteBatch);
         hero.Draw(gameTime, spriteBatch);
         spriteBatch.DrawString(shiaHealth,shiaOuch+ " :Shia Health", Vector2.Zero, Color.Blue);
         spriteBatch.DrawString(GameOver,Over, new Vector2(shiaH,shiaW), Color.Red);
         attackButton.Draw(gameTime, spriteBatch);
     }
   }
}
