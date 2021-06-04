using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.Desktop;

namespace opentk_test
{
    public class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, NativeWindowSettings.Default) { 
        
        }
    }
}
