namespace EmojiCommand
{
    /*
        RemoveFeature is a concreate implementaion of the ICommand interface.
        It's function is to remove a feature from the emoji, it will store 
        the target feature so that it may be re-added when Unexecute is 
        called.
    */
    public class RemoveFeature : ICommand
    {
        IFeature Payload; // Store a feature as this commands payload

        // Constructor
        public RemoveFeature(IFeature payload)
        {
            Payload = payload;
        }

        // Execute removes the payload feature from the canvas
        void ICommand.Execute()
        {
            Program.Canvas.RemoveFeature(Payload);
        }

        // Execute adds the same feature back to the payload
        void ICommand.Unexecute()
        {
            Program.Canvas.AddFeature(Payload);
        }
    }
}