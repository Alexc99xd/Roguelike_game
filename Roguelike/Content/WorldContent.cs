using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Roguelike.Content
{
    public class WorldContent
    {

        ContentManager content;


        //player
        public Texture2D PlaceHolderBG { get; set; }
        public Texture2D PlaceHolderBG2 { get; set; }
        public Texture2D Dirt { get; set; }
        public Texture2D Wall { get; set; }
        public Texture2D Water { get; set; }
        public Texture2D Hole { get; set; }

        public Texture2D HeadWalker { get; set; }
        public Texture2D Walker { get; set; }

        public WorldContent(ContentManager content)
        {
            //this.content = content;
            PlaceHolderBG = content.Load<Texture2D>("World/placeHolderBG");
            PlaceHolderBG2 = content.Load<Texture2D>("World/chan_alex");
            Dirt = content.Load<Texture2D>("World/Dirt");
            Wall = content.Load<Texture2D>("World/Wall");
            Water = content.Load<Texture2D>("World/Water");
            Hole = content.Load<Texture2D>("World/Hole");
            HeadWalker = content.Load<Texture2D>("World/headWalker");
            Walker = content.Load<Texture2D>("World/Walker");
        }


        public void Unload()
        {
            content.Unload();
        }
    }
}
