namespace EmojiCommand
{
    public class Mouth : IFeature
    {
        public override string Name {get;} // Store the name of the feature, "Mouth"
        public override bool Type {get; set;} // Indicates which style this feature will take
        public override float X {get; set;} // The amount of space the feature is offset from the default in the X sense
        public override float Y {get; set;} // // The amount of space the feature is offset from the default in the Y sense

        // Default Constructor
        public Mouth()
        {
            Name = "Mouth";
            Type = true;
            X = Y = 0F;
        }

        public Mouth(IFeature f)
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
$@"<ellipse cx=""{250 + X}"" cy=""{400 + Y}"" rx=""60"" ry=""50"" fill=""#5c4033"" stroke-width=""0""/>";
            }
            else
            {
                return 
$@"<line x1=""{175 + X}"" y1=""{400 + Y}"" x2=""{325 + X}"" y2=""{400 + Y}"" stroke=""#5c4033"" stroke-width=""12""/>";
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
            float bound = Program.Bound; // Boundary that X and Y can move within.
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