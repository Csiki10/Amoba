using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Amoba
{
    public class Display : FrameworkElement

    {
        IGameModel model;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            double rectWidth = size.Width / 3;
            double rectHeight = size.Height / 3;

            drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 0),
                new Rect(0, 0, size.Width, size.Height));

            ;
            for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                {
                    ImageBrush brush = new ImageBrush();
                    switch (model.GameMatrix[i, j])
                    {
                        case Logic.Item.x:
                            brush = new ImageBrush
                                (new BitmapImage(new Uri(Path.Combine("Images", "o29.jpg"), UriKind.RelativeOrAbsolute)));
                            break;
                        case Logic.Item.o:
                            brush = new ImageBrush
                                (new BitmapImage(new Uri(Path.Combine("Images", "x29.jpg"), UriKind.RelativeOrAbsolute)));
                            break;
                        case Logic.Item.e:
                            break;
                        default:
                            break;
                    }

                    drawingContext.DrawRectangle(brush
                                , new Pen(Brushes.Black, 0),
                                new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                );
                }
            }

        }


    }
}
