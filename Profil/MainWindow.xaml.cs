using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Diagnostics;
using iTextSharp.text;


using iTextSharp.text.pdf;

namespace Profil
{

    
    public partial class MainWindow : Window
    {
        private object pdfViewer;

        public MainWindow()
        {
            InitializeComponent();
            
            int compteur;
            int a = 20;
            double b = 100.20;

            MyValues = new ChartValues<ObservablePoint>();

                //{
                //        new ObservablePoint(100, 500),
                //      //  new ObservablePoint(1500, 800)
                //};
            for (compteur = 0; compteur < 1; compteur++)
            {
                MyValues.Add(new ObservablePoint(a, b));
                MyValues.Add(new ObservablePoint(50, 1200));
                MyValues.Add(new ObservablePoint(300, 300));
                MyValues.Add(new ObservablePoint(500, 860));
                MyValues.Add(new ObservablePoint(600, 150));
            }

            SeriesCollection = new SeriesCollection
                {


                new LineSeries
                {
                    Title = "Topgraphie",
                   // Fill = Brushes.Red,
                   // StrokeThickness = 4,
                    Values = MyValues,//les valeurs
                 //   PointGeometrySize = 4,
                    AreaLimit = 0,
                    LineSmoothness = 0.4,
                    //DataLabels = true,
                   
                    

                }
            };

            

            

            //Formatter = value => Math.Pow(Base, value).ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Formatter { get; set; }
        public double Base { get; set; }
        public ChartValues<ObservablePoint> MyValues { get; set; }

        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Viewbox viewbox = new Viewbox();



            RenderTargetBitmap rtb = new RenderTargetBitmap((int)chart.ActualWidth, (int)chart.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(visual: chart);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            MemoryStream stream = new MemoryStream();
            png.Save(stream);

            SaveToPng(chart, "MyChart.png");


            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
               PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("pdf.pdf", FileMode.Create));
          //   doc.Open();
           
                //iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(generatedPdfSaveFilePath, FileMode.Create));
                doc.Open();
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("./MyChart.PNG");
                jpg.Border = iTextSharp.text.Rectangle.BOX;
                jpg.BorderWidth = 5f;
                doc.Add(jpg);

                   doc.Add(new iTextSharp.text.Paragraph("Original Width: " + jpg.Width.ToString()));
            doc.Add(new iTextSharp.text.Paragraph("Original Height " + jpg.Height.ToString()));
            doc.Add(new iTextSharp.text.Paragraph("Scaled Width: " + jpg.ScaledWidth.ToString()));
            doc.Add(new iTextSharp.text.Paragraph("Scaled Height " + jpg.ScaledHeight.ToString()));
            
            float Resolution = jpg.Width / jpg.ScaledWidth * 72f;
            doc.Add(new iTextSharp.text.Paragraph("Resolution: " + Resolution));


            //   System.Windows.Documents.Paragraph name = new System.Windows.Documents.Paragraph();
            // doc.Add(name);
            //      MemoryStream ms = new MemoryStream();
            //   var ms = new MemoryStream();
            //        chart1.SaveImage(ms, ChartImageFormat.Png);
            //        String filePath = @"C:\Users\xxx\Desktop\test.jpg";
            //    var ParentPanelCollection = (chart.Parent as Panel).Children as UIElementCollection;
            //    ParentPanelCollection.Clear();

            
            //png file was created at the root directory. 

             doc.Close();

        }

        public void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }
    }

}

// Image image = Image.FromStream(stream);

//DependencyObject og = LogicalTreeHelper.GetParent(chart);
//test.Children.Remove(chart);
//viewbox.Child = chart;

//viewbox.Measure(chart.RenderSize);
//    viewbox.Arrange(new Rect(new Point(0, 0), chart.RenderSize));
//    chart.Update(true, true); //force chart redraw
//   viewbox.UpdateLayout();























