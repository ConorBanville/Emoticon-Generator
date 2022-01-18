namespace EmojiCommand
{
    /*
        StyleFeature is a concreate implementaion of the ICommand interface.
        It's function is to set the style to one of two possible styles for 
        the given feature. It will Store the old style so that is may be
        restored when unexecute is called.
    */
    public class StyleFeature : ICommand
    {
        IFeature Payload;
        string Style;

        public StyleFeature(IFeature payload, string style)
        {
            Payload = payload;
            Style = style;
        }

        void ICommand.Execute()
        {
            Program.Canvas.Style(Payload, Style);
        }

        void ICommand.Unexecute()
        {
            if(Style == "a")
            {
                Program.Canvas.Style(Payload, "b");
            }
            else
            {
                Program.Canvas.Style(Payload, "a");
            }
        }
    }
}