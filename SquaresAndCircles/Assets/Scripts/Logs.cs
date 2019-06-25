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
    public GameObject User1RightHandPos;
    public GameObject User2RightHandPos;
    public GameObject User1PosToque; //vazio, mas existe; coords, com toque
    public GameObject User2PosToque; //vazio, mas existe; coords, com toque
    public GameObject User1MaoDeToque;
    public GameObject User2MaoDeToque;
    public GameObject User1TouchType; //Tap, DoubleTap, Drag
    public GameObject User2TouchType; //Tap, DoubleTap, Drag
    public GameObject User1Action; //Select, Exit, Error
    public GameObject User2Action; //Select, Exit, Error
    public GameObject HoverU1;
    public GameObject HoverU2;
    public GameObject NQuadToSelect;
    public GameObject NCircToSelect;
    public GameObject LastCollidingObj1;
    public GameObject LastCollidingObj2;
    public GameObject HandCube1Pos;
    public GameObject HandCube2Pos;

    //Time:User:UserPos:UserRHPos:UserLHPos:UserPosToque:UserMaoDeToque:UserTouchType:UserAction:HoverUnityName:HoverObjectType:NQuadToSelect:NCircToSelect:LastCollidingObj:HandCubePos

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

            //StartLogging
            text.Add("Time:User:UserPos:UserRHPos:UserLHPos:UserPosToque:UserMaoDeToque:UserTouchType:UserAction:HoverUnityName:HoverObjectType:NQuadToSelect:NCircToSelect:LastCollidingObj:HandCubePos");
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
            LogFileFrameWriting();
            
        }

        if ( tarefaOn == 0 )
        {
            

        }

    }

    private void LogFileFrameWriting()
    {
        TimeSpan timestamp = DateTime.Now - taskStart;
        //System.Random r = new System.Random();
        Vector3 User1Posicao;
        Vector3 User2Posicao;
        Vector3 U1RH;
        Vector3 U1LH;
        Vector3 U2RH;
        Vector3 U2LH;
        Vector3 PosTouchU1;
        Vector3 PosTouchU2;
        string MaoUser1;
        string MaoUser2;
        string U1TouchType;
        string U2TouchType;
        string U1Action;
        string U2Action;
        GameObject HoverUNU1; //unity name
        GameObject HoverUNU2;
        string HoverOTU1; //obj type
        string HoverOTU2;
        int NumQuadToSelect; //pelo User1
        int NumCircToSelect; //pelo User2
        GameObject U1LastColliding;
        GameObject U2LastColliding;
        Vector3 HandCubeU1;
        Vector3 HandCubeU2;

  
        User1Posicao = User1Pos.transform.position;
        User2Posicao = User2Pos.transform.position;
        U1RH = User1RightHandPos.transform.position;
        U1LH = User1LeftHandPos.transform.position;
        U2RH = User2RightHandPos.transform.position;
        U2LH = User1LeftHandPos.transform.position;
        //User1MaoDeToque = ; MAL FEITO
        //User2MaoDeToque = ; MAL FEITO
        U1TouchType = User1TouchType.GetComponent<UserTouch>().typeOfTouch; //T, DT, DR
        U2TouchType = User2TouchType.GetComponent<UserTouch>().typeOfTouch;
        U1Action = User1Action.GetComponent<ColliderObj>().actionIsNow; //Select...
        U2Action = User2Action.GetComponent<ColliderObj>().actionIsNow;
        HoverUNU1 = HoverU1.GetComponent<ColliderObj>().collidingObject;
        HoverUNU2 = HoverU2.GetComponent<ColliderObj>().collidingObject;
        HoverOTU1 = HoverU1.GetComponent<ColliderObj>().objectName;
        HoverOTU2 = HoverU2.GetComponent<ColliderObj>().objectName;
        int sqTotal = NQuadToSelect.GetComponent<ColliderObj>().squares_findTotal;
        int ccTotal = NCircToSelect.GetComponent<ColliderObj>().circles_findTotal;
        int incSQ = NQuadToSelect.GetComponent<ColliderObj>().squares_inc;
        int incCC = NCircToSelect.GetComponent<ColliderObj>().circles_inc;
        NumQuadToSelect = sqTotal - incSQ;
        NumCircToSelect = ccTotal - incCC;
        U1LastColliding = LastCollidingObj1.GetComponent<ColliderObj>().lastCollidingObject;
        U2LastColliding = LastCollidingObj2.GetComponent<ColliderObj>().lastCollidingObject;
        HandCubeU1 = HandCube1Pos.transform.position;
        HandCubeU2 = HandCube2Pos.transform.position;

        //MAO DO TOQUE - LEFT OR RIGHT
        if (User1MaoDeToque.GetComponent<TrackerClient>().handRightU1 != null)
        {
            MaoUser1 = "right";
        }
        else if (User1MaoDeToque.GetComponent<TrackerClient>().handLeftU1 != null)
        {
            MaoUser1 = "left";
        }
        else
        {
            MaoUser1 = null;
        }
        if (User2MaoDeToque.GetComponent<TrackerClient>().handRightU2 != null)
        {
            MaoUser2 = "right";
        }
        else if (User2MaoDeToque.GetComponent<TrackerClient>().handLeftU2 != null)
        {
            MaoUser2 = "left";
        }
        else
        {
            MaoUser2 = null;
        }

        //POSICAO DO TOQUE
        if (U1TouchType == "tap" || U1TouchType == "double-tap" || U1TouchType == "drag")
        {
            PosTouchU1 = User1PosToque.transform.position;
        }
        else
        {
            PosTouchU1 = Vector3.zero;
        }
        if (U2TouchType == "tap" || U2TouchType == "double-tap" || U2TouchType == "drag")
        {
            PosTouchU2 = User2PosToque.transform.position;
        }
        else
        {
            PosTouchU2 = Vector3.zero;
        }

        text.Add(timestamp.TotalMilliseconds + ":" + "User 1" + ":" + User1Posicao + ":" + U1RH + ":" + U1LH + ":" + PosTouchU1 + ":" + MaoUser1 + ":" + U1TouchType + ":" + U1Action + ":" + HoverUNU1 + ":" + HoverOTU1 + ":" + NumQuadToSelect + ":" + NumCircToSelect + ":" + U1LastColliding + ":" +  HandCubeU1);
        text.Add(timestamp.TotalMilliseconds + ":" + "User 2" + ":" + User2Posicao + ":" + U2RH + ":" + U2LH + ":" + PosTouchU2 + ":" + MaoUser2 + ":" + U2TouchType + ":" + U2Action + ":" + HoverUNU2 + ":" + HoverOTU2 + ":" + NumQuadToSelect + ":" + NumCircToSelect + ":" + U2LastColliding + ":" +  HandCubeU2);
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: " + feedbackType);
    }
}