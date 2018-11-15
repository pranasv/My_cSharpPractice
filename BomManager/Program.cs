using System;
using System.Collections.Generic;
using DataLayer;


namespace BusinessLayer
{
    class Program
    {
        public static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            foreach (Product item in productService.GetAllProducts())
            {
                Console.WriteLine(item);
                foreach (int childId in productService.GetProductChilds(item))
                {
                    Console.WriteLine("Child's Id: " + childId);
                }

            }



            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}