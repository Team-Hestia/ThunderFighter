﻿namespace ThunderFighter.Models.Missiles.Abstract
{
    using System.Collections.Generic;
    using ThunderFighter.Common.Enums;
    using ThunderFighter.Contracts;
    using ThunderFighter.Models.Common;

    public abstract class Missile : Entity, IMovable
    {
        private int deltaX;
        private int deltaY;

        protected Missile(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityStateType entityState) :
            base(field, position, bodyStates, entityState)
        {
        }

        public int DeltaX
        {
            get
            {
                return this.deltaX;
            }

            set
            {
                this.deltaX = value;
            }
        }

        public int DeltaY
        {
            get
            {
                return this.deltaY;
            }

            set
            {
                this.deltaY = value;
            }
        }

        public abstract void Move();
    }
}