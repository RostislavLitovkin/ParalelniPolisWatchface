using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("bignoodletitling.ttf")]

namespace ParalelniPolisWatchface
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextWatchApplication : Application
    {
        public TextWatchApplication()
        {
            InitializeComponent();
        }
        public AbsoluteLayout ParticleLayout => particleLayout;
        public Image SecondsHand => secondsHand;
        public Image Triangle => triangle;
        public Image TriangleAmbient => triangleAmbient;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Particle particle = new Particle();
            particle.Appear(particleLayout);
        }

    }
}