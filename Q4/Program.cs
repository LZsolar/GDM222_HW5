using System;

class Program
{
    static void Main(string[] args)
    {
        int n=1,m=1;
        int redoMain=0,redoSub=0;
        Stack<int> redo = new Stack<int>();
        while(true){
            int move = int.Parse(Console.ReadLine());
            if(move==11){break;}

            bool canMove = false;
            switch(move){
               // case 9: if(redoMain!=0)
                case 10:
                default: canMove = TestMove(move,n,m); break;
            }
            if(!canMove){continue;}
            RealMove(move,ref n,ref m);
        }
        Console.WriteLine(Convert.ToChar(n-1+'A')+" "+m);
    }
    static bool TestMove(int move,int n,int m){
            switch(move){
                case 1: if(n+1<=8)       {return true;} break;
                case 2: if(n+1<=8&&m-1>0){return true;} break;
                case 3: if(m-1>0)        {return true;} break;
                case 4: if(n-1>0&&m-1>0) {return true;} break;
                case 5: if(n-1>0)        {return true;} break;
                case 6: if(n-1>0&&m+1<=8){return true;} break;
                case 7: if(m+1<=8)       {return true;} break;
                case 8: if(n+1<=8&&m+1<=8){return true;} break;

                default: return false;
            }
            return false;
        }
        static void RealMove(int move,ref int n,ref int m){
            switch(move){
                case 1: if(n+1<=8)       {n++;} break;
                case 2: if(n+1<=8&&m-1>0){n++;m--;} break;
                case 3: if(m-1>0)        {m--;} break;
                case 4: if(n-1>0&&m-1>0) {n--;m--;} break;
                case 5: if(n-1>0)        {n--;} break;
                case 6: if(n-1>0&&m+1<=8){n--;m++;} break;
                case 7: if(m+1<=8)       {m++;} break;
                case 8: if(n+1<=8&&m+1<=8){n++;m++;} break;

                default: return;
            }
        }
}