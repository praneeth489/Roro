﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Roro.Workflow
{
    public sealed class EndNode : Node
    {
        public EndNode()
        {
            this.Activity = new EndNodeActivity();
        }

        public override Guid Execute()
        {
            Console.WriteLine("Execute: {0} {1}", this.Id, this.GetType().Name);
            return Guid.Empty;
        }

        public override void SetNextTo(Guid id)
        {
            Console.WriteLine("Error: Cannot set next to {0}.", this.GetType().Name);
        }

        public override GraphicsPath Render(Graphics g, Rectangle r, DefaultNodeStyle o)
        {
            var midRect = new Rectangle(
                r.X + r.Height / 2,
                r.Y,
                r.Width - r.Height,
                r.Height);
            var leftRect = new Rectangle(
                r.X,
                r.Y,
                r.Height,
                r.Height);
            var rightRect = new Rectangle(
                r.Right - r.Height,
                r.Y,
                r.Height,
                r.Height);
            g.DrawLine(o.BorderPen, midRect.X, midRect.Y, midRect.Right, midRect.Y);
            g.DrawLine(o.BorderPen, midRect.X, midRect.Bottom, midRect.Right, midRect.Bottom);
            g.DrawArc(o.BorderPen, leftRect, 90, 180);
            g.DrawArc(o.BorderPen, rightRect, 270, 180);

            // return path.
            var path = new GraphicsPath();
            path.AddArc(leftRect, 90, 180);
            path.AddArc(rightRect, 270, 180);
            return path;
        }
    }
}
