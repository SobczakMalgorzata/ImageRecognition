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
        ImageInstance image;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter =
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Bit Map (*.bmp)|*.bmp|" +
                "Portable Network Graphic (*.png)|*.png|" +
                "Portable Network Graphic (*.gif)|*.gif";
            op.DefaultExt = ".jpg";
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
                            //displaing pictures
                            int myExt = op.FilterIndex;
                            //getting data from picture
                            
                            //img = image.GetColorBitmap();
                            this.board.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(img.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));

                            //image.Initialization(img);
                            image = new ImageInstance(img);
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

        private void BlackAndWhite_Click(object sender, RoutedEventArgs e)
        {
            Bitmap img = image.GetGrayScaleBitmap();
            this.board.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(img.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            Bitmap img = image.GetColorBitmap();
            this.board.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(img.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));
        }

        private void EdgeDetection_Click(object sender, RoutedEventArgs e)
        {
            Bitmap img = image.EdgeDetectionBitmap();
            this.board.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(img.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(img.Width, img.Height));
        }
    }
}
