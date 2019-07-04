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
    public bool User1hasTouch;
    public bool User2hasTouch;
    public TimeSpan User1TouchStart;
    public TimeSpan User2TouchStart;
    public double User1TouchTime;
    public double User2TouchTime;
    public Vector3 PosTouchU1, PosTouchU2;
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
    public int NumSelecoesVaziasU1 = 0;
    public int NumSelecoesVaziasU2 = 0;
    public List<double> TimeStampQuadrados = new List<double>();
    public List<double> TimeStampCirculos = new List<double>();

    public List<double> TimeStampErros = new List<double>();
    public double TempoSelecaoQuadrados;
    public double TempoSelecaoCirculos;
    public double TempoTotalTarefa;

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

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Comecou a tarefa!");
            tarefaOn = 1;
            User1TouchTime = 0;
            User2TouchTime = 0;

            // TODO: fazer reset as variaveis para o aglomerate 
            taskStart = DateTime.Now;

            //StartLogging
            text.Add(
                "Time:"+
                "User:"+
                "UserPosX:" +
                "UserPosY:" +
                "UserPosZ:" +
                "UserRHPosX:" +
                "UserRHPosY:" +
                "UserRHPosZ:" +
                "UserLHPosX:"+
                "UserLHPosY:"+
                "UserLHPosZ:"+
                "UserPosToqueX:"+
                "UserPosToqueY:"+
                "UserPosToqueZ:"+
                "UserTouchType:"+
                "UserAction:"+
                "HoverUnityName:"+
                "HoverObjectType:"+
                "NQuadToSelect:"+
                "NCircToSelect:"+
                "LastCollidingObj:" +
                "HandCubePosX:" + 
                "HandCubePosY:" + 
                "HandCubePosZ:");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tarefaOn = 0;
            print("Tarefa finito");
            textStory.Add("At " + timestamp.TotalMilliseconds + " task was stopped");
            
            DateTime now = DateTime.Now;

            // FRAME A FRAME
            using (StreamWriter sw = new StreamWriter(@"kinglog" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
            {
                foreach (string s in text)
                {
                    sw.WriteLine(s);
                }
            }

            // AGLOMERATE
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
    }

    public void LogFileFrameWriting()
    {
        timestamp = DateTime.Now - taskStart;

        //POSICAO USER
        User1Posicao = User1Pos.transform.position;
        User2Posicao = User2Pos.transform.position;

        //POSICAO MAOS USER
        U1RH = User1RightHandPos.transform.position;
        U1LH = User1LeftHandPos.transform.position;
        U2RH = User2RightHandPos.transform.position;
        U2LH = User1LeftHandPos.transform.position;

        //POSICAO DO TOQUE e TEMPO:
        bool newUser1hasTouch = User1Pos.GetComponent<User>().handRight.userTouch.touch != null;
        if (!User1hasTouch && newUser1hasTouch)
        {
            User1TouchStart = timestamp;
        }
        if (User1hasTouch && !newUser1hasTouch)
        {
            User1TouchTime += (timestamp - User1TouchStart).TotalMilliseconds;
        }
        User1hasTouch = newUser1hasTouch;
        if (User1hasTouch)
            PosTouchU1 = User1Pos.GetComponent<User>().handRight.userTouch.touch.transform.position;


        bool newUser2hasTouch = User2Pos.GetComponent<User>().handRight.userTouch.touch != null;
        if (!User2hasTouch && newUser2hasTouch)
        {
            User2TouchStart = timestamp;
        }
        if (User2hasTouch && !newUser2hasTouch)
        {
            User2TouchTime += (timestamp - User2TouchStart).TotalMilliseconds;
        }
        User2hasTouch = newUser2hasTouch;
        if (User2hasTouch)
            PosTouchU2 = User2Pos.GetComponent<User>().handRight.userTouch.touch.transform.position;

        //TIPO DE TOQUE - Tap, DoubleTap, Drag
        U1TouchType = User1TouchType.GetComponent<UserTouch>().typeOfTouch;
        U2TouchType = User2TouchType.GetComponent<UserTouch>().typeOfTouch;

        //TIPO DE ACAO - Select, Error, Exit
        U1Action = User1Action.GetComponent<ColliderObj>().actionIsNow;
        U2Action = User2Action.GetComponent<ColliderObj>().actionIsNow;

        User1Action.GetComponent<ColliderObj>().actionIsNow = User2Action.GetComponent<ColliderObj>().actionIsNow = null;
        
        //NOME DO OBJETO NO UNITY
        HoverUNU1 = HoverU1.GetComponent<ColliderObj>().collidingObject;
        HoverUNU2 = HoverU2.GetComponent<ColliderObj>().collidingObject;

        //TIPO DE OBJETO - Quadrado, Circulo, Triangulo
        HoverOTU1 = HoverU1.GetComponent<ColliderObj>().objectName;
        HoverOTU2 = HoverU2.GetComponent<ColliderObj>().objectName;

        //CONTAGEM DE SELECOES E TOTAIS
        sqTotal = NQuadToSelect.GetComponent<ColliderObj>().squares_findTotal;
        ccTotal = NCircToSelect.GetComponent<ColliderObj>().circles_findTotal;
        incSQ = NQuadToSelect.GetComponent<ColliderObj>().squares_inc;
        incCC = NCircToSelect.GetComponent<ColliderObj>().circles_inc;
        NumQuadToSelect = sqTotal - incSQ; //pelo User1
        NumCircToSelect = ccTotal - incCC; //pelo User2

        //LAST COLLIDING OBJECT
        U1LastColliding = LastCollidingObj1.GetComponent<ColliderObj>().lastCollidingObject;
        U2LastColliding = LastCollidingObj2.GetComponent<ColliderObj>().lastCollidingObject;

        //POSICAO DO CUBINHO
        HandCubeU1 = HandCube1Pos.transform.position;
        HandCubeU2 = HandCube2Pos.transform.position;
        

        //PARA O AGLOMERATE:
        //Numero de DT
        if (U1TouchType == "double-tap")
        {
            SelectionsU1++;
            print("Selections: " + SelectionsU1 + "and also " + SelectionsU2);
        }
        if (U2TouchType == "double-tap")
        {
            SelectionsU2++;
        }

        //Numero de Erros
        //timestamp erros cada user
        if (U1Action == "error" || (U1Action == "selected" && U1LastColliding == null))
        {
            ErrorsU1++;
            TimeStampErros.Add(timestamp.TotalMilliseconds);
        }
        if (U2Action == "error" || (U2Action == "selected" && U2LastColliding == null))
        {
            ErrorsU2++;
            TimeStampErros.Add(timestamp.TotalMilliseconds);
        }

        // NAO sera melhor User1Action.GetComponent<ColliderObj>().numErros; ? TO DO
        //Numero de Erros
        //selecoes vazias
        if (U1Action == "selected" && U1LastColliding == null)
        {
            NumSelecoesVaziasU1++;
            TimeStampErros.Add(timestamp.TotalMilliseconds);
        }
        if (U2Action == "selected" && U2LastColliding == null)
        {
            NumSelecoesVaziasU2++;
            TimeStampErros.Add(timestamp.TotalMilliseconds);
        }

        // Adiciona o texto ao documento Log frame-a-frame
        text.Add(timestamp.TotalMilliseconds + ":" + "User 1" + ":" + 
            User1Posicao.x + ":" + User1Posicao.y + ":" + User1Posicao.z + ":" +
            U1RH.x + ":" + U1RH.y + ":" + U1RH.z + ":" + 
            U1LH.x + ":" + U1LH.y + ":" + U1LH.z + ":" + 
            User1hasTouch + ":" + 
            (User1hasTouch? "" + (PosTouchU1.x + ":" + PosTouchU1.y + ":" + PosTouchU1.z) : "") + ":" + 
            U1TouchType + ":" + 
            U1Action + ":" + 
            HoverUNU1 + ":" + 
            HoverOTU1 + ":" + 
            NumQuadToSelect + ":" + 
            NumCircToSelect + ":" + 
            U1LastColliding + ":" +  
            HandCubeU1.x + ":" + HandCubeU1.y + ":" + HandCubeU1.z);

        text.Add(timestamp.TotalMilliseconds + ":" + "User 2" + ":" +
            User2Posicao.x + ":" + User2Posicao.y + ":" + User2Posicao.z + ":" +
            U2RH.x + ":" + U2RH.y + ":" + U2RH.z + ":" +
            U2LH.x + ":" + U2LH.y + ":" + U2LH.z + ":" +
            User2hasTouch + ":" + 
            (User2hasTouch ? "" + (PosTouchU2.x + ":" + PosTouchU2.y + ":" + PosTouchU2.z) : "") + ":" + 
            U2TouchType + ":" + 
            U2Action + ":" + 
            HoverUNU2 + ":" + 
            HoverOTU2 + ":" + 
            NumQuadToSelect + ":" + 
            NumCircToSelect + ":" + 
            U2LastColliding + ":" +
            HandCubeU2.x + ":" + HandCubeU2.y + ":" + HandCubeU2.z);

    }

    public void LogFileAglomerateWriting()
    {
        //Numero de selecoes vazias de ambos users
        int NumVaziasU1 = NumSelecoesVaziasU1;
        int NumVaziasU2 = NumSelecoesVaziasU2;
        int NumSelecoesVaziasAmbos = NumVaziasU1 + NumVaziasU2;
        //Numero de erros total
        int NumErrosU1 = ErrorsU1;
        int NumErrosU2 = ErrorsU2;
        int NumErrosAmbos = NumErrosU1 + NumErrosU2;
        //Numero de selecoes erradas de ambos users - selecionar algo que nao pode, selecionar "nada" - first case
        int NumSelecoesErradasAmbos = NumSelecoesVaziasAmbos + NumErrosAmbos;
        //timestamp selecao cada user
        if (U1Action == "selected" && HoverOTU1 == "square")
        {
            TimeStampQuadrados.Add(timestamp.TotalMilliseconds);
        }

        if (U2Action == "selected" && HoverOTU2 == "square")
        {
            TimeStampCirculos.Add(timestamp.TotalMilliseconds);
        }

        //tempo total de touch de cada user


        //tempo total de toque em simultâneo


        textAglomerate.Add("Tarefa Completada" + ":" + CompletedTask);
        textAglomerate.Add("Numero de Quadrados Selecionados" + ":" + incSQ);
        textAglomerate.Add("Numero de Circulos Selecionados" + ":" + incCC);
        textAglomerate.Add("Numero de Selecoes Vazias" + ":" + NumSelecoesVaziasAmbos);
        textAglomerate.Add("Numero de Selecoes Erradas" + ":" + NumSelecoesErradasAmbos);
        textAglomerate.Add("Numero de Erros no Total" + ":" + NumErrosAmbos);
        
        //timestamps
        textAglomerate.Add("Selecoes Quadrados" + ":" + TimeStampQuadrados);
        textAglomerate.Add("Selecoes Circulos" + ":" + TimeStampCirculos);
        textAglomerate.Add("Erros" + ":" + TimeStampErros);
        textAglomerate.Add("Tempo Total de Selecao de Quadrados" + ":" + TempoSelecaoQuadrados);
        textAglomerate.Add("Tempo Total de Selecao de Circulos" + ":" + TempoSelecaoCirculos);
        textAglomerate.Add("Tempo total da tarefa" + ":" + TempoTotalTarefa);

        textAglomerate.Add("Tempo Total de Toque do User 1" + ":" + User1TouchTime);
        textAglomerate.Add("Tempo Total de Toque do User 2" + ":" + User2TouchTime);
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