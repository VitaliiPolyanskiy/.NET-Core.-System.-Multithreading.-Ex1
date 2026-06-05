using System;
using System.Text;
using System.Threading;

public class Multithreading
{
    public static void MyThread()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Працює перший потік!");
            Thread.Sleep(100);
        }
        Console.WriteLine("Завершує роботу перший потік!");
    }

    public static void ThreadParam(object obj)
    {
        int delay = (int)obj;
        Thread t = Thread.CurrentThread;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Працює " + t.Name + " потік!");
            Thread.Sleep(delay);
        }
        Console.WriteLine("Завершує роботу " + t.Name + " потік!");

        Console.WriteLine("Ім'я потоку: {0}", t.Name);
        Console.WriteLine("Чи запущений потік: {0}", t.IsAlive);
        Console.WriteLine("Пріоритет потоку: {0}", t.Priority);
        Console.WriteLine("Статус потоку: {0}", t.ThreadState);
    }

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Thread t = Thread.CurrentThread;

        Console.WriteLine("Ім'я потоку: {0}", t.Name);
        t.Name = "Метод Main";
        Console.WriteLine("Ім'я потоку: {0}", t.Name);

        Console.WriteLine("Чи запущений потік: {0}", t.IsAlive);
        Console.WriteLine("Пріоритет потоку: {0}", t.Priority);
        Console.WriteLine("Статус потоку: {0}", t.ThreadState);

        Thread th = new Thread(new ThreadStart(MyThread));
        th.IsBackground = true;
        Console.WriteLine("Ім'я потоку: {0}", th.Name);
        Console.WriteLine("Чи запущений потік: {0}", th.IsAlive);
        Console.WriteLine("Статус потоку: {0}", th.ThreadState);
        th.Start();

        Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
        th1.IsBackground = true;
        th1.Name = "другий";
        th1.Start(200);

        Thread th2 = new Thread(new ParameterizedThreadStart(ThreadParam));
        th2.IsBackground = true;
        th2.Name = "третій";
        th2.Start(80);

        Console.ReadKey();

        Console.WriteLine("Ім'я потоку: {0}", th.Name);
        Console.WriteLine("Чи запущений потік: {0}", th.IsAlive);
        Console.WriteLine("Статус потоку: {0}", th.ThreadState);
    }

    /*
       Потік є або фоновим, або основним (за замовчуванням).
       Вони відрізняються за принципом дії. 
       Якщо працює фоновий потік і відбувається закриття додатка, потік також вивантажується з пам'яті. 
       Основний потік при закритті додатка залишиться в пам'яті.
       Якщо всі основні потоки, що належать процесу, завершилися, загальномовне середовище виконання завершує процес, 
       викликаючи метод Abort для всіх фонових потоків, які ще діють.
        
       public Thread(
       ThreadStart start – делегат, який вказує на потокову функцію.
       );
       public delegate void ThreadStart();

       public Thread(ParameterizedThreadStart start - делегат, який посилається на потокову функцію з 
                           параметром. 
       );

       public delegate void ParameterizedThreadStart(
       object obj – об'єкт, який буде передаватися в потокову функцію.
       );  
    */
}