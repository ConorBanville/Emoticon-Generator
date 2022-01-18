using System.Collections.Generic;

namespace EmojiCommand
{
    /*
        Invoker is used to implement undoable functions via the Command pattern. It's
        function is to store a history of all commands and provides methods to step 
        through the history executing and unexecuting the stored commands as necessary.

        The history is a list of ICommands, which are an interface for Command objects,
        each of the commands, show, hide, move, reset and style have their own concrete 
        commmand classes to handle the execute and unexecute functions. I have given 
        more specific detail on how each of them work in their respective files.
    */
    public class Invoker
    {
        public List<ICommand> History; // Store a list of all previous commands
        int Index; // Store the index of the currently active command

        // Constructor
        public Invoker()
        {
            History = new List<ICommand>(); // Initialise a new list of commands
            Index = 0;
        }

        // Add a new command to the history
        public void Add(ICommand command)
        {
            // If the index < |History| then we must remove dead commands 
            if(Index < History.Count - 1)
            {
                for(int i=History.Count; i>= Index; i--)
                {
                    History.RemoveAt(i);
                }
            }
            History.Add(command);
            Execute(); 
        }

        // Execute a command
        public void Execute()
        {
            if(Index < 0 || Index > History.Count - 1) return;
            History[Index].Execute();
            Index ++;
        }

        // Unexecute a command
        public void Unexecute()
        {
            Index --;
            if(Index < 0 || Index > History.Count - 1) return;          
            History[Index].Unexecute(); 
        }
    }
}