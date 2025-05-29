
using Lab_OOP1;
using System.Collections.Generic;

namespace LabOOPTests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawCircle(0);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test2()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawCircle(-3333333);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test4()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawTriangle(0);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test3()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawCircle(3333333);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test5()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawEllipse(0,3);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test6()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawEllipse(3333333,0);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test7()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawEllipse(232, 333333);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test8()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawTriangleRect(15, 333333);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test9()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawTriangleRect(-15, 333333);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test10()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawTriangle(800000000);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test11()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawRectangle(-15, 25);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test12()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.DrawRectangle(800000000,(int)99.0);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test13()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 20);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test14()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 20);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test15()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 2);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test16()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 2);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test17()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 20);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test18()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Fill(0, 2);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test19()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Redraw(new TriangleRect());
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test20()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Redraw(new Ellipse());
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test21()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Redraw(new Triangle());
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test22()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Redraw(new Rectangle());
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test23()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.undraw(1,true);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test24()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.undraw(0, true);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test25()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.undraw(1, false);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test26()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.undraw(0, false);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test27()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            
            dr.CheckTransposition(1,true);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test28()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.CheckTransposition(1, false);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }

        [Test]
        public void Test29()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Change(0);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        
        

        [Test]
        public void Test30()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            Drawer dr = new Drawer();
            dr.Change(3);
            string result = consoleOutput.ToString();
            Assert.IsTrue(!result.Contains("."));
        }
        [Test]
        public void Test31()
        {
            
            Drawer dr = new Drawer();
            dr.GetData();
            
            Assert.IsTrue(dr.GetData() is not null);
        }
        [Test]
        public void Test32()
        {
           
            Drawer dr = new Drawer();
            dr.GetData();

            Assert.IsTrue(dr.GetData() is not null);
        }
        [Test]
        public void Test33()
        {
            
            Drawer dr = new Drawer();

            int k = 0;
            Assert.IsTrue(dr.Showinfo(ref k) is not null);
        }
        [Test]
        public void Test34()
        {
            
            Drawer dr = new Drawer();

            int k = 0;
            Assert.IsTrue(dr.Showinfo(ref k) is "");
        }
        [Test]
        public void Test35()
        {
            
            ChangeAction ch = new ChangeAction();
            
            
            Assert.IsTrue(ch.AddToStorageDelete(new List<IFigure>()));
        }
        [Test]
        public void Test36()
        {
            
            ChangeAction ch = new ChangeAction();
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            List<IFigure> l = new List<IFigure>();
            Assert.IsTrue(ch.Accept() is null);
        }
        [Test]
        public void Test37()
        {
            
           
            ChangeAction ch = new ChangeAction();
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            List<IFigure> l = new List<IFigure>();
            l.Add(new Circle());
            Assert.IsTrue(ch.Decline()!=l);

        }
        [Test]
        public void Test38()
        {
            
          
            ChangeAction ch = new ChangeAction();
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            ch.AddToStorageDelete(new List<IFigure>());
            ch.Decline();
            List<IFigure> l = new List<IFigure>();
            Assert.IsTrue(ch.Accept() != l);

        }
        [Test]
        public void Test39()
        {


            WorkWithFile w = new WorkWithFile();
            w.WriteInFile(new List<IFigure>(),"dataa.json");
            Assert.IsTrue(w.WriteInFile(new List<IFigure>(), "dataa.json"));

        }
        [Test]
        public void Test40()
        {


            WorkWithFile w = new WorkWithFile();
            Assert.IsTrue(w.WriteInFile(new List<IFigure>(), "dattmp.json"));

        }
        [Test]
        public void Test41()
        {


            WorkWithFile w = new WorkWithFile();
            
            Assert.IsTrue(w.ReadFromFile("datasasaa.json") is null);

        }
        [Test]
        public void Test42()
        {

            
            WorkWithFile w = new WorkWithFile();
            List<IFigure> k = new List<IFigure>();
            Circle c = new Circle();
            c.CenterX = 1;
            c.CenterY = 1;
            c.radius = 4;
            c.Color = 1;
            k.Add(c);
            w.WriteInFile(k, "dattmp.json");
            Assert.IsTrue(w.ReadFromFile("dattmp.json") is not null);

        }

    }
}