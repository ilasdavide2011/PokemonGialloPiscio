using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;

namespace PokemonGialloPiscio.scripts
{
    public static class Utils
    {
        public static void Blit(SpriteBatch spriteBatch, Texture2D texture, Vector2 pos)
        {
            spriteBatch.Draw(texture, pos, null, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
        }
        public static void Blit(SpriteBatch spriteBatch, Texture2D texture, Vector2 pos, float scale)
        {
            spriteBatch.Draw(texture, pos, null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }
    }
}
