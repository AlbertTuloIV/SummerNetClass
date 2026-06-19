using System;

namespace Midterm
{
   struct csharp
    {
        int x, y, z;
        public csharp()
        {
            x = 0; y = 0; z = 0;
        }
        public csharp(int a, int b, int c)
        {
            x = a; y = b; z = c;
        }
        public void display()
        {
            Console.WriteLine(x + " " + y + " " + z);
        }
        public void change(int z)
        {
            this.z = z;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            csharp s1 = new csharp(5, 6, 8);
            csharp s3 = new csharp();
            s3 = s1;
            s3.change(100);
            s1.display();
            s3.display();
        }
    }
}