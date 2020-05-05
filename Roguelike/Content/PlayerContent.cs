using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class PlayerContent
    {

        ContentManager content;


        //player
        public Texture2D PlayerDefaultSpriteSheet { get; set; }
        public PlayerContent(ContentManager content)
        {
            this.content = content;
            PlayerDefaultSpriteSheet = content.Load<Texture2D>("Player/SmileyWalk");
        }

        public PlayerContent()
        {
        }

        public void Unload()
        {
            content.Unload();
        }

        


    }
}
