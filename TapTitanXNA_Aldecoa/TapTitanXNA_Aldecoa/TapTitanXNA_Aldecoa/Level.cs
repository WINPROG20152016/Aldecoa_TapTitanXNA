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
       SpriteFont Damage;
       SpriteFont GameOver;
       String Over="";
       float time = 0.0f;
       float dmg = 0f;
       float shiaOuch = 500f;
       Shia shia;

       Jotaro jojo;

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
        jojo = new Jotaro(content, this);
        
	}

    public void LoadContent()
    {
        background = content.Load<Texture2D>("Background/universe");
        shiaHealth = content.Load<SpriteFont>("SpriteFont1");
        GameOver = content.Load<SpriteFont>("SpriteFont2");
        Damage = content.Load<SpriteFont>("SpriteFont3");

        attackButton = new Button(content, "Button/buton",new Vector2(600,500));
        shia.LoadContent();
        jojo.LoadContent();
        hero.LoadContent();
        
    }

     public void Update(GameTime gameTime)
     {
          mouseState = Mouse.GetState();
          mouseX = mouseState.X;
          mouseY = mouseState.Y;
          prev_mpressed = mpressed;
          mpressed = mouseState.LeftButton == ButtonState.Pressed;
          time = gameTime.TotalGameTime.Seconds;


          hero.Update(gameTime);
          

         oldMouseState = mouseState;

         if (time % 2 == 0)
         {
             dmg += 0.5f;
             shiaOuch -= 0.5f;
             
         }

         if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
         {
            shiaOuch -= 5;
            dmg += 0.5f;
            shia.Update(gameTime);
            
            jojo.Update(gameTime);
         }
         if (shiaOuch <= 0)
         {
             Over = "Game Over";
             shiaOuch = 0;
             dmg = 0;

         }
         if (shiaOuch ==0 && mpressed)
         {
             game.Exit();

         }

        
     }

     public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
     {

         spriteBatch.Draw(background, Vector2.Zero, Color.White);
         shia.Draw(gameTime, spriteBatch);
         jojo.Draw(gameTime, spriteBatch);
         hero.Draw(gameTime, spriteBatch);
         spriteBatch.DrawString(shiaHealth,shiaOuch+ " :Shia Health", Vector2.Zero, Color.Blue);
         spriteBatch.DrawString(GameOver,Over, new Vector2(400,150), Color.Red);
         spriteBatch.DrawString(Damage,"Damage:" + dmg +" total",new Vector2(0,200), Color.Aquamarine);
         attackButton.Draw(gameTime, spriteBatch);
     }
   }
}
