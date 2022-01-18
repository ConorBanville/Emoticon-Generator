namespace EmojiCommand
{
    public class LeftBrow : IFeature
    {
        public override string Name {get;} // Store the name of the feature, "Left-brow"
        public override bool Type {get; set;} // Indicates which style this feature will take
        public override float X {get; set;} // The amount of space the feature is offset from the default in the X sense
        public override float Y {get; set;} // // The amount of space the feature is offset from the default in the Y sense

        // Default constructor
        public LeftBrow()
        {
            Name = "Left-Brow";
            Type = true;
            X = Y = 0F;
        }

        public LeftBrow(IFeature f)
        {
            Name = f.Name;
            Type = f.Type;
            X = f.X;
            Y = f.Y;
        }

        // Return svg embeded feature
        public override string Embed()
        {
            // Default values have been coded into the svg already, then a X or Y value have been added where relevent.
            // The X and Y can only exist withing a certain bound. This is so features cannot spill over into other features
            // or off the page.

            if(Type)
            {
                return 
$@"<line x1=""{125 + X}"" y1=""{100 + Y}"" x2=""{210 + X}"" y2=""{135 + Y}"" stroke=""#000000"" stroke-width=""14""/>";
            }
            else
            {
                return 
$@"<line x1=""{70 + X}"" y1=""{140 + Y}"" x2=""{130 + X}"" y2=""{120 + Y}"" stroke=""#000000"" stroke-width=""14""/>
<line x1=""{125 + X}"" y1=""{121 + Y}"" x2=""{190 + X}"" y2=""{121 + Y}"" stroke=""#000000"" stroke-width=""15""/>";
            }
        }

        // Move a feature along the X-Axis
        public override void MoveX(float delta)
        {
            float bound = Program.Bound; // Boundary that X and Y can move within.

            X = X - delta;
            if(X <= -bound)
            {
                X = -bound;
            }
            if(X >= bound)
            {
                X = bound;
            }
        }
        // Move a feature along the Y-Axis
        public override void MoveY(float delta)
        {
            float bound = Program.Bound; // Boundary that X and Y can move within.;
            Y = Y - delta;
            if(Y <= -bound)
            {
                Y = -bound;
            }
            if(Y >= bound)
            {
                Y = bound;
            }
        }
    }
}