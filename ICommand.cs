namespace EmojiCommand
{
    public interface ICommand
    {
        /*  
            ICommand interface used to implement undoable functions via the Command Pattern.
            It's function is to create a contract for Command object, this contract basically 
            boils down to a Execute method that allows the redo function and an unexecute method
            that allows the undo function.
        */

        public void Execute();

        public void Unexecute();
    }
}