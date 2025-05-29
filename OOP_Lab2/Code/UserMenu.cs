using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab2
{
    class UserMenu
    {
        Checker checker = new Checker();
        List<Document> docs = new List<Document>();
        ManageMemFile<Document> manager = new ManageMemFile<Document>();
        User currUser;
        public UserMenu(User user)
        {
            docs = manager.GetCollection("mem1.json");
            if (docs == null) docs = new List<Document>();
            currUser = user;
        }
        public void Start()
        {
            while (true)
            {
                string output = "0 - Создать файл, 1 - Выбрать файл из уже созданных, -1 - Выход ";
                Console.WriteLine(output);
                int choise = checker.CheckWithBorders(Console.ReadLine(), -1, 1, output, 2);
                if (choise == 0)
                {
                    output = "Введите имя файла";
                    Console.WriteLine(output);
                    string name = Console.ReadLine();
                    while (checker.CheckStringInCollectionDoc(docs, name))
                    {
                        Clear(2);
                        Console.WriteLine("Ошибка такой файл есть! " + output);
                        name = Console.ReadLine();
                    }
                    //Worker.Add(Users, name);

                    //Clear(4);
                    output = "0 - txt, 1 - json, 2 - md, 3 - xml";
                    Console.WriteLine(output);
                    choise = checker.CheckWithBorders(Console.ReadLine(), 0, 3, output, 2);
                    Document doc;
                    if (choise == 0)
                    {
                        doc = new Document(currUser, name + ".txt", 0);
                        docs.Add(doc);
                        currUser.TemporaryDocument = doc;
                    }
                    if (choise == 1)
                    {
                        doc = new Document(currUser, name + ".json", 1);
                        docs.Add(doc);
                        currUser.TemporaryDocument = doc;
                    }
                    if (choise == 2)
                    {
                        doc = new Document(currUser, name + ".md", 2);
                        docs.Add(doc);
                        currUser.TemporaryDocument = doc;
                    }
                    if (choise == 3)
                    {
                        doc = new Document(currUser, name + ".xml", 3);
                        docs.Add(doc);
                        currUser.TemporaryDocument = doc;
                    }
                    Clear(6);
                    currUser.CurrentStrategy = "admin";
                    //currUser.TemporaryDocument = doc;
                    currUser.SetStrategy();
                    currUser.ExecuteStrategy();
                    manager.WriteCollection(docs, "mem1.json");
                }
            }
        }
        public void Clear(int count)
        {
            int tp = Console.GetCursorPosition().Top;
            for (int i = tp; i < tp + count; ++i)
            {
                Console.SetCursorPosition(0, i - count);
                Console.Write("\r");
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, tp - count);
        }
    }
}
