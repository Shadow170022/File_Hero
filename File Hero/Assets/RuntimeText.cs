using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RuntimeText: MonoBehaviour
{
    private string textoTotal = "";

    public void WriteString(string texto)
    {
        textoTotal += texto;
        string path = Application.persistentDataPath + "/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(texto);
        writer.Close();
        /*StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();*/
    }
    
    public List<string> ReadString()
    {
        List<string> timesList = new List<string>();
        string path = Application.persistentDataPath + "/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());
        while (!reader.EndOfStream){
            timesList.Add(reader.ReadLine());
        }
        reader.Close();
        return timesList;
    }

    public void ClearFile()
    {
        string path = Application.persistentDataPath + "/test.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine("");
        writer.Close();
    }
}