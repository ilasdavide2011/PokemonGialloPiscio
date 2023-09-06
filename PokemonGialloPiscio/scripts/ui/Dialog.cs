using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PokemonGialloPiscio.scripts
{
    public class Dialog
    {
        private Vector2 pos;
        private string text;
        private string type;
        private Texture2D dialogTexture;
        private SpriteFont font;
        public bool active;

        public Dialog(string text, string type) 
        {
            this.pos = new Vector2(0, 390-32*4);
            this.text = text;
            this.type = type;
            active = true;
        }
        public void Load(ContentManager Content)
        {
            dialogTexture = Content.Load<Texture2D>("images/ui/dialogs/basicDialog");
            font = Content.Load<SpriteFont>("fonts/PokemonDS");
        }
        public void Update()
        {
            
        }
        public void Render(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(dialogTexture, pos, new Rectangle(new Point(0, 0), new Point(16, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(4, 4), SpriteEffects.None, 0);
                spriteBatch.Draw(dialogTexture, new Vector2(pos.X + 4 * 4, pos.Y), new Rectangle(new Point(4, 0), new Point(10, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(56, 4), SpriteEffects.None, 0);
                spriteBatch.Draw(dialogTexture, new Vector2(640 - 16 * 4, pos.Y), new Rectangle(new Point(16, 0), new Point(16, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(4, 4), SpriteEffects.None, 0);

                spriteBatch.Draw(dialogTexture, new Vector2(pos.X, pos.Y + 16 * 4), new Rectangle(new Point(0, 16), new Point(16, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(4, 4), SpriteEffects.None, 0);
                spriteBatch.Draw(dialogTexture, new Vector2(pos.X + 4 * 4, pos.Y + 16 * 4), new Rectangle(new Point(4, 16), new Point(10, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(56, 4), SpriteEffects.None, 0);
                spriteBatch.Draw(dialogTexture, new Vector2(640 - 16 * 4, pos.Y + 16 * 4), new Rectangle(new Point(16, 16), new Point(16, 16)), Color.White, 0, new Vector2(0, 0), new Vector2(4, 4), SpriteEffects.None, 0);

                spriteBatch.DrawString(font, text, new Vector2(pos.X + 18, pos.Y + 16), Color.Black, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            }
        }
    }
}
