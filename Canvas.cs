using System.Collections.Generic;

namespace EmojiCommand
{
    public class Canvas
    {
        public List<IFeature> Features {get; set;} // Store a list of features
        public static string BoilerSvg = 
        @"<?xml version=""1.0"" standalone=""no""?>
<svg width=""500"" height=""500"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"">
<circle cx=""250"" cy=""250"" r=""250"" fill=""#FFC300"" stroke-width=""0""/>"; // The first few lines required in the svg

        // Default constructor
        public Canvas()
        {
            Features = new List<IFeature>();
        }

        // Constructor: Takes a list of features
        public Canvas(List<IFeature> features)
        {
            Features = features;
        }

        // Add a new feature to the list
        public void AddFeature(IFeature feature)
        { 
            if(Contains(feature))RemoveFeature(feature);
            Features.Add(feature);
        }

        // Remove a feature from the list
        public IFeature RemoveFeature(IFeature feature)
        {
            IFeature f = null;

            for(int i=0; i<Features.Count; i++)
            {
                if(Features[i].Name == feature.Name)
                {
                    f = Features[i];
                    Features.RemoveAt(i);
                }
            }

            return f;
        }

        // Retreive the Svg for the canvas
        public string Draw()
        {
            string svg = BoilerSvg + "\n";

            foreach(IFeature obj in Features)
            {
                svg += obj.Embed() + "\n";
            }

            return svg += "</svg>";
        }

        // Check to see if the canvas contains a given feature
        public bool Contains(IFeature feature)
        {
            bool wasFound = false;
            
            foreach(IFeature obj in Features)
            {
                if(obj.Name == feature.Name)
                {
                    wasFound = true;
                }
            }

            return wasFound;
        }

        public void Move(string target, string dir, float delta)
        {
            foreach(IFeature obj in Features)
            {
                if(obj.Name == target)
                {
                    switch(dir)
                    {
                        case "up":
                            obj.MoveY(+delta);
                        break;

                        case "down":
                            obj.MoveY(-delta);
                        break;

                        case "left":
                            obj.MoveX(delta);
                        break;

                        case "right":
                            obj.MoveX(-delta);
                        break;
                    }
                }
            }
        }
    
        public void Style(IFeature target, string style)
        {
            foreach(IFeature obj in Features)
            {
                if(obj.Name == target.Name)
                {
                    if(obj.Type && style=="b")
                    {
                        obj.Type = false;
                    }

                    else if(!obj.Type && style=="a")
                    {
                        obj.Type = true;
                    }
                }
            }
        }
    }
}