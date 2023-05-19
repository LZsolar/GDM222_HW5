using System;

class Program
{
    static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        Dictionary<string,string> dict = new Dictionary<string,string>();
        int[] intTrack = new int[n];
        char[] charTrack= new char[m];
        for(int i=0;i<m;i++){
            charTrack[i]='A';
        }

        while(true){
            string item = Console.ReadLine();
            if(item=="Stop"){break;}
            
            string code = getCode(ref intTrack,ref charTrack,n,m);

            dict.Add(code,item);
            intRun(ref intTrack,n,0,ref charTrack,m);
        }

        string finding = Console.ReadLine();
        bool isValid = dict.ContainsKey(finding);
        if(isValid){Console.WriteLine(dict[finding]);}
        else{Console.WriteLine("Not found!");}
    }

    static void intRun(ref int[] intTrack,int n,int now ,ref char[] charTrack,int m){
        if(now==n){ charRun(ref charTrack,m,0); return;}

        if(intTrack[now]<9){intTrack[now]++;}
        else if(intTrack[now]==9){
            intTrack[now]=0; 
            intRun(ref intTrack,n,now+1,ref charTrack,m);
        }
    }
    static void charRun(ref char[] charTrack,int m,int now){
        if(now==m){ return;}
        Console.Write(charTrack[now]);

        if(charTrack[now]!='Z'){charTrack[now]=Convert.ToChar(charTrack[now]+1);}
        else if(charTrack[now]=='Z'){
            charTrack[now]='A'; 
            charRun(ref charTrack,m,now+1);
        }
    }

    static string getCode(ref int[] intTrack,ref char[] charTrack,int n,int m){
        string code ="";
        for(int i=m-1;i>=0;i--){
            code = code +charTrack[i];
        }
        for(int i=n-1;i>=0;i--){
            code = code + intTrack[i];
        }
        return code;
    }
}