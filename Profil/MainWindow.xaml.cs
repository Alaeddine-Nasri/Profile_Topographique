using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace Profil
{

    
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            int compteur;

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(2),
                new ObservableValue(8),
                new ObservableValue(18),
                new ObservableValue(23),
                new ObservableValue(10),

            };
         
            for (compteur = 0; compteur < 1; compteur++)
            {
                MyValues.Add(new ObservableValue(3));//We add Y ! 
            }
                SeriesCollection = new SeriesCollection
                {


                new LineSeries
                {
                    Title = "Topgraphie",
                    //Fill = Brushes.Red,
                  //  StrokeThickness = 4,
                    Values = MyValues,//les valeurs
                    PointGeometrySize = 10,
                    AreaLimit = 0,
                 //   LineSmoothness = 0,
                 //   DataLabels = true,
                   
                    

                },
               
                
                
              /*  new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }*/
            };
                

                Labels = new[] { "20m", "30m", "40m", "50m", "60m","70m" };// l'absis des x
                YFormatter = value => value.ToString("C");
             //   Console.WriteLine("Bonjour C#");
            
            
            //modifying the series collection will animate and update the chart
            /*    SeriesCollection.Add(new LineSeries
                {
                    Title = "Series 4",
                    Values = new ChartValues<double> { 5, 3, 2, 4 },
                    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                    PointGeometrySize = 50,
                    PointForeground = Brushes.Gray
                });*/

            //modifying any series values will also animate and update the chart
            //   SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public LineSeries LineSeries { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ChartValues<ObservableValue> MyValues { get; set; }
    }

}







 












