﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace MacPan
{
    class MovingBody
    {
        //enum for direction
        public enum direction { up, right, down, left};
        private int speed = 10;
        private direction bodyOrient;
        private Point bodyPos;
        private Rectangle sprite;
        public Point BodyPos { get => bodyPos;  }
        public direction BodyOrient { get => bodyOrient; }
        public Rectangle Sprite { get => sprite; }

        //todo add constructor method
        public MovingBody()
        {

        }
        public void drawBody()
        {
            //todo add drawBody logic
        }

        public bool checkCollision()
        {
            //todo add collision logic
            return false;
        }

        public virtual void update()
        {
            //todo add update logic
            switch(bodyOrient)
            {
                case direction.up:
                    this.bodyPos.Y -= speed;
                    break;
                case direction.down:
                    this.bodyPos.Y += speed;
                    break;
                case direction.left:
                    this.bodyPos.X -= speed;
                    break;
                case direction.right:
                    this.bodyPos.X += speed;
                    break;
                default:
                    break;
            }
        }
    }
}
