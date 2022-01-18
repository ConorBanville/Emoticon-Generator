namespace EmojiCommand
{
    /*
        MoveFeature is a concreate implementaion of the ICommand interface.
        It's function is to move a feature in the X or Y sense on the Emoji.
        In order to implement undoables, we store the feature being moved,
        the direction it was moved and the amount it moved by so that
        all of this may be undone at when Unexecute is called.
    */
    public class MoveFeature : ICommand
    {
        string Payload;
        string Dir;
        float Delta;

        public MoveFeature(string payload, string dir, float delta)
        {
            Payload = payload;
            Dir = dir;
            Delta = delta;
        }

        void ICommand.Execute()
        {
            Program.Canvas.Move(Payload, Dir, Delta);
        }

        void ICommand.Unexecute()
        {
            Program.Canvas.Move(Payload, Dir, -Delta);
        }
    }
}