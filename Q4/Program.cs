using System;

class Program
{
    static void Main(string[] args)
    {
        int n=1,m=1;
        Stack<Tuple<int, int>> undoHistory = new Stack<Tuple<int, int>>();
        Stack<Tuple<int, int>> redoHistory = new Stack<Tuple<int, int>>();
        while(true){
            int move = int.Parse(Console.ReadLine());
            int x;
            bool canMove = false;
            if(move==11){break;}
            else if(move==9 && undoHistory.Count>0){
                Tuple<int,int> temp = new Tuple<int,int>(n,m);
                n=undoHistory.Peek().Item1; 
                m=undoHistory.Peek().Item2;  
                redoHistory.Push(temp); undoHistory.Pop();
                continue;
            }
            else if(move==10 && redoHistory.Count>0){
                Tuple<int,int> temp = new Tuple<int,int>(n,m);
                n=redoHistory.Peek().Item1; 
                m=redoHistory.Peek().Item2;
                undoHistory.Push(temp); redoHistory.Pop();
                continue;
            }
            else if(move!=9&&move!=10){ x = int.Parse(Console.ReadLine());
                canMove = TestMove(move,n,m,x);

                if(!canMove){continue;}
                Tuple<int,int> temp = new Tuple<int,int>(n,m);
                undoHistory.Push(temp);
                RealMove(move,ref n,ref m,x); 
                while(redoHistory.Count>0){redoHistory.Pop();}
            }
        }
        Console.WriteLine(Convert.ToChar(m-1+'A')+""+n);
    }
    static bool TestMove(int move,int n,int m,int x){
            switch(move){
                case 1: if(n+x<=8)       {return true;} break;
                case 2: if(n+x<=8&&m-x>0){return true;} break;
                case 3: if(m-x>0)        {return true;} break;
                case 4: if(n-x>0&&m-x>0) {return true;} break;
                case 5: if(n-x>0)        {return true;} break;
                case 6: if(n-x>0&&m+x<=8){return true;} break;
                case 7: if(m+x<=8)       {return true;} break;
                case 8: if(n+x<=8&&m+x<=8){return true;} break;

                default: return false;
            }
            return false;
        }
        static void RealMove(int move,ref int n,ref int m,int x){
            switch(move){
                case 1: if(n+x<=8)       {n+=x;} break;
                case 2: if(n+x<=8&&m-x>0){n+=x;m-=x;} break;
                case 3: if(m-x>0)        {m-=x;} break;
                case 4: if(n-x>0&&m-x>0) {n-=x;m-=x;} break;
                case 5: if(n-x>0)        {n-=x;} break;
                case 6: if(n-x>0&&m+x<=8){n-=x;m+=x;} break;
                case 7: if(m+x<=8)       {m+=x;} break;
                case 8: if(n+x<=8&&m+x<=8){n+=x;m+=x;} break;

                default: return;
            }
        }
}