using UnityEngine;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Logs : MonoBehaviour
{

    public string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public string feedbackType = null;
    public int timer = 0;
    public Timer Timer1;
    public int tarefaOn = -1;
    DateTime taskStart;
    
    public GameObject User1Pos, User2Pos;
    public GameObject User1LeftHandPos, User2LeftHandPos;
    public GameObject User1RightHandPos, User2RightHandPos;
    public GameObject User1PosToque, User2PosToque; //vazio, mas existe; coords, com toque
    public GameObject User1MaoDeToque, User2MaoDeToque;
    public GameObject User1TouchType, User2TouchType; //Tap, DoubleTap, Drag
    public GameObject User1Action, User2Action; //Select, Exit, Error
    public GameObject HoverU1, HoverU2;
    public GameObject NQuadToSelect, NCircToSelect;
    public GameObject LastCollidingObj1, LastCollidingObj2;
    public GameObject HandCube1Pos, HandCube2Pos;

    public TimeSpan timestamp;
    public Vector3 User1Posicao, User2Posicao;
    public Vector3 U1RH, U1LH, U2RH, U2LH;
    public Vector3 PosTouchU1, PosTouchU2;
    public string MaoUser1, MaoUser2;
    public string U1TouchType, U2TouchType;
    public string U1Action, U2Action;
    public GameObject HoverUNU1, HoverUNU2;
    public string HoverOTU1, HoverOTU2;
    public int sqTotal, ccTotal, incSQ, incCC;
    public int NumQuadToSelect, NumCircToSelect;
    public GameObject U1LastColliding, U2LastColliding;
    public Vector3 HandCubeU1, HandCubeU2;

    public bool CompletedTask = false;
    public int SelectionsU1 = 0;
    public int SelectionsU2 = 0;
    public int ErrorsU1 = 0;
    public int ErrorsU2 = 0;
    public Double[] TimeStampQuadrados = new Double[5];
    public Double[] TimeStampCirculos = new Double[5];
    public Double[] TimeStampErros = new Double[20]; //what now?
    public Double TempoSelecaoQuadrados;
    public Double TempoSelecaoCirculos;
    public Double TempoTotalTarefa;

    //Time:User:UserPos:UserRHPos:UserLHPos:UserPosToque:UserMaoDeToque:UserTouchType:UserAction:HoverUnityName:HoverObjectType:NQuadToSelect:NCircToSelect:LastCollidingObj:HandCubePos

    public List<string> text = new List<string>();
    public List<string> textAglomerate = new List<string>();
    public List<string> textStory = new List<string>();

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
            //textStory.Add("Time:User:Action:ObjUnity:NumSelectForSelection");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tarefaOn = 0;
            print("Tarefa finito");
            textStory.Add("At " + timestamp.TotalMilliseconds + " task was stopped");

            //print("Tarefa Terminada! Tempo: " + current);
            DateTime now = DateTime.Now;

            // FRAME A FRAME
            using (StreamWriter sw = new StreamWriter(@"kinglog" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
            {
                foreach (string s in text)
                {
                    sw.WriteLine(s);
                    //System.IO.File.WriteAllText(@"Frame-A-Frame_Logs.txt", s);
                }
            }

            LogFileAglomerateWriting();

            // TELL A STORY
            using (StreamWriter sws = new StreamWriter(@"kinglogTellAStory" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
            {
                foreach (string s in textStory)
                {
                    sws.WriteLine(s);
                }
            }
        }

        if (tarefaOn == 1)
        {
            LogFileFrameWriting();
            LogFileTellAStoryWriting();


        }

        if ( tarefaOn == 0 )
        {
            
        }

    }

    public void LogFileFrameWriting()
    {
        timestamp = DateTime.Now - taskStart;
        //System.Random r = new System.Random();

        User1Posicao = User1Pos.transform.position;
        User2Posicao = User2Pos.transform.position;

        U1RH = User1RightHandPos.transform.position;
        U1LH = User1LeftHandPos.transform.position;
        U2RH = User2RightHandPos.transform.position;
        U2LH = User1LeftHandPos.transform.position;

        //PosTouchU1;
        //PosTouchU2;

        //MaoUser1;
        //MaoUser2;

        //User1MaoDeToque = ; MAL FEITO
        //User2MaoDeToque = ; MAL FEITO

        U1TouchType = User1TouchType.GetComponent<UserTouch>().typeOfTouch; //T, DT, DR
        U2TouchType = User2TouchType.GetComponent<UserTouch>().typeOfTouch;

        U1Action = User1Action.GetComponent<ColliderObj>().actionIsNow; //Select...
        U2Action = User2Action.GetComponent<ColliderObj>().actionIsNow;

        HoverUNU1 = HoverU1.GetComponent<ColliderObj>().collidingObject; //unity name
        HoverUNU2 = HoverU2.GetComponent<ColliderObj>().collidingObject;

        HoverOTU1 = HoverU1.GetComponent<ColliderObj>().objectName; //obj type
        HoverOTU2 = HoverU2.GetComponent<ColliderObj>().objectName;

        // Vars
        sqTotal = NQuadToSelect.GetComponent<ColliderObj>().squares_findTotal;
        ccTotal = NCircToSelect.GetComponent<ColliderObj>().circles_findTotal;
        incSQ = NQuadToSelect.GetComponent<ColliderObj>().squares_inc;
        incCC = NCircToSelect.GetComponent<ColliderObj>().circles_inc;
        NumQuadToSelect = sqTotal - incSQ; //pelo User1
        NumCircToSelect = ccTotal - incCC; //pelo User2

        U1LastColliding = LastCollidingObj1.GetComponent<ColliderObj>().lastCollidingObject;
        U2LastColliding = LastCollidingObj2.GetComponent<ColliderObj>().lastCollidingObject;
        HandCubeU1 = HandCube1Pos.transform.position;
        HandCubeU2 = HandCube2Pos.transform.position;

        //MAO DO TOQUE - LEFT OR RIGHT - MAL
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

        //POSICAO DO TOQUE : enquanto está a haver um tap, DT ou drag, significa que ha um toque criado
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

        //Numero de DT
        if(U1TouchType == "double-tap")
        {
            SelectionsU1++;
        }
        if (U2TouchType == "double-tap")
        {
            SelectionsU2++;
        }

        //Numero de Erros
        //timestamp erros cada user
        for (int i = 0; i < TimeStampErros.Length - 1; i++)
        {
            if (U1Action == "error" || (U1Action == "selected" && U1LastColliding == null))
            {
                ErrorsU1++;
                TimeStampErros[i] = timestamp.TotalMilliseconds;
            }
            if (U2Action == "error" || (U2Action == "selected" && U2LastColliding == null))
            {
                ErrorsU2++;
                TimeStampErros[i] = timestamp.TotalMilliseconds;
            }
        }

        // Adiciona o texto ao documento Log frame-a-frame
        text.Add(timestamp.TotalMilliseconds + ":" + "User 1" + ":" + User1Posicao + ":" + U1RH + ":" + U1LH + ":" + PosTouchU1 + ":" + MaoUser1 + ":" + U1TouchType + ":" + U1Action + ":" + HoverUNU1 + ":" + HoverOTU1 + ":" + NumQuadToSelect + ":" + NumCircToSelect + ":" + U1LastColliding + ":" +  HandCubeU1);
        text.Add(timestamp.TotalMilliseconds + ":" + "User 2" + ":" + User2Posicao + ":" + U2RH + ":" + U2LH + ":" + PosTouchU2 + ":" + MaoUser2 + ":" + U2TouchType + ":" + U2Action + ":" + HoverUNU2 + ":" + HoverOTU2 + ":" + NumQuadToSelect + ":" + NumCircToSelect + ":" + U2LastColliding + ":" +  HandCubeU2);
        
    }

    public void LogFileAglomerateWriting()
    {
        //Numero de selecoes vazias de ambos users
        int NumSelecoesVaziasU1 = 0;
        int NumSelecoesVaziasU2 = 0;
        if (U1Action == "selected" && U1LastColliding == null)
        {
            NumSelecoesVaziasU1++;
        }
        if (U2Action == "selected" && U2LastColliding == null)
        {
            NumSelecoesVaziasU2++;
        }
        int NumSelecoesVaziasAmbos = NumSelecoesVaziasU1 + NumSelecoesVaziasU2;
        //Numero de selecoes erradas de ambos users - selecionar algo que nao pode, selecionar "nada" - first case
        int NumSelecoesErradasU1 = ErrorsU1 + NumSelecoesVaziasU1;
        int NumSelecoesErradasU2 = ErrorsU2 + NumSelecoesVaziasU2;
        int NumSelecoesErradasAmbos = NumSelecoesErradasU1 + NumSelecoesErradasU2 + NumSelecoesVaziasAmbos;
        //Numero de erros total
        int NumErrosU1 = ErrorsU1;
        int NumErrosU2 = ErrorsU2;
        int NumErrosAmbos = NumErrosU1 + NumErrosU2;
        //timestamp selecao cada user
        for (int i = 0; i < TimeStampQuadrados.Length-1; i++)
        {
            if (U1Action == "selected" && HoverOTU1 == "square")
            {
                TimeStampQuadrados[i] = timestamp.TotalMilliseconds;
            }
        }
        for (int i = 0; i < TimeStampCirculos.Length - 1; i++)
        {
            if (U2Action == "selected" && HoverOTU2 == "square")
            {
                TimeStampCirculos[i] = timestamp.TotalMilliseconds;
            }
        }

        //tempo total de touch de cada user

        //tempo total de toque em simultâneo

        textAglomerate.Add("Tarefa Completada" + ":" + CompletedTask);
        textAglomerate.Add("Numero de Quadrados Selecionados" + ":" + incSQ);
        textAglomerate.Add("Numero de Circulos Selecionados" + ":" + incCC);
        textAglomerate.Add("Numero de Selecoes Vazias" + ":" + NumSelecoesVaziasAmbos);
        textAglomerate.Add("Numero de Selecoes Erradas" + ":" + NumSelecoesErradasAmbos);
        textAglomerate.Add("Numero de Erros no Total" + ":" + NumErrosAmbos);

        textAglomerate.Add("Selecoes Quadrados" + ":" + TimeStampQuadrados); //timestamps
        textAglomerate.Add("Selecoes Circulos" + ":" + TimeStampCirculos); //timestamps
        textAglomerate.Add("Erros" + ":" + TimeStampErros); //timestamps
        textAglomerate.Add("Tempo Total de Selecao de Quadrados" + ":" + TempoSelecaoQuadrados);
        textAglomerate.Add("Tempo Total de Selecao de Circulos" + ":" + TempoSelecaoCirculos);
        textAglomerate.Add("Tempo total da tarefa" + ":" + TempoTotalTarefa);

        textAglomerate.Add("Tempo Total de Toque do User 1" + ":" + " ");
        textAglomerate.Add("Tempo Total de Toque do User 2" + ":" + " ");
        textAglomerate.Add("Tempo Total de Toque em simultâneo" + ":" + " ");

        DateTime now = DateTime.Now;
        // AGLOMERATE
        using (StreamWriter swa = new StreamWriter(@"kinglogAglomerate" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
        {
            foreach (string s in textAglomerate)
            {
                swa.WriteLine(s);
            }
        }
    }

    public void LogFileTellAStoryWriting()
    {
        // Adiciona o texto ao documento Log Tell A Story
        // Time:User:Action:ObjUnity:NumSelectForSelection

        if (U1Action == "selected" && NumQuadToSelect != 0)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User1 selected " + HoverOTU1 + " and there is still " + NumQuadToSelect + " squares to select.");
        }
        if (U1TouchType == "double-tap" && HoverOTU1 == "circle") // aka error
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User1 tried to select " + HoverOTU1 + " and that is not possible.");
        }
        if (U2Action == "selected" && NumCircToSelect != 0)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User2 selected " + HoverOTU2 + " and there is still " + NumCircToSelect + " circles to select.");
        }
        if (U2TouchType == "double-tap" && HoverOTU2 == "square") //aka error
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User2 tried to select " + HoverOTU2 + " and that is not possible.");
        }

        if (U1Action == "selected" && NumQuadToSelect == 0)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User 1 selected all the squares.");
            TempoSelecaoQuadrados = timestamp.TotalMilliseconds;
        }
        if (U2Action == "selected" && NumCircToSelect == 0)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User 2 selected all the circles.");
            TempoSelecaoCirculos = timestamp.TotalMilliseconds;
        }
        if (NumQuadToSelect == 0 && NumCircToSelect == 0)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " All squares and circles were selected. Task completed!");
            CompletedTask = true;
            TempoTotalTarefa = timestamp.TotalMilliseconds;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 30, 200, 35), "Feedback Type: " + feedbackType);
    }
}