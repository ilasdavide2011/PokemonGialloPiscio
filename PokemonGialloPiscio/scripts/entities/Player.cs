using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonGialloPiscio.scripts;

namespace PokemonGialloPiscio.scripts.entities
{
    public class Player : PhysicsEntity
    {
        public string playerName;
        public string playerGender;

        private float speed;
        public Player()
        {
            pos = new Vector2(0, 0);
            vel = new Vector2(0, 0);
            speed = 4;
        }

        new public void Load(ContentManager Content)
        {
            image = Content.Load<Texture2D>("images/entities/player");
            size = new Vector2(image.Width, image.Height);
        }

        new public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            vel = new Vector2(0, 0);

            if (keyState.IsKeyDown(Keys.W)) vel.Y = -speed;
            if (keyState.IsKeyDown(Keys.A)) vel.X = -speed;
            if (keyState.IsKeyDown(Keys.S)) vel.Y = speed;
            if (keyState.IsKeyDown(Keys.D)) vel.X = speed;

            pos.X += vel.X;
            pos.Y += vel.Y;
        }

        new public void Render(SpriteBatch spriteBatch)
        {
            Utils.Blit(spriteBatch, image, pos, 4);
        }
    }
}
