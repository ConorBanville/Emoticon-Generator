namespace EmojiCommand
{
    /*
        Name : Conor Banville
        Std Number: 18383803
        IDE : VS Code, (VS Community to genorate UML)

        This solution utilised the Command DP to implement undoable functions. 
        Application may break if certain commands are not entered exactly as 
        specifiaction dictates. I have explained how I implemented the Command 
        pattern in relevent files. I give an overview of my command design in 
        the Invoker.cs file.

        I used no external resources in order to create this applications, all work
        is my own including the Svg, because of this the Svg is extremely basic but I 
        figured that marks were probably not going for quality of the svg.   
    */
    class Program
    {   
        public static Canvas Canvas = new Canvas(); // Canvas initialised here so that its is easilly accessible from each class, canvas stores the features on the Emoji.
        public static float Bound = 20F; // This is a boundary that each feature can be moved within, 20F is fairly restrictive but I wanted to be sure 
                                         // features wouldn't spill over into other features or off the page. I have it set here so it can easily be
                                         // edited.
        public static Manager m = new Manager();

        static void Main()
        {
            m.Start();
        }
    }
}