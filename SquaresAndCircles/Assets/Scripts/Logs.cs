using UnityEngine;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Logs : MonoBehaviour
{
    // Create a string array with the lines of text
    //public string[] lines = { "First line", "Second line", "Third line" };
    // Set a variable to the Documents path.
    public string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public string feedbackType = null;
    //public int whichFeedback = -1;
    public int timer = 0;
    public Timer Timer1;
    public int tarefaOn = -1;
    DateTime taskStart;

    public GameObject User1Pos;
    public GameObject User2Pos;
    public GameObject User1LeftHandPos;
    public GameObject User2LeftHandPos;

    public List<string> text = new List<string>();

    public void Start()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            feedbackType = "Private";
            ColliderObj.feedbackType = 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            feedbackType = "Task-Dependent";
            ColliderObj.feedbackType = 2;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            feedbackType = "Public";
            ColliderObj.feedbackType = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Comecou a tarefa!");
            tarefaOn = 1;
            taskStart = DateTime.Now;

            text.Add("TimeStamp:Action:Value");
            
            //StartLoggings();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tarefaOn = 0;
            print("Tarefa finito");

            //print("Tarefa Terminada! Tempo: " + current);
            DateTime now = DateTime.Now;
            using (StreamWriter sw = new StreamWriter(@"kinglog" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
            {
                foreach (string s in text)
                {
                    sw.WriteLine(s);
                    //System.IO.File.WriteAllText(@"Frame-A-Frame_Logs.txt", s);
                }
            }
        }

        if (tarefaOn == 1)
        {
            TimeSpan timestamp = DateTime.Now - taskStart;

            System.Random r = new System.Random();

            text.Add(timestamp.TotalMilliseconds + ":" + "Touch" + ":" + r.Next(0, 100));

            //current += TimeSpan.FromSeconds(1);
            //print("Current: " + timestamp.TotalMilliseconds);
        }

        if ( tarefaOn == 0 )
        {
            

        }
        // Write the string array to a new file named "WriteLines.txt".
        /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }*/

        

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: " + feedbackType);
    }
}
// The example creates a file named "WriteLines.txt" with the following contents:
// First line
// Second line
// Third line