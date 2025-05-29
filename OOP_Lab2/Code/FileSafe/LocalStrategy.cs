using OOP_Lab2.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.FileSafe
{
    class LocalStrategy
    {
        WorkWithLocal w_l;
        //WorkWithLocal w_l;
        //LocalStorage Lstorage;
        public void Execute()
        {
            w_l = new WorkWithLocal();
           // Lstorage = cs;
        }
        public void LocalCreate(string name,int typem,string content)
        {
            w_l.Create(name, content);
        }
        public void LocalUpdate()
        {
            //w_l.Update
        }
    }
}
