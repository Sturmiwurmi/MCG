using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Quest 
{
    // quest.txt datei ist abhänig vom Namen 
    private string questname;
    private int Questprogress; // aktuellerstand 
    private int queststages; // wieviele dialoge 
    private string[] dialogues; 
    public Quest(string pName)
    {
        questname = pName;
        Questprogress = 0;

        countqueststages(); 
        dialogues = new string[queststages];
        filldialogues(); 
    }

    void countqueststages()
    {

        TextAsset file = Resources.Load<TextAsset>("dialogues/" + questname + "quest");

        if (file == null)
        {
            file = Resources.Load<TextAsset>("dialogues/defaultquest");
        }

        int lineCount = 0;

        using (StringReader reader = new StringReader(file.text))
        {
            while (reader.Peek() != -1) //Beachte, dass reader.Peek() verwendet wird, um zu überprüfen, ob es noch weitere Zeilen gibt, anstatt reader.EndOfStream, wie es im vorherigen Beispiel gezeigt wurde. reader.Peek() gibt den nächsten Zeichencode zurück, ohne ihn aus der Stream-Position zu entfernen, so dass wir mit -1 überprüfen können, ob das Ende des Streams erreicht wurde.
            {
                string line = reader.ReadLine();
                lineCount++;
            }
        }

        queststages = lineCount; // 
    }


    void filldialogues()
    {
        TextAsset file = Resources.Load<TextAsset>("dialogues/"+ questname+"quest");

        if (file == null)
        {
            file = Resources.Load<TextAsset>("dialogues/defaultquest");
        }

        int lineCount = 0;

        using (StringReader reader = new StringReader(file.text))
        {
            while (reader.Peek() != -1) //Beachte, dass reader.Peek() verwendet wird, um zu überprüfen, ob es noch weitere Zeilen gibt, anstatt reader.EndOfStream, wie es im vorherigen Beispiel gezeigt wurde. reader.Peek() gibt den nächsten Zeichencode zurück, ohne ihn aus der Stream-Position zu entfernen, so dass wir mit -1 überprüfen können, ob das Ende des Streams erreicht wurde.
            {
                string line = reader.ReadLine();                
                dialogues[lineCount] = line;
                lineCount++;
            }
        }
    }
   

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public string getQuestName()
    {
        return questname;
    }
    public int getQueststages()
    {
        return queststages;
    }
    public int getQuestprogress()
    {
        return Questprogress;
    }
    public string getDialogue()
    {
        return dialogues[Questprogress];
    }
}
