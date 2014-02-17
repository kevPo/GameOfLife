using System;

namespace GameOfLife
{
    public class Cell
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Boolean IsAlive { get; set; }
        public Char Value { get; set; }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public Cell Clone()
        {
            return new Cell { X = this.X, Y = this.Y, IsAlive = this.IsAlive, Value = this.Value };
        }

        public override bool Equals(object other)
        {
            if (!(other.GetType() == typeof(Cell)))
                return false;
            return Equals(other as Cell);
        }

        private Boolean Equals(Cell otherCell)
        {
            return X == otherCell.X &&
                Y == otherCell.Y &&
                IsAlive == otherCell.IsAlive;
        }
    }
}
