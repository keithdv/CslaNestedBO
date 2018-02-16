using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaNestedBO.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var bo = Csla.DataPortal.Fetch<SimpleBO>();
            long propertyChangedCount = 0;

            void Traverse(SimpleBO child)
            {
                propertyChangedCount = 0;
                child.Name = "Keith";
                Console.WriteLine($"Depth: {child.Depth} PropertyChangedCount: {propertyChangedCount}");
                if(child.Child != null)
                {
                    Traverse(child.Child);
                }
            }

            bo.PropertyChanged += (o, e) => propertyChangedCount++;

            Traverse(bo);

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
