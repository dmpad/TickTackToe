using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace TickTacToe
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textureX, textureO, board, blank, t1, t2, t3, t4, t5, t6, t7, t8, t9, temp;
        Vector2 textureOPos, textureXPos, boardPos, tempVector, pos11, pos12, pos13, pos21, pos22, pos23, pos31, pos32, pos33, test, test2, scoreLabel, scores;
        protected float scale = 0.54f, s1 = 1f, s2 = 1f, s3 = 1f, s4 = 1f, s5 = 1f, s6 = 1f, s7 = 1f, s8 = 1f, s9 = 1f;
        int turn = 1, xWins = 0, yWins = 0;
        char player = 'x';
        char[,] boardArr = new char[3,3];
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Tick Tack Toe"; //Adds title to the top of the application
            textureOPos = new Vector2(5, 5);
            textureXPos = new Vector2(105, 5);
            boardPos = new Vector2(0, 0);
            tempVector = new Vector2(5, 105);
            pos11 = new Vector2(5, 5);
            pos12 = new Vector2(5, 105);
            pos13 = new Vector2(5, 205);
            pos21 = new Vector2(105, 5);
            pos22 = new Vector2(105, 105);
            pos23 = new Vector2(105, 205);
            pos31 = new Vector2(205, 5);
            pos32 = new Vector2(205, 105);
            pos33 = new Vector2(205, 205);
            scoreLabel = new Vector2(450, 20);
            scores = new Vector2(450, 50);
            test = new Vector2(400, 150);
            test2 = new Vector2(400, 180);
        }
        
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureO = this.Content.Load<Texture2D>("o");
            textureX = this.Content.Load<Texture2D>("x");
            font = Content.Load<SpriteFont>("Arial");

            board = new Texture2D(this.GraphicsDevice, 310, 310);
            Color[] colorData = new Color[310 * 310];
            for(int loop = 0; loop < 96100; loop++)
                colorData[loop] = Color.Black;

            board.SetData<Color>(colorData);

            blank = new Texture2D(this.GraphicsDevice, 95, 95);
            Color[] colorData2 = new Color[95 * 95];
            for (int loop = 0; loop < 9025; loop++)
                colorData2[loop] = Color.White;

            blank.SetData<Color>(colorData2);

            t1 = blank;
            t2 = blank;
            t3 = blank;
            t4 = blank;
            t5 = blank;
            t6 = blank;
            t7 = blank;
            t8 = blank;
            t9 = blank;
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsActive) //Pauses game while program is not selected
            {
                KeyboardState stateK = Keyboard.GetState();
                if (stateK.IsKeyDown(Keys.Escape))
                    Exit();
                if (stateK.IsKeyDown(Keys.R))
                    reset();

                MouseState stateM = Mouse.GetState();
                if (turn % 2 != 0) //determines who's turn it is, x always goes first
                {
                    temp = textureX;
                    player = 'x';
                }
                else
                {
                    temp = textureO;
                    player = 'o';
                }
                if (stateM.LeftButton == ButtonState.Pressed)
                {
                    if ((stateM.X > 5 && stateM.X < 300) && (stateM.Y > 5 && stateM.Y < 300))
                    {
                        if (stateM.X < 100)
                        {
                            if (stateM.Y < 100)
                            {
                                if (t1 == blank)
                                {
                                    t1 = temp;
                                    s1 = scale;
                                    boardArr[0, 0] = player;
                                    turn++;
                                }
                            }
                            else
                            {
                                if (stateM.Y < 200)
                                {
                                    if (t2 == blank)
                                    {
                                        t2 = temp;
                                        s2 = scale;
                                        boardArr[0, 1] = player;
                                        turn++;
                                    }
                                } else
                                {
                                    if (t3 == blank)
                                    {
                                        t3 = temp;
                                        s3 = scale;
                                        boardArr[0, 2] = player;
                                        turn++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (stateM.X < 200)
                            {
                                if (stateM.Y < 100)
                                {
                                    if (t4 == blank)
                                    {
                                        t4 = temp;
                                        s4 = scale;
                                        boardArr[1, 0] = player;
                                        turn++;
                                    }
                                }
                                else
                                {
                                    if (stateM.Y < 200)
                                    {
                                        if (t5 == blank)
                                        {
                                            t5 = temp;
                                            s5 = scale;
                                            boardArr[1, 1] = player;
                                            turn++;
                                        }
                                    }
                                    else
                                    {
                                        if (t6 == blank)
                                        {
                                            t6 = temp;
                                            s6 = scale;
                                            boardArr[1, 2] = player;
                                            turn++;
                                        }
                                    }
                                }
                            } else
                            {
                                if (stateM.Y < 100)
                                {
                                    if (t7 == blank)
                                    {
                                        t7 = temp;
                                        s7 = scale;
                                        boardArr[2, 0] = player;
                                        turn++;
                                    }
                                }
                                else
                                {
                                    if (stateM.Y < 200)
                                    {
                                        if (t8 == blank)
                                        {
                                            t8 = temp;
                                            s8 = scale;
                                            boardArr[2, 1] = player;
                                            turn++;
                                        }
                                    }
                                    else
                                    {
                                        if (t9 == blank)
                                        {
                                            t9 = temp;
                                            s9 = scale;
                                            boardArr[2, 2] = player;
                                            turn++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                if (boardArr[0,0].Equals(boardArr[0, 1]) && boardArr[0, 0].Equals(boardArr[0, 2]) && (boardArr[0,0] == 'x' || boardArr[0,0] == 'o'))//check for win here
                {
                    if (boardArr[0, 0].Equals('x'))
                        xWins++;
                    else
                        yWins++;
                    reset();
                } else
                {
                    if (boardArr[1, 0].Equals(boardArr[1, 1]) && boardArr[1, 0].Equals(boardArr[1, 2]) && (boardArr[1, 0] == 'x' || boardArr[1, 0] == 'o'))
                    {
                        if (boardArr[1, 0].Equals('x'))
                            xWins++;
                        else
                            yWins++;
                        reset();
                    } else
                    {
                        if (boardArr[2, 0].Equals(boardArr[2, 1]) && boardArr[2, 0].Equals(boardArr[2, 2]) && (boardArr[2, 0] == 'x' || boardArr[2, 0] == 'o'))
                        {
                            if (boardArr[2, 0].Equals('x'))
                                xWins++;
                            else
                                yWins++;
                            reset();
                        }
                            else
                            {
                                if (boardArr[0, 0].Equals(boardArr[1, 0]) && boardArr[0, 0].Equals(boardArr[2, 0]) && (boardArr[0, 0] == 'x' || boardArr[0, 0] == 'o'))
                                {
                                    if (boardArr[1, 1].Equals('x'))
                                        xWins++;
                                    else
                                        yWins++;
                                    reset();
                            }
                            else
                            {
                                    if (boardArr[0, 1].Equals(boardArr[1, 1]) && boardArr[0, 1].Equals(boardArr[2, 1]) && (boardArr[0, 1] == 'x' || boardArr[0, 1] == 'o'))
                                    {
                                        if (boardArr[0, 1].Equals('x'))
                                            xWins++;
                                        else
                                            yWins++;
                                        reset();
                                }
                                else
                                    {
                                    if (boardArr[0, 2].Equals(boardArr[1, 2]) && boardArr[0, 2].Equals(boardArr[2, 2]) && (boardArr[0, 2] == 'x' || boardArr[0, 2] == 'o'))
                                    {
                                        if (boardArr[0, 2].Equals('x'))
                                            xWins++;
                                        else
                                            yWins++;
                                        reset();
                                    }
                                    else
                                    {
                                        if (boardArr[0, 0].Equals(boardArr[1, 1]) && boardArr[0, 0].Equals(boardArr[2, 2]) && (boardArr[0, 0] == 'x' || boardArr[0, 0] == 'o'))
                                        {
                                            if (boardArr[0, 0].Equals('x'))
                                                xWins++;
                                            else
                                                yWins++;
                                            reset();
                                        }
                                        else
                                        {
                                            if (boardArr[2, 0].Equals(boardArr[1, 1]) && boardArr[2, 0].Equals(boardArr[0, 2]) && (boardArr[2, 0] == 'x' || boardArr[2, 0] == 'o'))
                                            {
                                                if (boardArr[2, 0].Equals('x'))
                                                    xWins++;
                                                else
                                                    yWins++;
                                                reset();
                                            }
                                        }
                                        }
                                    }
                                }
                            }
                    }

                }
                base.Update(gameTime);
            }
        }
        
        protected override void Draw(GameTime gameTime)
        {
            var fps = 1 / gameTime.ElapsedGameTime.TotalSeconds; //equation to calculate fps
            //Window.Title = fps.ToString();
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(board, boardPos, Color.Black);
            spriteBatch.Draw(t1, pos11, null, Color.White, 0, Vector2.Zero, s1, SpriteEffects.None, 0);
            spriteBatch.Draw(t2, pos12, null, Color.White, 0, Vector2.Zero, s2, SpriteEffects.None, 0);
            spriteBatch.Draw(t3, pos13, null, Color.White, 0, Vector2.Zero, s3, SpriteEffects.None, 0);
            spriteBatch.Draw(t4, pos21, null, Color.White, 0, Vector2.Zero, s4, SpriteEffects.None, 0);
            spriteBatch.Draw(t5, pos22, null, Color.White, 0, Vector2.Zero, s5, SpriteEffects.None, 0);
            spriteBatch.Draw(t6, pos23, null, Color.White, 0, Vector2.Zero, s6, SpriteEffects.None, 0);
            spriteBatch.Draw(t7, pos31, null, Color.White, 0, Vector2.Zero, s7, SpriteEffects.None, 0);
            spriteBatch.Draw(t8, pos32, null, Color.White, 0, Vector2.Zero, s8, SpriteEffects.None, 0);
            spriteBatch.Draw(t9, pos33, null, Color.White, 0, Vector2.Zero, s9, SpriteEffects.None, 0);

            spriteBatch.DrawString(font, "X  O", scoreLabel,Color.Black);
            spriteBatch.DrawString(font, (xWins.ToString() + "  " + yWins.ToString()), scores, Color.Black);
            spriteBatch.DrawString(font, "You can press 'R' to reset the board", test, Color.Black);
            spriteBatch.DrawString(font, "and you can press 'esc' to close.", test2, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void reset()
        {
            for(int l = 0; l <= 2; l++)
            {
                for(int i = 0; i <= 2; i++)
                {
                    boardArr[l, i] = 'N';
                }
            }

            LoadContent();

            s1 = 1f; s2 = 1f; s3 = 1f; s4 = 1f; s5 = 1f; s6 = 1f; s7 = 1f; s8 = 1f; s9 = 1f;
            Thread.Sleep(300);
        }
    }
}
