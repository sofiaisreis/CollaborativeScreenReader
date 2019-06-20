using UnityEngine;
using System;
using System.IO;

public class Logs : MonoBehaviour
{
    // Create a string array with the lines of text
    public string[] lines = { "First line", "Second line", "Third line" };

    // Set a variable to the Documents path.
    public string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public string feedbackType = null;
    public int whichFeedback = -1;

    public AudioRequest audioRequest;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            feedbackType = "Private";
            whichFeedback = 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            feedbackType = "Task-Dependent";
            whichFeedback = 2;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            feedbackType = "Public";
            whichFeedback = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Comecou a tarefa!");
            //StartLoggings();
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