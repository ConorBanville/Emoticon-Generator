namespace EmojiCommand
{
    public static class Info
    {

        public static string Welcome = 
@"Welcome to Emoticon Generator! A simple command line application to help you
create your favourite Emojis, as long as you have very limited taste in Emojis!
For some help getting started why don't you try the H[elp] command!";

        public static string Banner = 
        @"      
███████ ███    ███  ██████  ████████ ██  ██████  ██████  ███    ██      ██████  ███████ ███    ██ ███████ ██████   █████  ████████  ██████  ██████  
██      ████  ████ ██    ██    ██    ██ ██      ██    ██ ████   ██     ██       ██      ████   ██ ██      ██   ██ ██   ██    ██    ██    ██ ██   ██ 
█████   ██ ████ ██ ██    ██    ██    ██ ██      ██    ██ ██ ██  ██     ██   ███ █████   ██ ██  ██ █████   ██████  ███████    ██    ██    ██ ██████  
██      ██  ██  ██ ██    ██    ██    ██ ██      ██    ██ ██  ██ ██     ██    ██ ██      ██  ██ ██ ██      ██   ██ ██   ██    ██    ██    ██ ██   ██ 
███████ ██      ██  ██████     ██    ██  ██████  ██████  ██   ████      ██████  ███████ ██   ████ ███████ ██   ██ ██   ██    ██     ██████  ██   ██ ";

        public static string Banner2 =
        @"
███████╗███╗   ███╗ ██████╗ ████████╗██╗ ██████╗ ██████╗ ███╗   ██╗  ██████╗ ███████╗███╗   ██╗███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗ 
██╔════╝████╗ ████║██╔═══██╗╚══██╔══╝██║██╔════╝██╔═══██╗████╗  ██║ ██╔════╝ ██╔════╝████╗  ██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
█████╗  ██╔████╔██║██║   ██║   ██║   ██║██║     ██║   ██║██╔██╗ ██║ ██║  ███╗█████╗  ██╔██╗ ██║█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝
██╔══╝  ██║╚██╔╝██║██║   ██║   ██║   ██║██║     ██║   ██║██║╚██╗██║ ██║   ██║██╔══╝  ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗
███████╗██║ ╚═╝ ██║╚██████╔╝   ██║   ██║╚██████╗╚██████╔╝██║ ╚████║ ╚██████╔╝███████╗██║ ╚████║███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
╚══════╝╚═╝     ╚═╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝  ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
                                                                                                                                                    ";

        public static string Help = 
        @"
    show <feature>   * Show command adds a feature to the emoji
                    feature ->  left-eye    ... adds a left eye 
                                left-brow   ... adds a left brow 
                                right-eye   ... adds a right eye
                                right-brow  ... adds a right brow
                                mouth       ... adds a mouth

                example:  show left-eye    

    hide <feature>   * Hide command removes a feature from the emoji
                    feature ->  left-eye    ... removes a left eye 
                                left-brow   ... removes a left brow 
                                right-eye   ... removes a right eye
                                right-brow  ... removes a right brow
                                mouth       ... removes a mouth

                example:  hide left-eye
    
    move <feature> <direction> <value>
                    * Move command removes a feature from the emoji
                    feature   ->    left-eye    ... moves a left eye 
                                    left-brow   ... moves a left brow 
                                    right-eye   ... moves a right eye
                                    right-brow  ... moves a right brow
                                    mouth       ... moves a mouth

                    direction ->    up          ... moves feature up
                                    down        ... moves feature down
                                    left        ... moves feature left
                                    right       ... moves feature right

                    value     ->    the amount of units the feature is
                                    to be moved

                    example:  move left-eye 10

    reset <feature>  * Reset command resets a feature to it default position & style
                     feature  ->    left-eye    ... resets a left eye 
                                    left-brow   ... resets a left brow 
                                    right-eye   ... resets a right eye
                                    right-brow  ... resets a right brow
                                    mouth       ... resets a mouth
                        
                    example:  reset left-eye

    style <feature> <value>
                    * Style command sets a features style
                    feature   ->    left-eye    ... style a left eye 
                                    left-brow   ... style a left brow 
                                    right-eye   ... style a right eye
                                    right-brow  ... style a right brow
                                    mouth       ... style a mouth

                    value ->        A           ... sets the style to A
                                    B           ... sets the style to B

                    example:  style left-eye a
                                    
    save <file>     * Save saves the svg file to the ./output folder
                    file    ->      the desired name of file to be saved

                    example:  save SurprisedEmoji
                      this would create a file called SurprisedEmoji.svg in the 
                      ./output folder. This folder must already exist!


    draw        * Draw command will print the svg of the Emoji to the display
    undo        * Undo command undoes the previous command
    redo        * Redo command redoes the previously undone command
    help        * Help command display the help message
    quit        * Quit commmand will close the application saving no work
        ";
    }
}