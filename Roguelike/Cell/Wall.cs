using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Roguelike.Interfaces;
using Roguelike.Sprite;
using System;

namespace Roguelike.Cell
{
    public class Wall : ICell
    {
        public ISprite Sprite { get; set; }
        public Vector2 Location { get; set; }
        public Tuple<int, int> GridLocation { get; set; }

        public int LayerType { get => 1; set => LayerType = value; }
        public Wall(Vector2 location, int x, int y)
        {
            GridLocation = new Tuple<int, int>(x, y);
            Location = location;
            Sprite = CellSpriteFactory.Instance.CreateWallSprite(location);
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
