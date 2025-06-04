using Lab_oop1;
using System;
using System.Collections.Generic;

public class Program
{
    static void SafeSetCursorPosition(int left, int top)
    {
        if (left >= 0 && left < Console.WindowWidth &&
            top >= 0 && top < Console.WindowHeight)
        {
            Console.SetCursorPosition(left, top);
        }
    }

    static void Clear(int k)
    {
        for (int i = 0; i < k; ++i)
        {
            SafeSetCursorPosition(0, 2 + i);
            Console.Write("\r");
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }

    private static void Main(string[] args)
    {
        try
        {
            // Установка размера консоли
            Console.SetWindowSize(240, 60);
            Console.SetBufferSize(240, 60);
        }
        catch (Exception)
        {
            // Если не удалось установить размер - работаем с текущим
        }

        Drawer draw = new Drawer();
        WorkWithFile worker = new WorkWithFile();
        ChangeAction change = new ChangeAction();
        Checker check = new Checker();
        int CounterOfFigures = 0;
        string text1 = "Введите, что хотите сделать -1 - выход 0 - нарисовать фигуру, 1 - удалить фигуру, 2 - залить фигуру, 3 - сдвинуть фигуру, 4 - сохранить в файл, 5 - прочесть из файла, CTRL+X - вернуть предыдущее действие, CTRL+Y - отменить возвращение к предыдущему состоянию  ";
        Console.WriteLine(text1);

        // Рисуем границы с учетом текущего размера консоли
        int rightBorder = Console.WindowWidth - 1;
        int bottomBorder = Console.WindowHeight - 1;

        for (int i = 11; i < bottomBorder; ++i)
        {
            SafeSetCursorPosition(0, i);
            Console.Write("=");
            SafeSetCursorPosition(rightBorder, i);
            Console.Write("=");
        }

        for (int i = 0; i < Console.WindowWidth; ++i)
        {
            SafeSetCursorPosition(i, 11);
            Console.Write("=");
            SafeSetCursorPosition(i, bottomBorder);
            Console.Write("=");
        }

        SafeSetCursorPosition(0, 2);
        change.AddToStorageDelete(new List<IFigure>());

        while (true)
        {
            int parametr = 0;
            SafeSetCursorPosition(0, 2);

            string paraam = Console.ReadLine();
            if (paraam == "\u0018" || paraam == "\u0019")
            {
                Clear(1);
                if (paraam == "\u0018")
                {
                    List<IFigure> list = change.Decline();
                    if (list is not null) draw.DrawCanva(list);
                }
                else if (paraam == "\u0019")
                {
                    List<IFigure> list = change.Accept();
                    if (list is not null) draw.DrawCanva(list);
                }

                // Перерисовка границ
                for (int i = 11; i < bottomBorder; ++i)
                {
                    SafeSetCursorPosition(0, i);
                    Console.Write("=");
                    SafeSetCursorPosition(rightBorder, i);
                    Console.Write("=");
                }

                for (int i = 0; i < Console.WindowWidth; ++i)
                {
                    SafeSetCursorPosition(i, 11);
                    Console.Write("=");
                    SafeSetCursorPosition(i, bottomBorder);
                    Console.Write("=");
                }

                SafeSetCursorPosition(0, 2);
            }
            else
            {
                parametr = check.CheckWithBorders(paraam, -1, 5, text1);
                if (parametr == -2) continue;

                CounterOfFigures++;
                switch (parametr)
                {
                    case 0:
                        if (CounterOfFigures > 50)
                        {
                            Clear(1);
                            continue;
                        }
                        text1 = "Введите тип фигуры, 0 - круг (3<R<20) 1 - треугольник равносторонний (3<a<20) 2 - треугольник прямоугольный(3<a<20,3<b<20) 3 - эллипс(3<r1<20,3<r2<20) 4 - прямоугольник(3<a<20,3<b<20) ";
                        Console.WriteLine(text1);
                        int param = check.CheckWithBorders(Console.ReadLine(), 0, 4, text1);
                        HandleFigureDrawing(draw, check, param);
                        break;

                    case 1:
                        HandleFigureDeletion(draw, check);
                        CounterOfFigures--;
                        break;

                    case 2:
                        HandleFigureFilling(draw, check);
                        break;

                    case 3:
                        HandleFigureMoving(draw, check);
                        break;

                    case 4:
                        worker.WriteInFile(draw.GetData(), "data.json");
                        Clear(5);
                        break;

                    case 5:
                        draw.DrawCanva(worker.ReadFromFile("data.json"));
                        Clear(5);
                        RedrawBorders(rightBorder, bottomBorder);
                        SafeSetCursorPosition(0, 2);
                        break;
                }

                worker.WriteInFile(draw.GetData(), "data1.json");
                change.AddToStorageDelete(worker.ReadFromFile("data1.json"));

                if (parametr == -1) break;
            }

            SafeSetCursorPosition(0, 0);
            text1 = "Введите, что хотите сделать -1 - выход 0 - нарисовать фигуру, 1 - удалить фигуру, 2 - залить фигуру, 3 - сдвинуть фигуру, 4 - сохранить в файл, 5 - прочесть из файла, CTRL+X - вернуть предыдущее действие, CTRL+Y - отменить возвращение к предыдущему состоянию  ";
            Console.WriteLine(text1);
        }
    }

    private static void HandleFigureDrawing(Drawer draw, Checker check, int param)
    {
        string text1;
        switch (param)
        {
            case 0:
                text1 = "Введите радиус круга";
                Console.WriteLine(text1);
                int radius = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                draw.DrawCircle(radius);
                Clear(5);
                break;

            case 1:
                text1 = "Введите сторону треугольника";
                Console.WriteLine(text1);
                int a = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                draw.DrawTriangle(a);
                Clear(5);
                break;

            case 2:
                text1 = "Введите длину первой стороны";
                Console.WriteLine(text1);
                int a1 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                text1 = "Введите длину второй стороны";
                Console.WriteLine(text1);
                int b1 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                draw.DrawTriangleRect(a1, b1);
                Clear(7);
                break;

            case 3:
                text1 = "Введите радиус по вертикали";
                Console.WriteLine(text1);
                int r1 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                text1 = "Введите радиус по горизонтали";
                Console.WriteLine(text1);
                int r2 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                draw.DrawEllipse(r1, r2);
                Clear(7);
                break;

            case 4:
                text1 = "Введите длину первой стороны";
                Console.WriteLine(text1);
                int a2 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                text1 = "Введите длину второй стороны";
                Console.WriteLine(text1);
                int b2 = check.CheckWithBorders(Console.ReadLine(), 3, 20, text1);
                draw.DrawRectangle(a2, b2);
                Clear(7);
                break;
        }
    }

    private static void HandleFigureDeletion(Drawer draw, Checker check)
    {
        string text1 = "Удалить фигуру ";
        int k = 0;
        string txt = draw.Showinfo(ref k);
        if (k == 0)
        {
            Clear(1);
            return;
        }
        draw.undraw(check.CheckWithBorders(Console.ReadLine(), 0, k - 1, text1 + txt), false);
        Clear(4);
    }

    private static void HandleFigureFilling(Drawer draw, Checker check)
    {
        string text1 = "Залить фигуру ";
        int k = 0;
        string txt = draw.Showinfo(ref k);
        if (k == 0)
        {
            Clear(1);
            return;
        }
        int figr = check.CheckWithBorders(Console.ReadLine(), 0, k - 1, text1 + txt);
        text1 = $"Введите опцию заливки :0 - " + " ' ' " + " 1 - / 2 - #";
        Console.WriteLine(text1);
        int color = check.CheckWithBorders(Console.ReadLine(), 0, 2, text1);
        draw.Fill(figr, color);
        Clear(5);
    }

    private static void HandleFigureMoving(Drawer draw, Checker check)
    {
        string text1 = "Сдвинуть фигуру ";
        int k = 0;
        string txt = draw.Showinfo(ref k);
        if (k == 0)
        {
            Clear(1);
            return;
        }
        int figr = check.CheckWithBorders(Console.ReadLine(), 0, k - 1, text1 + txt);
        draw.Change(figr);
        Clear(5);
    }

    private static void RedrawBorders(int rightBorder, int bottomBorder)
    {
        for (int i = 11; i < bottomBorder; ++i)
        {
            SafeSetCursorPosition(0, i);
            Console.Write("=");
            SafeSetCursorPosition(rightBorder, i);
            Console.Write("=");
        }

        for (int i = 0; i < Console.WindowWidth; ++i)
        {
            SafeSetCursorPosition(i, 11);
            Console.Write("=");
            SafeSetCursorPosition(i, bottomBorder);
            Console.Write("=");
        }
    }
}
