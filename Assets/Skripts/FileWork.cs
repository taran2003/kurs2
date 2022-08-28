using System.IO;
using System.Collections;
using System.Collections.Generic;


public class FileWork
{

    static public string ReadFile(string path)
    {
        string CardNum = "1";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            StreamReader fin = new StreamReader(path);
            CardNum = fin.ReadLine();
            fin.Close();
        }
        return CardNum;
    }

    static public void Write(string path, string rez, bool add = true)
    {
        StreamWriter fout = new StreamWriter(path, add);
        fout.Write(rez);
        fout.Close();
    }
}
