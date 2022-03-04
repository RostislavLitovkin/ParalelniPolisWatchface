using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms.Renderer.Watchface;
using Xamarin.Forms;

namespace ParalelniPolisWatchface
{
    class Program : FormsWatchface
    {
        ClockViewModel _viewModel;
        TextWatchApplication watchfaceApp;
        bool animation = false;

        protected override void OnCreate()
        {
            base.OnCreate();
            watchfaceApp = new TextWatchApplication();
            _viewModel = new ClockViewModel();
            watchfaceApp.BindingContext = _viewModel;
            LoadWatchface(watchfaceApp);
        }

        protected override void OnTick(TimeEventArgs time)
        {
            base.OnTick(time);
            if (_viewModel != null)
            {
                _viewModel.Time = time.Time.UtcTimestamp;
                if (animation && _viewModel.Time.Second % 5 == 0)
                {
                    Particle particle = new Particle();
                    particle.Appear(watchfaceApp.ParticleLayout);
                }
            }
        }

        protected override void OnAmbientChanged(AmbientEventArgs mode)
        {
            base.OnAmbientChanged(mode);
            animation = !mode.Enabled;
            watchfaceApp.SecondsHand.IsVisible = !mode.Enabled;
            watchfaceApp.Triangle.IsVisible = !mode.Enabled;
            watchfaceApp.TriangleAmbient.IsVisible = mode.Enabled;
        }

        protected override void OnAmbientTick(TimeEventArgs time)
        {
            base.OnAmbientTick(time);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app);
            global::Tizen.Wearable.CircularUI.Forms.Renderer.FormsCircularUI.Init();
            app.Run(args);
        }
    }
}
