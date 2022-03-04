using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParalelniPolisWatchface
{
    public class Particle : Image
    {
        const int delay = 2500;
        public Particle()
        {
            Source = "triangle.png";
            Opacity = 0;
            Aspect = Aspect.AspectFill;
        }

        public async Task Appear(AbsoluteLayout layout)
        {
            Random random = new Random();

            layout.Children.Add(this, new Rectangle(0.5, 20, 300, 300), AbsoluteLayoutFlags.XProportional);

            this.TranslationX = random.Next(-180, 180);
            this.TranslationY = random.Next(-180, 180);
            this.Rotation = random.Next(-90, 90);
            this.Scale = random.NextDouble() / 4 + 0.3;

            await Task.WhenAll(
                this.TranslateTo(0, 0, delay, Easing.CubicOut),
                this.FadeTo(0.6, delay),
                this.RotateTo(0, delay, Easing.CubicOut),
                this.ScaleTo(1, delay, Easing.CubicOut));
            await this.FadeTo(0, 500);

            layout.Children.Remove(this);
        }
    }
}
