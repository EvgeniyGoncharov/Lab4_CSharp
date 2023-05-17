using System.Collections;

namespace lab2
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
    public delegate void Handler(int a);
    class Program
    {
        public static event Handler handler;
        public static void ShowNum1(int a)
        {
            Console.WriteLine("число 1 метода: " + a);
        }
        public static void ShowNum2(int a)
        {
            Console.WriteLine("число 2 метода: " + a);
        }
        public static void ShowNum3(int a)
        {
            Console.WriteLine("число 3 метода: " + a);
        }


        static public void Main(String[] args) 
        {
            /*handler += ShowNum1;
            handler += ShowNum1;

            handler += ShowNum2;
            handler += ShowNum3;
            handler(0);*/
            //задание 1

            KeySelector<string> ks = new KeySelector<string>(MagazineCollection<string>.GetKey);

            MagazineCollection<string> magCol1 = new MagazineCollection<string>(ks);
            MagazineCollection<string> magCol2 = new MagazineCollection<string>(ks);

            Listener listener = new Listener();
            magCol1.MagazinesChanged += listener.magazinesChanged;
            magCol2.MagazinesChanged += listener.magazinesChanged;


            Magazine magazine1 = new Magazine("dadadad", new DateTime(2000, 1, 1), 5);
            Magazine magazine2 = new Magazine("dadadad", new DateTime(2000, 1, 1), 6);
            Magazine magazine3 = new Magazine("dadadad", new DateTime(2000, 1, 1), 3);
            Magazine magazine4 = new Magazine("dadadad", new DateTime(2000, 1, 1), 4);
            List<Magazine> list = new List<Magazine>
            {
                magazine1, magazine2, magazine3,
            };

            /*Listener listener = new Listener();
            magCol1.MagazinesChanged += listener.magazinesChanged;
            magCol2.MagazinesChanged += listener.magazinesChanged;*/
            /*magCol1.AddMagazines(list);
            Console.WriteLine(magCol1.Replace(magazine1,magazine4 ));
            Console.WriteLine(magCol1.ToString());
            magCol1.AddMagazines(list);
            magCol1.Replace(magazine1, magazine4);
            Console.WriteLine(listener.ToString());*/
            //задание 2

            //задание 3

            //задание 4

        }
    }
    public enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }
   
}