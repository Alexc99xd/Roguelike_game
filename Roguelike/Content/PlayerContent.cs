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
        public Texture2D PlayerDownLeftSpriteSheet { get; set; }
        public Texture2D PlayerDownRightSpriteSheet { get; set; }
        public Texture2D PlayerDownSpriteSheet { get; set; }
        public Texture2D PlayerLeftSpriteSheet { get; set; }
        public Texture2D PlayerRightSpriteSheet { get; set; }
        public Texture2D PlayerUpLeftSpriteSheet { get; set; }
        public Texture2D PlayerUpRightSpriteSheet { get; set; }
        public Texture2D PlayerUpSpriteSheet { get; set; }
        public Texture2D ArrowSpriteSheet { get; set; }
        public PlayerContent(ContentManager content)
        {
            this.content = content;
            PlayerDefaultSpriteSheet = content.Load<Texture2D>("Player/DefaultSpriteSheet");
            PlayerDownLeftSpriteSheet = content.Load<Texture2D>("Player/DownLeftSpriteSheet");
            PlayerDownRightSpriteSheet = content.Load<Texture2D>("Player/DownRightSpriteSheet");
            PlayerDownSpriteSheet = content.Load<Texture2D>("Player/DownSpriteSheet");
            PlayerLeftSpriteSheet = content.Load<Texture2D>("Player/LeftSpriteSheet");
            PlayerRightSpriteSheet = content.Load<Texture2D>("Player/RightSpriteSheet");
            PlayerUpLeftSpriteSheet = content.Load<Texture2D>("Player/UpSpriteSheet");
            PlayerUpRightSpriteSheet = content.Load<Texture2D>("Player/UpRightSpriteSheet");
            PlayerUpSpriteSheet = content.Load<Texture2D>("Player/UpSpriteSheet");
            ArrowSpriteSheet = content.Load<Texture2D>("Player/arrowSpriteSheet");
        }


        public void Unload()
        {
            content.Unload();
        }

        


    }
}
