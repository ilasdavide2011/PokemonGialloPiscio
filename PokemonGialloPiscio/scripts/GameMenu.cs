using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using PokemonGialloPiscio.scripts.ui;

namespace PokemonGialloPiscio.scripts
{
    public class GameMenu
    {
        private Texture2D splashScreenTexture;
        private float splashScreenTimer;

        private Texture2D title;
        private Texture2D background;
        private Texture2D pika;
        private float pikaGiratoso;
        private Texture2D PlayButtonTexture;

        private Vector2 MousePos;
        private bool configPartStarted;

        private Dialog initialGenderDialog;
        private Dialog initialNameDialog;

        private Texture2D profTex;
        private Texture2D mcMasTex;
        private Texture2D mcFemTex;
        private Texture2D initalBg;
        private Texture2D mcMasTexSel;
        private Texture2D mcFemTexSel;
        private Texture2D mcMasTexA;
        private Texture2D mcFemTexA;
        public string selectedGender;
        public string selectedName;

        private TextBox nameInput;
        public bool startGame;
        //private SpriteFont font;

        public GameMenu()
        {
            splashScreenTimer = 0;
            pikaGiratoso = 0;
            configPartStarted = false;
            initialGenderDialog = new Dialog("Professor Immigrantissimo: ti piace il pepente o la fess?", "basic");
            initialNameDialog = new Dialog("Professor Immigrantissimo: quale e' il tuo nome?\n(massimo 10 caratteri)", "basic");
            startGame = false;
        }

        public void Load(ContentManager Content)
        {
            splashScreenTexture = Content.Load<Texture2D>("images/logog");
            title = Content.Load<Texture2D>("images/GameMenu/Title");
            pika = Content.Load<Texture2D>("images/GameMenu/Pika");
            background = Content.Load<Texture2D>("images/GameMenu/bg");
            PlayButtonTexture = Content.Load<Texture2D>("images/GameMenu/PlayButton");
            initialGenderDialog.Load(Content);
            initialNameDialog.Load(Content);
            profTex = Content.Load<Texture2D>("images/characters/immigratissimo/prof");
            mcMasTex = Content.Load<Texture2D>("images/characters/mc/mcMas");
            mcFemTex = Content.Load<Texture2D>("images/characters/mc/mcFem");
            initalBg = Content.Load<Texture2D>("images/characters/immigratissimo/initalSetupBg");
            mcMasTexSel = Content.Load<Texture2D>("images/characters/mc/mcMasSel");
            mcFemTexSel = Content.Load<Texture2D>("images/characters/mc/mcFemSel");
            mcMasTexA = mcMasTex;
            mcFemTexA = mcFemTex;
            nameInput = new TextBox(Content.Load<SpriteFont>("fonts/PokemonDS"), new Vector2(640-Content.Load<Texture2D>("images/ui/textInput").Width*2, 390-32*4-Content.Load<Texture2D>("images/ui/textInput").Height*2), Content.Load<Texture2D>("images/ui/textInput"), Content.Load<Texture2D>("images/ui/selTextInput")); ;
            //font = Content.Load<SpriteFont>("fonts/PokemonDS");
        }

        public void Update()
        {
            if (!startGame)
            {
                pikaGiratoso = pikaGiratoso + (float)0.05;
                MousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                if (splashScreenTimer >= 3)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        if ((MousePos.X > 640 / 2 - PlayButtonTexture.Width * 2) && (MousePos.X < 640 / 2 - PlayButtonTexture.Width * 2 + PlayButtonTexture.Width * 4) && (MousePos.Y > 390 / 2) && (MousePos.Y < 390 / 2 + PlayButtonTexture.Height * 4))
                        {
                            configPartStarted = true;
                        }
                    }
                }

                if (configPartStarted)
                {
                    initialGenderDialog.Update();
                    if ((MousePos.X > 20) && (MousePos.X < 20 + mcMasTex.Width * 4) && (MousePos.Y > 390 / 2 - 100) && (MousePos.Y < 390 / 2 - 100 + mcMasTex.Height * 4))
                    {
                        mcMasTexA = mcMasTexSel;
                    }
                    else
                    {
                        mcMasTexA = mcMasTex;
                    }
                    if ((MousePos.X > 640 - mcFemTex.Width * 2 - 60) && (MousePos.X < 640 - mcFemTex.Width * 2 - 60 + mcFemTex.Width * 4) && (MousePos.Y > 390 / 2 - 100) && (MousePos.Y < 390 / 2 - 100 + mcFemTex.Height * 4))
                    {
                        mcFemTexA = mcFemTexSel;
                    }
                    else
                    {
                        mcFemTexA = mcFemTex;
                    }
                    if (mcMasTexA == mcMasTexSel && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        Debug.WriteLine("[Player Info] gender: male");
                        selectedGender = "mas";
                        initialGenderDialog.active = false;
                    }
                    if (mcFemTexA == mcFemTexSel && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        Debug.WriteLine("[Player Info] gender: female");
                        selectedGender = "fem";
                        initialGenderDialog.active = false;
                    }
                }
                if (initialGenderDialog.active == false)
                {
                    KeyboardState keyboardState = Keyboard.GetState();
                    MouseState mouseState = Mouse.GetState();

                    if (initialNameDialog.active)
                    {
                        nameInput.Update(keyboardState, mouseState);
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && nameInput.text.Length != 0)
                        {
                            Debug.WriteLine("[Player Info] player name: " + nameInput.text);
                            selectedName = nameInput.text;
                            initialNameDialog.active = false;
                            configPartStarted = false;
                            startGame = true;
                        }
                    }
                }
            }
        }

        public void Render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!startGame)
            {
                splashScreenTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
                if (splashScreenTimer < 3) Utils.Blit(spriteBatch, splashScreenTexture, new Vector2(640 / 2 - splashScreenTexture.Width / 2, 0), 1);
                if (splashScreenTimer >= 3.5 && !configPartStarted)
                {
                    Utils.Blit(spriteBatch, background, new Vector2(0, 0));
                    Utils.Blit(spriteBatch, title, new Vector2(640 / 2 - (title.Width + title.Width / 2), 20), 3);
                    spriteBatch.Draw(pika, new Vector2((640 / 4) * 3 - pika.Width + 50, 180), null, Color.White, pikaGiratoso, new Vector2(pika.Width / 2, pika.Height / 2), 4, SpriteEffects.None, 0);
                    spriteBatch.Draw(pika, new Vector2(640 / 4 - pika.Width, 180), null, Color.White, pikaGiratoso, new Vector2(pika.Width / 2, pika.Height / 2), 4, SpriteEffects.None, 0);
                    Utils.Blit(spriteBatch, PlayButtonTexture, new Vector2(640 / 2 - PlayButtonTexture.Width * 2, 390 / 2), 4);
                    //spriteBatch.DrawString(font, "Gioca", new Vector2(640 / 2-10, 390 / 2), Color.Yellow, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
                }
                if (configPartStarted)
                {
                    Utils.Blit(spriteBatch, initalBg, new Vector2(0, 0));
                    initialGenderDialog.Render(spriteBatch);
                    if (initialGenderDialog.active == true)
                    {
                        Utils.Blit(spriteBatch, profTex, new Vector2(640 / 2 - profTex.Width * 2, 390 / 2 - 100), 4);
                        Utils.Blit(spriteBatch, mcMasTexA, new Vector2(20, 390 / 2 - 100), 4);
                        Utils.Blit(spriteBatch, mcFemTexA, new Vector2(640 - mcFemTex.Width * 2 - 60, 390 / 2 - 100), 4);
                    }
                    else if (initialGenderDialog.active == false && initialNameDialog.active == true)
                    {
                        if (selectedGender == "mas") Utils.Blit(spriteBatch, mcMasTex, new Vector2(640 / 2 - mcMasTex.Width * 2, 390 / 2 - 100), 4);
                        if (selectedGender == "fem") Utils.Blit(spriteBatch, mcFemTex, new Vector2(640 / 2 - mcFemTex.Width * 2, 390 / 2 - 100), 4);
                        Utils.Blit(spriteBatch, profTex, new Vector2(50, 50), 4);

                        initialNameDialog.Render(spriteBatch);
                        nameInput.Render(spriteBatch);
                    }
                }
            }
        }
    }
}
