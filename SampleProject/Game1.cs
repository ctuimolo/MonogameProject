using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SampleProject.GameObjects;
using SampleProject.GameObjects.Player;
using SampleProject.GameObjects.Walls;
using SampleProject.AABBPhysics;

namespace SampleProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AABBPhysicsHandler PhysicsHandler;

        List<GameObject> gameObjects;
        Player player;

        List<Wall> walls;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Content.RootDirectory = "Content";
            player = new Player(Content, spriteBatch);
            gameObjects = new List<GameObject>() { player };
            walls = new List<Wall>();
            player.SetWalls(walls);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Initialize();
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Wall wall1 = new Wall(Content, spriteBatch, new Vector2(40, 300), 700, 50);
            Wall wall2 = new Wall(Content, spriteBatch, new Vector2(160, 270), 290, 30);
            Wall wall3 = new Wall(Content, spriteBatch, new Vector2(470, 220), 90, 10);
            Wall wall4 = new Wall(Content, spriteBatch, new Vector2(300, 190), 100, 30);

            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            walls.Add(wall4);

            gameObjects.Add(wall1);
            gameObjects.Add(wall2);
            gameObjects.Add(wall3);
            gameObjects.Add(wall4);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent();
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
