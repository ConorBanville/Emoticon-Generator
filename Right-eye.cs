namespace EmojiCommand
{
    public class RightEye : IFeature
    {
        public override string Name {get;} // Store the name of the feature, "Right-eye"
        public override bool Type {get; set;} // Indicates which style this feature will take
        public override float X {get; set;} // The amount of space the feature is offset from the default in the X sense
        public override float Y {get; set;} // // The amount of space the feature is offset from the default in the Y sense

        // Default constructor
        public RightEye()
        {
            Name = "Right-Eye";
            Type = true;
            X = Y = 0F;
        }

        public RightEye(IFeature f)
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
$@"<circle cx=""{375 + X}"" cy=""{185 + Y}"" r=""60"" fill=""#F2F2F2"" stroke-width=""0""/>
<circle cx=""{350 + X}"" cy=""{200 + Y}"" r=""18"" fill=""#000000"" stroke-width=""0""/>";
            }
            else
            {
                return 
$@"<ellipse cx=""{350 + X}"" cy=""{200 + Y}"" rx=""70"" ry=""40"" fill=""#F2F2F2"" stroke-width=""0""/>
<circle cx=""{350 + X}"" cy=""{221 + Y}"" r=""18"" fill=""#000000"" stroke-width=""0""/>";
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