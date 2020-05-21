using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Content
{
    public class WorldContent
    {

        ContentManager content;


        //player
        public Texture2D PlaceHolderBG { get; set; }
        public Texture2D PlaceHolderBG2 { get; set; }
        public WorldContent(ContentManager content)
        {
            //this.content = content;
            PlaceHolderBG = content.Load<Texture2D>("World/placeHolderBG");
            PlaceHolderBG2 = content.Load<Texture2D>("World/chan_alex");
        }


        public void Unload()
        {
            content.Unload();
        }
    }
}
