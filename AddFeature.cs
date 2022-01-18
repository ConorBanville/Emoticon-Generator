namespace EmojiCommand
{
    /*
        AddFeature is a concreate implementaion of the ICommand interface.
        It's function is to add a new feature to the emoji. It implements 
        undoable functions by allowing the command to be unexecuted which 
        removes the stored feature from the emoji.

        The payload stores the trageted feature so that it may be removed (Unexecute)
        and added (Execute).
    */
    public class AddFeature : ICommand
    {
        IFeature Payload; // Store a feature as this commands payload

        // Constructor 
        public AddFeature(IFeature payload)
        {
            Payload = payload;
        }

        // Execute adds a feature to the canvas
        void ICommand.Execute()
        {
            Program.Canvas.AddFeature(Payload);
        }

        // Unexecute removes the same feature from the canvas
        void ICommand.Unexecute()
        {
            Program.Canvas.RemoveFeature(Payload);
        }
    }
}