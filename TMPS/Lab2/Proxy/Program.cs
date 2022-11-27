using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IImage
    {
        void DisplayImage();
    }

    public class RealImage : IImage
    {
        private string Filename { get; set; }
        public RealImage(string filename)
        {
            Filename = filename;
            LoadImage();
        }
        public void LoadImage()
        {
            Console.WriteLine("Загружаем картинку : " + Filename);
        }
        public void DisplayImage()
        {
            Console.WriteLine("Показываем картинку : " + Filename);
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage realImage = null;
        private string Filename { get; set; }
        public ProxyImage(string filename)
        {
            Filename = filename;
        }
        public void DisplayImage()
        {
            if (realImage == null)
            {
                realImage = new RealImage(Filename);
            }
            realImage.DisplayImage();
        }
    }
    class Program
    {
        static void Main()
        {
            IImage Image1 = new ProxyImage("Картиночка с котиками");

            Console.WriteLine("Вызываем метод DisplayImage в первый раз :");
            Image1.DisplayImage(); 
            Console.WriteLine("\nВызываем метод DisplayImage во второй раз :");
            Image1.DisplayImage(); // загрузка уже не нужна
            Console.WriteLine("\nВызываем метод DisplayImage в третий раз :");
            Image1.DisplayImage(); 
            Console.WriteLine("\n============================================================");
            IImage Image2 = new ProxyImage("Картинка с зайчиком");
            Console.WriteLine("\nВызываем метод DisplayImage в первый раз :");
            Image2.DisplayImage(); 
            Console.WriteLine("\nВызываем метод DisplayImage во второй раз :");
            Image2.DisplayImage();
            Console.ReadKey();
        }
    }
}
