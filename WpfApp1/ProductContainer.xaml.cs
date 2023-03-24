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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para ProductContainer.xaml
    /// </summary>
    public partial class ProductContainer : Page
    {
        private static string firstOptionSelect = string.Empty;
        private static string SecondOptionSelect = string.Empty;
        public ProductContainer()
        {
            InitializeComponent();
            ProductInformation data = SourceInformation();
            ListViewProductDescription.ItemsSource = data.ProductDescription?.ProductDescriptionList?.ToList();
            PlanOneDescription.ItemsSource = data.ProductGoalFirstOption?.ToList();
            PlanTwoDescription.ItemsSource = data.ProductGoalSecondOption?.ToList();
        }

        public static ProductInformation SourceInformation()
        {
            return new BusinessInformation().GetProductInformation;
        }

        private void FirstOption_Click(object sender, RoutedEventArgs e)
        {
            firstOptionSelect = "Seleccionaste el plan de 12 meses";
            SecondOptionSelect = string.Empty;
        }

        private void SecondOption_Click(object sender, RoutedEventArgs e)
        {
            firstOptionSelect = string.Empty;
            SecondOptionSelect = "Seleccionaste el plan de 18 meses";
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = !string.IsNullOrEmpty(firstOptionSelect) ? firstOptionSelect :
                !string.IsNullOrEmpty(SecondOptionSelect) ? SecondOptionSelect : "Debes seleccionar un plan";
            string caption = "Plan seleccionado";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        private void PlanOneDescription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class BusinessInformation
    {
        public ProductInformation GetProductInformation
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string pathImage = path + @"\Image\ok.png";
                return
             new ProductInformation
             {
                 ProductTitle = "SEGURO PLUS",
                 ProductGoalFirstOption = new List<ProductGoal>
                 {
                     new ProductGoal
                     {
                         IdGoal = 1,
                     GoalTitle = "12 Meses",
                     PriceTotalLabel = "Costo total:",
                     TotalPrice = 1200,
                     PriceByMonthLabel = "Mensualidad:",
                     TotalByMonth = 100
                     }
                 },
                 ProductGoalSecondOption = new List<ProductGoal>
                 {
                     new ProductGoal
                     {
                      IdGoal = 2,
                     GoalTitle = "18 Meses",
                     PriceTotalLabel = "Costo total:",
                     TotalPrice = 1900,
                     PriceByMonthLabel = "Mensualidad:",
                     TotalByMonth = 110
                     }
                 },
                 ProductDescription = new ProductDescription
                 {
                     Title = "Cobertura",
                     ProductDescriptionList = new List<ProductsDescription>
                  {
                      new ProductsDescription
                      {
                          Image=pathImage,
                          Title="Pérdida total",
                          Description="Diseño superior al 50% del valor de la moto. Deducible 10%"
                      },
                      new ProductsDescription
                      {
                          Image=pathImage,                          
                          Title="robo total de la moto",
                          Description="Deducible 20%"
                      },
                      new ProductsDescription
                      {
                          Image=pathImage,
                          Title="Responsabilidad civil",
                          Description="Hasta por $400.000"
                      },
                      new ProductsDescription
                      {
                          Image=pathImage,
                          Title="Apoyo legal",
                          Description="Apoyo de abogado y pago de fianza, asistencia vial"
                      }
                  }
                 }
             };
            }
        }
    }
    public class ProductInformation
    {
        public string? ProductTitle { get; set; }
        public ProductDescription? ProductDescription { get; set; }
        public IEnumerable<ProductGoal>? ProductGoalFirstOption { get; set; }
        public IEnumerable<ProductGoal>? ProductGoalSecondOption { get; set; }
    }

    public class ProductDescription
    {
        public string? Title { get; set; }
        public IEnumerable<ProductsDescription>? ProductDescriptionList { get; set; }
        
    }
    public class ProductsDescription
    {
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
    public class ProductGoal
    {
        public int? IdGoal { get; set; }
        public string? GoalTitle { get; set; }
        public string? PriceTotalLabel { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? PriceByMonthLabel { get; set; }
        public decimal? TotalByMonth { get; set; }        
    }
}