using OOP_Lab2.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2.FileSafe
{
    class CloudStrategy
    {
        WorkWithCloud w_c;
        //WorkWithLocal w_l;
        CloudStorage Cstorage;
        Checker checker = new Checker();
        string folder;
        
        public void Execute(CloudStorage cs,User usr,Document doc,string folder)
        {
            w_c = new WorkWithCloud();
            this.folder = folder;
            Cstorage = cs;
            Console.WriteLine("1 - Сохранить в облако, 2 - Список файлов в облаке, 3 - Поменять содержимое файла, 4 - Удалить файл");
            int choise = checker.CheckWithBorders(Console.ReadLine(),1,3, "1 - Сохранить в облако, 2 - Список файлов в облаке, 3 - Поменять содержимое файла, 4 - Удалить файл", 2);
            while (true)
            {
                if (choise == 1)
                {
                    if (CloudSave(doc) == -1)
                    {
                        Console.WriteLine("Такой файл уже существует в облаке, переименуйте его");
                        return;
                    }

                }
                if(choise == 2)
                {
                    CloudGetInfo(folder);
                }
                if(choise == 3)
                {
                    CloudUpdate(doc);
                }
                if(choise == 4)
                {
                    if (doc.UserName == usr.Name)
                    {
                        CloudDelete();
                    }
                    else
                    {
                        Console.WriteLine("Нет прав для удаления");
                        return;
                    }
                }
            }
        }
        public int CloudSave(Document doc)
        {
            
            string id = w_c.UploadFile(doc.name, doc.type, "2", "2");
            if (id == "-1") return -1;
            Cstorage.fileId = id;
            doc.FileId = id;
            //Cstorage.name = doc.name;
            return 0;
        }
        public void CloudUpdate(Document doc)
        {

            string a = w_c.UpdateFile(doc.name, doc.type, "2", "2", Cstorage.fileId);
            Cstorage.name = a;
        }
        public void CloudGetInfo(string folder)
        {
            var a = w_c.GetFiles(folder);
            foreach (var b in a)
            {
                Console.WriteLine(b.Name + " " + b.Size + " " + b.Id);
            }
        }

        public void CloudDelete()
        {
            w_c.Delete(Cstorage.fileId, "1Iiy2UToZeMaFiviRQRwIf8aZJoxncAws");
            Cstorage.fileId = "0";
        }
    }
}
