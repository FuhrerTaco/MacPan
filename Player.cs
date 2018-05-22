﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MacPan
{
    class Player : MovingBody
    {
        //ResourceManager rm = new ResourceManager()
        //todo test powerup logic
        private bool canEat = false;
        private double powerUpLength = 0;
        private Timer powerUpTimer = new Timer();
        public Player(Canvas c) : base(c, "MacPan")
        {
            this.speed = 10;
            powerUpTimer.Elapsed += (sender, args) => { canEat = false; powerUpTimer.Stop(); };
            this.bodyOrient = direction.none;
            this.nextOrient = direction.none;
            this.bodyPos = new Point(100, 100);
            //todo fine tune speed
            this.speed = 5;
        }
        public void update(Ghost[] ghosts,Tile[,] tiles)
        {
            //todo add update logic
            if (Keyboard.IsKeyDown(Key.W)) this.nextOrient = direction.up;
            if (Keyboard.IsKeyDown(Key.D)) this.nextOrient = direction.right;
            if (Keyboard.IsKeyDown(Key.S)) this.nextOrient = direction.down;
            if (Keyboard.IsKeyDown(Key.A)) this.nextOrient = direction.left;
            base.update(true,true,tiles);
            checkCollision(ghosts);
            drawBody();
        }

        private void checkCollision(Ghost[] ghosts)
        {
            foreach(Ghost g in ghosts)
            {
                this.checkCollision(g);
            }
        }
        public void powerUp()
        {

            this.canEat = true;
            powerUpTimer.Interval = powerUpLength * 1000;
            powerUpTimer.Start();
        }
    }
}