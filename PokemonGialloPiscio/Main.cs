using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonGialloPiscio.scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGialloPiscio.scripts.entities;

namespace PokemonGialloPiscio
{

    public class Main
    {
        private Player player;
        public Main()
        {
            player = new Player();
        }

        public void Load(ContentManager Content)
        {
            player.Load(Content);
        }
        
        public void Update(GameTime gameTime, string playerName, string playerGender)
        {
            if (player.playerName == null && player.playerGender == null)
            {
                player.playerGender = playerGender;
                player.playerName = playerName;
                Debug.WriteLine("[Player Info Confirm] " + playerName + " " + playerGender);
            }
            player.Update();
        }
        
        public void Render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            player.Render(spriteBatch);
        }
    }
}
