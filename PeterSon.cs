using System;
using System.Threading;
class Hello
{
 public static bool[] flag=new bool[2];
 public static int turn;
 public static void DisplayThreadSafe(object j)
 {
     int k=(int)j;
     Console.WriteLine(k);
     int i=1-k;
    flag[k]=true;
     turn=i;
    while(flag[i]&&(turn==i))
    {
      Console.WriteLine(flag[i]+"  "+turn); 
       Console.WriteLine("Ohh no process {0} have to wait",turn);
     }
    Console.WriteLine(" {0} is finished",i);
    for(int d=0;d<5;++d)    //Critical code comes till flag is falsed
       Console.WriteLine(d);
    flag[k]=false;
 }

 public static void Main(String[] args)
{flag[0]=flag[1]=false;
  Thread thread1=new Thread(DisplayThreadSafe);
  object ob1=0;
  object ob2=1;
  Thread thread2=new Thread(DisplayThreadSafe);
  thread1.Start(ob1);
//  Thread.Sleep(100);
  thread2.Start(ob2);
 Console.WriteLine("In main thread");
  Console.WriteLine();

}

}