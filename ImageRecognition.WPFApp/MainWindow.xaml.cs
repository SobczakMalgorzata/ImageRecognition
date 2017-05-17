using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ImageRecognition.ObjectDetectionLibrary;

namespace ImageRecognition.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageObject.ObjectDetectingOnImage image;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter =
                "Bit Map (*.bmp)|*.bmp|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png|" +
                "Portable Network Graphic (*.gif)|*.gif";
            op.DefaultExt = ".bmp";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.Stream myStream = null;
                try
                {
                    if ((myStream = op.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //currentimage = op.FileName; 
                            Uri currentImage = new Uri(op.FileName);
                            Bitmap img = new Bitmap(myStream);

                            image = new ImageObject.ObjectDetectingOnImage(img);

                            //displaing pictures
                            int myExt = op.FilterIndex;
                            //getting data from picture

                            //img = image.GetColorBitmap();
                            int index = 2;
                            this.board.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(image.segmentedImage.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(image.segmentedImage.Width, image.segmentedImage.Height));
                            //Bitmap img2 = image.verticalProjections[index];
                            this.verticalBoard.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(image.verticalProjections[index].GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));
                            //Bitmap img1 = image.horizontalProjections[index];
                            this.horizontalBoard.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(image.horizontalProjections[index].GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));
                            
                            //image.Initialization(img);
                            //image = new ImageInstance(img);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                myStream.Dispose();
            }
        }
        
    }
}
