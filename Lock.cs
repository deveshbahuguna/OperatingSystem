using System;
using System.Threading;
class lockTest
{
 public static bool lockVar;
public static bool TestAndSet(ref bool lockVar) //This may not work as this function is not atomic and thus two threads accessing same var can cause error
{
  bool origVar=lockVar;
  lockVar=true;
  return origVar;
}

public static void DisplayWithlockVar()
 {
      while(TestAndSet(ref lockVar));
     //Here comes the critical code
     for(int i=0;i<5;++i)
        Console.WriteLine(i);
    //Now another critical code ends     
     lockVar=false;      
  }

    /// <summary>
    /// This is the entry point.
    /// </summary>
    /// <param name="args"></param>
public static void Main(String[] args)
 {
     Thread th1=new Thread(DisplayWithlockVar);
     Thread th2=new Thread(DisplayWithlockVar);
      th1.Start();
      th2.Start();
      Console.ReadLine();
  }
}