using System;
using System.Threading;

public class Multithreading
{
    public static void MyThread()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Работает первый поток!");
            Thread.Sleep(100);
        }
        Console.WriteLine("Завершает работу первый поток!");
    }

    public static void ThreadParam(object obj)
    {
        int delay = (int)obj;
        Thread t = Thread.CurrentThread;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Работает " + t.Name + " поток!");
            Thread.Sleep(delay);
        }
        Console.WriteLine("Завершает работу " + t.Name + " поток!");

        Console.WriteLine("Имя потока: {0}", t.Name);
        Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
        Console.WriteLine("Приоритет потока: {0}", t.Priority);
        Console.WriteLine("Статус потока: {0}", t.ThreadState);
    }

    public static void Main()
    {
        Thread t = Thread.CurrentThread;

        Console.WriteLine("Имя потока: {0}", t.Name);
        t.Name = "Метод Main";
        Console.WriteLine("Имя потока: {0}", t.Name);

        Console.WriteLine("Запущен ли поток: {0}", t.IsAlive);
        Console.WriteLine("Приоритет потока: {0}", t.Priority);
        Console.WriteLine("Статус потока: {0}", t.ThreadState);

        Thread th = new Thread(new ThreadStart(MyThread));
        th.IsBackground = true;
        Console.WriteLine("Имя потока: {0}", th.Name);
        Console.WriteLine("Запущен ли поток: {0}", th.IsAlive);
        Console.WriteLine("Статус потока: {0}", th.ThreadState);
        th.Start();

        Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
        th1.IsBackground = true;
        th1.Name = "второй";
        th1.Start(200);

        Thread th2 = new Thread(new ParameterizedThreadStart(ThreadParam));
        th2.IsBackground = true;
        th2.Name = "третий";
        th2.Start(80);

        Console.ReadKey();

        Console.WriteLine("Имя потока: {0}", th.Name);
        Console.WriteLine("Запущен ли поток: {0}", th.IsAlive);
        Console.WriteLine("Статус потока: {0}", th.ThreadState);
    }

    /*
       Поток является либо фоновым, либо основным (по умолчанию).
       Они отличаются по принципу действия. 
       Если работает фоновый поток и происходит закрытие приложения, поток также выгружается из памяти. 
       Основной же поток при закрытии приложения останется в памяти.
       Если все основные потоки, принадлежащие процессу, завершились, общеязыковая среда выполнения завершает процесс, 
       вызывая метод Abort для всех фоновых потоков, которые еще действуют.
        
       public Thread(
       ThreadStart start – делегат, который указывает на потоковую функцию.
       );
       public delegate void ThreadStart();

       public Thread(ParameterizedThreadStart start - делегат, который ссылается на потоковую функцию с 
                           параметром. 
       );

       public delegate void ParameterizedThreadStart(
       object obj – объект, который будет передаваться в потоковую функцию.
       );  
       */
}
