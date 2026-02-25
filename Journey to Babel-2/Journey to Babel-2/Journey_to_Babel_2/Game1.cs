using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Journey_to_Babel_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        enum gameState
        {
            start,
            save,
            done
        }

        enum Language
        {
            English,
            Spanish,
            German
        }

        string[] statePhrases = new string[] {"start","save", "done"};

        Dictionary<string, string> EnglishLang = new Dictionary<string, string>();

        Dictionary<string, string> SpanishLang = new Dictionary<string, string>();

        Dictionary<string, string> GermanLang = new Dictionary<string, string>();

        Dictionary<string, string> currentLanguage;
        Language lang = Language.English; 

        KeyboardState oldKb;

        gameState currentGameState;

        List<string> lines;

        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            currentLanguage = EnglishLang;
            
            lines = new List<string>();


            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ReadFileAsStrings(@"Content/Output Messages-2.txt");
            font = this.Content.Load<SpriteFont>("SpriteFont1");


            EnglishLang.Add("start", lines[1]);
            EnglishLang.Add("save", lines[6]);
            EnglishLang.Add("done", lines[11]);

            SpanishLang.Add("start", lines[2]);
            SpanishLang.Add("save", lines[7]);
            SpanishLang.Add("done", lines[12]);

            GermanLang.Add("start", lines[3]);
            GermanLang.Add("save", lines[8]);
            GermanLang.Add("done", lines[13]);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 

        private void ReadFileAsStrings(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {

                        for (int i = 0; i < 14; i += 2)
                        {
                            string line = reader.ReadLine();

                            lines.Add(line);
                        }


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState kb = Keyboard.GetState();

            



            if (kb.IsKeyDown(Keys.D1) && !oldKb.IsKeyDown(Keys.D1))
            {
                currentLanguage = EnglishLang;
                lang = Language.English;
            }

            if (kb.IsKeyDown(Keys.D2) && !oldKb.IsKeyDown(Keys.D2))
            {
                currentLanguage = SpanishLang;
                lang = Language.Spanish;
            }

            if (kb.IsKeyDown(Keys.D3) && !oldKb.IsKeyDown(Keys.D3))
            {
                currentLanguage = GermanLang;
                lang = Language.German;
            }
            //if (currentGameState == gameState.done && kb.IsKeyDown(Keys.Space) && !oldKb.IsKeyDown(Keys.Space))
            //{
            //    currentGameState = 0;
            //}
            if (kb.IsKeyDown(Keys.Space) && !oldKb.IsKeyDown(Keys.Space))
            {
                currentGameState++;   
            }

            if (kb.IsKeyDown(Keys.Enter) && !oldKb.IsKeyDown(Keys.Enter))
            {
                switch (currentGameState)
                {
                    case gameState.start:

                        currentGameState = gameState.save;
                        break;


                    case gameState.save:
                        currentGameState = gameState.done;
                        break;

                    case gameState.done:

                        currentGameState = gameState.start;
                        break;

                }

            }

            // TODO: Add your update logic here
            oldKb = kb;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (lang) 
            {
                case Language.English:

                    switch (currentGameState)
                    {
                        case gameState.start:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[0]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.save:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[0]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.done:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[0]], new Vector2(50, 10), Color.Black);
                            break;
                    }
                    break;


                case Language.Spanish:

                    switch (currentGameState)
                    {
                        case gameState.start:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[1]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.save:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[1]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.done:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[1]], new Vector2(50, 10), Color.Black);
                            break;
                    }

                    break;



                case Language.German:
                    switch (currentGameState)
                    {
                        case gameState.start:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[2]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.save:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[2]], new Vector2(50, 10), Color.Black);
                            break;
                        case gameState.done:
                            spriteBatch.DrawString(font, currentLanguage[statePhrases[2]], new Vector2(50, 10), Color.Black);
                            break;
                    }
                    break;


        }

            



            spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}