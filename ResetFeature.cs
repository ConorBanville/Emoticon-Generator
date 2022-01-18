namespace EmojiCommand
{
    /*
        ResetFeature is a concreate implementaion of the ICommand interface.
        It's function is to reset a feature to its default. It will store a 
        copy of the feature, before it was reset in its payload so that it may 
        be restored when Unexecute is called;
    */
    public class ResetFeature : ICommand
    {
        IFeature Payload;
        string Target;

        public ResetFeature(string target)
        {
            Target = target;
            // Temporarily initialise the Payload, doesnt matter that they are new instances of 
            // a feature all we need is the feature name, and the garbage collecter will free up 
            // the memory.
            switch(target)
            {
                case "left-eye":
                    Payload = new LeftEye();
                break;

                case "left-brow":
                    Payload = new LeftBrow();
                break;

                case "right-eye":
                    Payload = new RightEye();
                break;

                case "right-brow":
                    Payload = new RightBrow();
                break;

                case "mouth":
                    Payload = new Mouth();
                break;
            }
        }

        void ICommand.Execute()
        {
            Payload = Program.Canvas.RemoveFeature(Payload);
            switch(Target)
            {
                case "left-eye":
                    Program.Canvas.AddFeature(new LeftEye());
                break;

                case "left-brow":
                    Program.Canvas.AddFeature(new LeftBrow());
                break;

                case "right-eye":
                    Program.Canvas.AddFeature(new RightEye());
                break;

                case "right-brow":
                    Program.Canvas.AddFeature(new RightBrow());
                break;

                case "mouth":
                    Program.Canvas.AddFeature(new Mouth());
                break;
            }
        }

        void ICommand.Unexecute()
        {
            Program.Canvas.RemoveFeature(Payload);
            Program.Canvas.AddFeature(Payload);
        }
    }
}