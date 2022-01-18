using System;
using System.IO;

namespace EmojiCommand
{
    /*
        Manager class is the center of the application, it's function it to accept input and 
        then act upon that input, then it loops back to accept more input.
    */
    public class Manager
    {
        static Invoker Invoker; // Store an Invoker object to allow undoables
        static IFeature F; // Have a bucket to temporarily store IFeatures

        // Default Constructor
        public Manager()
        {
            Invoker = new Invoker();
        }

        // Start is called when application is ready to start accepting input from the user
        public void Start()
        {
            bool running = true; // Flag indicates whether the program is running

            Console.Clear(); // Clear the console
            Console.WriteLine(Info.Banner2); // Print the Banner
            Console.WriteLine(Info.Welcome); //Print a welcome message

            // While the application is running accept input
            while(running)
            {
                switch(Run(Console.ReadLine()))
                {
                    // If the kill message comes back from the parser close the application
                    case "k":
                        Console.WriteLine("Program Closing ...");
                    return;

                    // Handle every other event by doing nothing, then accept more input
                    default:
                    break;
                }
            }
        }

        // Run() takes the users input and passes it to the relevent method to be parsed and executed
        public string Run(string input)
        {
            string token; // Token flages what type of instruction has been given by the user
            string argument; // Contains any relevent data the application will need in order to execute an instruction

            if(input.Contains(" "))
            {
                token = input.Substring(0,input.IndexOf(' '));
                argument = input.Substring(input.IndexOf(' ') + 1, input.Length - (input.IndexOf(' ') + 1));
                return Parse(token, argument.ToLower());
            }
            else
            {
                token = input;
                argument = "";
                return Parse(token);
            }
        }

        public string Parse(string token)
        {
            switch(token.ToLower())
            {
                // Display the help screen
                case "h":
                    Console.WriteLine(Info.Help);
                break;
                // Display the help screen
                case "help":
                    Console.WriteLine(Info.Help);
                break;

                // Close the Program 
                case "q":
                return "k";
                // Close the Program 
                case "quit":
                return "k";

                // Undo the last Command 
                case "u":
                   Invoker.Unexecute();
                break;
                // Undo the last Command 
                case "undo":
                    Invoker.Unexecute();
                break;

                // Redo the last Command
                case "r":
                    Invoker.Execute();
                break;
                // Redo the last Command
                case "redo":
                    Invoker.Execute();
                break;

                // Output the SVG to the console
                case "d":
                    Console.WriteLine(Program.Canvas.Draw());
                break;
                // Output the SVG tot he console
                case "draw":
                    Console.WriteLine(Program.Canvas.Draw());
                break;

                default:
                break;
            }

            return "";
        }

        public string Parse(string token, string argument)
        {
            if(token == "move")
            {
                Move(argument);
                return "";
            }

            if(token == "style")
            {
                Style(argument);
                return "";
            }
            
            switch(token.ToLower())
            {
                case "show":
                    switch(argument.ToLower())
                    {
                        case "left-eye":
                            Invoker.Add(new AddFeature(new LeftEye()));
                        break;

                        case "left-brow":
                            Invoker.Add(new AddFeature(new LeftBrow()));
                        break;

                        case "right-eye":
                            Invoker.Add(new AddFeature(new RightEye()));
                        break;

                        case "right-brow":
                            Invoker.Add(new AddFeature(new RightBrow()));
                        break;

                        case "mouth":
                            Invoker.Add(new AddFeature(new Mouth()));
                        break;
                        
                        default: 
                        break;
                    }
                break;

                case "hide":
                    switch(argument.ToLower())
                    {
                        case "left-eye":
                            F = new LeftEye();
                            // Only create a new command if the canvas contains the relevent feature
                            if(Program.Canvas.Contains(F))
                            {
                                Invoker.Add(new RemoveFeature(F));
                            }
                            else 
                            {
                                Console.WriteLine($"Emoji does not contain a {F.Name}");
                            }
                        break;

                        case "left-brow":
                            F = new LeftBrow();
                            // Only create a new command if the canvas contains the relevent feature
                            if(Program.Canvas.Contains(F))
                            {
                                Invoker.Add(new RemoveFeature(F));
                            }
                            else 
                            {
                                Console.WriteLine($"Emoji does not contain a {F.Name}");
                            }
                        break;

                        case "right-eye":
                            F = new RightEye();
                            // Only create a new command if the canvas contains the relevent feature
                            if(Program.Canvas.Contains(F))
                            {
                                Invoker.Add(new RemoveFeature(F));
                            }
                            else 
                            {
                                Console.WriteLine($"Emoji does not contain a {F.Name}");
                            }
                        break;

                        case "right-brow":
                            F = new RightBrow();
                            // Only create a new command if the canvas contains the relevent feature
                            if(Program.Canvas.Contains(F))
                            {
                                Invoker.Add(new RemoveFeature(F));
                            }
                            else 
                            {
                                Console.WriteLine($"Emoji does not contain a {F.Name}");
                            }
                        break;

                        case "mouth":
                            F = new Mouth();
                            // Only create a new command if the canvas contains the relevent feature
                            if(Program.Canvas.Contains(F))
                            {
                                Invoker.Add(new RemoveFeature(F));
                            }
                            else 
                            {
                                Console.WriteLine($"Emoji does not contain a {F.Name}");
                            }
                        break;
                        
                        default: 
                        break;
                    }
                break;

                case "reset":
                    switch(argument.ToLower())
                    {
                        case "left-eye": 
                            if(Program.Canvas.Contains(new LeftEye()))
                            {
                                Invoker.Add(new ResetFeature(argument.ToLower()));
                            }
                            else{
                                Console.WriteLine($"Emoji does not contain a {argument}");
                            }
                        break;

                        case "left-brow":
                            if(Program.Canvas.Contains(new LeftBrow()))
                            {
                                Invoker.Add(new ResetFeature(argument.ToLower()));
                            } 
                            else{
                                Console.WriteLine($"Emoji does not contain a {argument}");
                            }                           
                        break;

                        case "right-eye": 
                            if(Program.Canvas.Contains(new RightEye()))
                            {
                                Invoker.Add(new ResetFeature(argument.ToLower()));
                            }
                            else{
                                Console.WriteLine($"Emoji does not contain a {argument}");
                            }
                        break;

                        case "right-brow": 
                            if(Program.Canvas.Contains(new RightBrow()))
                            {
                                Invoker.Add(new ResetFeature(argument.ToLower()));
                            }
                            else{
                                Console.WriteLine($"Emoji does not contain a {argument}");
                            }
                        break;

                        case "mouth": 
                            if(Program.Canvas.Contains(new Mouth()))
                            {
                                Invoker.Add(new ResetFeature(argument.ToLower()));
                            }
                            else{
                                Console.WriteLine($"Emoji does not contain a {argument}");
                            }
                        break;
                    }
                break;

                case "save":
                    string svg = Program.Canvas.Draw();
                    File.WriteAllText($"./output/{argument}.svg", svg);
                break;
            }

            return "";
        } 

        // Move a feature on the emoji
        public void Move(string argument)
        {
            string[] arr = argument.Split(' ');

            if(arr.Length != 3)
            {
                Console.WriteLine($"{argument} is an invalid command!");
                return;
            }

            try{
                float delta = float.Parse(arr[2]);

                switch(arr[0])
                {
                    case "left-eye":
                        F = new LeftEye();
                        if(Program.Canvas.Contains(F))
                        {
                            Invoker.Add(new MoveFeature(F.Name, arr[1].ToLower(), delta));
                        }
                    break;

                    case "left-brow":
                        F = new LeftBrow();
                        if(Program.Canvas.Contains(F))
                        {
                            Invoker.Add(new MoveFeature(F.Name, arr[1].ToLower(), delta));
                        }
                    break;

                    case "right-eye":
                        F = new RightEye();
                        if(Program.Canvas.Contains(F))
                        {
                            Invoker.Add(new MoveFeature(F.Name, arr[1].ToLower(), delta));
                        }
                    break;

                    case "right-brow":
                        F = new RightBrow();
                        if(Program.Canvas.Contains(F))
                        {
                            Invoker.Add(new MoveFeature(F.Name, arr[1].ToLower(), delta));
                        }
                    break;

                    case "mouth":
                        F = new Mouth();
                        if(Program.Canvas.Contains(F))
                        {
                            Invoker.Add(new MoveFeature(F.Name, arr[1].ToLower(), delta));
                        }
                    break;
                }

                return;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Cannot convert {arr[2]} to a number!");
                Console.WriteLine(e.Message);
                return;
            }
        }  
    
        // Change the style of a feature
        public void Style(string argument)
        {
            string[] arr = argument.Split();

            if(arr.Length != 2)
            {
                Console.WriteLine($"{argument} is an invalid command!");
                return;
            }

            switch(arr[0].ToLower())
            {
                case "left-eye":
                    if(Program.Canvas.Contains(new LeftEye()))
                    {
                        Invoker.Add(new StyleFeature(new LeftEye(), arr[1].ToLower()));
                    }
                break;

                case "left-brow":
                    if(Program.Canvas.Contains(new LeftBrow()))
                    {
                        Invoker.Add(new StyleFeature(new LeftBrow(), arr[1].ToLower()));
                    }
                break;

                case "right-eye":
                    if(Program.Canvas.Contains(new RightEye()))
                    {
                        Invoker.Add(new StyleFeature(new RightEye(), arr[1].ToLower()));
                    }
                break;

                case "right-brow":
                    if(Program.Canvas.Contains(new RightBrow()))
                    {
                        Invoker.Add(new StyleFeature(new RightBrow(), arr[1].ToLower()));
                    }
                break;

                case "mouth":
                    if(Program.Canvas.Contains(new Mouth()))
                    {
                        Invoker.Add(new StyleFeature(new Mouth(), arr[1].ToLower()));
                    }
                break;
            }
        }
    }
}