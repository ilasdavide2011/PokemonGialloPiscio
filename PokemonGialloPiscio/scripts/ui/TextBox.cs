using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PokemonGialloPiscio.scripts.ui
{
    public class TextBox
    {
        private SpriteFont font;
        private Vector2 pos;
        public string text;
        private bool isFocused;
        private HashSet<Keys> previousKeys;
        private Texture2D texture;
        private Texture2D selTexture;
        private Texture2D textureA;

        public TextBox(SpriteFont font, Vector2 position, Texture2D texture, Texture2D selTexture)
        {
            this.texture = texture;
            this.selTexture = selTexture;
            this.font = font;
            pos = position;
            text = string.Empty;
            isFocused = false;
            textureA = this.texture;
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Rectangle textBoxRectangle = new Rectangle((int)pos.X, (int)pos.Y, 100, 50);
                Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

                if (mouseRectangle.Intersects(textBoxRectangle))
                {
                    isFocused = true;
                    textureA = selTexture;
                }
                else
                {
                    isFocused = false;
                    textureA = texture;
                }
            }

            if (isFocused)
            {
                Keys[] pressedKeys = keyboardState.GetPressedKeys();

                foreach (Keys key in pressedKeys)
                {
                    if (!previousKeys.Contains(key))
                    {
                        if (key == Keys.Back && text.Length > 0)
                        {
                            text = text.Substring(0, text.Length - 1);
                        }
                        else
                        {
                            string keyString = key.ToString();

                            if (keyString.Length == 1)
                            {
                                bool shiftHeld = keyboardState.IsKeyDown(Keys.LeftShift) || keyboardState.IsKeyDown(Keys.RightShift);
                                char keyChar = shiftHeld ? keyString[0] : char.ToLower(keyString[0]);
                                if (text.Length <= 9)
                                {
                                    text += keyChar;
                                }
                            }
                        }
                    }
                }

                previousKeys = new HashSet<Keys>(pressedKeys);
            }
            else
            {
                previousKeys = new HashSet<Keys>();
            }
        }

        public void Render(SpriteBatch spriteBatch)
        {
            Utils.Blit(spriteBatch, textureA, pos);
            spriteBatch.DrawString(font, text, pos + new Vector2(9, 9), Color.Black);
        }
    }

}
