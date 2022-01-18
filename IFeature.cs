namespace EmojiCommand
{
    public abstract class IFeature
    {
        public abstract string Name {get;} // Name of the Feature eg. "Left-eye"
        public abstract bool Type {get; set;} // Indicates which style this feature will take
        public abstract float X {get; set;} // The amount of space the feature is offset from the default in the X sense
        public abstract float Y {get; set;} // // The amount of space the feature is offset from the default in the Y sense
        public abstract string Embed(); // Embed a feature in svg
        public abstract void MoveX(float delta); // Move a feature along the X-Axis
        public abstract void MoveY(float delta); // Move a feature along the Y-Axis
    }
}