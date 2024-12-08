using Music.ViewModel.PlayerCommandsBar;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace Music.View.PlayingSong
{

    public partial class PlayingSong
    {
        public PlayingSong()
        {
            InitializeComponent();
        }

        private void BlurBackgroundSkElement_OnPaintCanvas(object                  sender,
                                                           SKPaintSurfaceEventArgs e
        )
        {
            if (DataContext is PlayerCommandsBarViewModel playerCommandsBarViewModel &&
                !string.IsNullOrWhiteSpace(playerCommandsBarViewModel.Album?.CoverImageUrl))
            {
                using var bitmap = SKBitmap.Decode(playerCommandsBarViewModel.Album.CoverImageUrl);
                using var filter = SKImageFilter.CreateBlur(50, 50);
                using var paint = new SKPaint
                                  {
                                      ImageFilter = filter
                                  };


                e.Surface.Canvas.DrawBitmap(bitmap, SKRect.Create(e.Info.Width, e.Info.Height), paint);
            }
        }
    }
}