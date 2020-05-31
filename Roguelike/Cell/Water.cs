using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using Roguelike.Sprite;
using System;

namespace Roguelike.Cell
{
    public class Water : ICell
    {
        public ISprite Sprite { get; set; }
        public Vector2 Location { get; set; }
        public Tuple<int, int> GridLocation { get; set; }

        public int LayerType { get => 0; set => LayerType = value; }
        public Water(Vector2 location, int x, int y)
        {
            GridLocation = new Tuple<int, int>(x, y);
            Location = location;
            Sprite = CellSpriteFactory.Instance.CreateWaterSprite(location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, float priority)
        {
            Sprite.Draw(spriteBatch, priority);
        }
        public void DrawMini(SpriteBatch spriteBatch)
        {
            Sprite.DrawMini(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
