using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Lab2.FileSafe
{
    public class WorkWithLocal
    {
        public void Create(string name,string content)
        {
            Task.Delay(190);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+name, content);
        }
        public void Delete(string name)
        {
           
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + name))File.Delete(AppDomain.CurrentDomain.BaseDirectory + name);
        }
        public void Update(string name, string content)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + name, content);
        }
        

    }
}
