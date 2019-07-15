using UnityEngine;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

public class Logs : MonoBehaviour
{

    public string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public string feedbackType = "";
    public int timer = 0;
    public Timer Timer1;
    public int tarefaOn = -1;
    DateTime taskStart;
    DateTime comecou;
    DateTime finalizou;
    
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
    public GameObject repocess;
    public GameObject colliderino;
    public GameObject tabuleirino;
    public GameObject LastLastColliding1;
    public GameObject LastLastColliding2;

    public TimeSpan timestamp;
    public Vector3 User1Posicao, User2Posicao;
    public Vector3 U1RH, U1LH, U2RH, U2LH;
    public bool User1hasTouch;
    public bool User2hasTouch;
    public TimeSpan User1TouchStart;
    public TimeSpan User2TouchStart;
    public bool User1TouchStartbool = false;
    public bool User2TouchStartbool = false;
    public double User1TouchTime;
    public double User2TouchTime;
    public TimeSpan UserSimultaneousStart;
    public TimeSpan UserSimultaneousEnd;
    public double UserSimultaneousTouchTime = 0;
    public Vector3 PosTouchU1, PosTouchU2;
    public string U1TouchType, U2TouchType;
    public string U1Action, U2Action;
    public GameObject HoverUNU1, HoverUNU2;
    public string HoverOTU1, HoverOTU2;
    public int sqTotal, ccTotal, incSQ, incCC;
    public int NumQuadsToSelect, NumCircsToSelect;
    public GameObject U1LastColliding, U2LastColliding;
    public string LastCollidingTypeU1, LastCollidingTypeU2;
    public Vector3 HandCubeU1, HandCubeU2;
    public int TargetReentersU1 = 0;
    public int TargetReentersU2 = 0;
    public string GodIs = "";
    public string SpaceIs = "";
    public string HIs = "";

    public bool CompletedTask = false;
    public int NumSelecoesVaziasU1 = 0;
    public int NumSelecoesVaziasU2 = 0;
    public int NumSelecoesErradasTU1 = 0;
    public int NumSelecoesErradasOU1 = 0;
    public int NumSelecoesErradasTU2 = 0;
    public int NumSelecoesErradasOU2 = 0;


    public ArrayList TimeStampQuadrados = new ArrayList();
    public ArrayList TimeStampCirculos = new ArrayList();
    public ArrayList TimeStampVaziosU1 = new ArrayList();
    public ArrayList TimeStampVaziosU2 = new ArrayList();
    public ArrayList TimeStampSelecoesErradasU1 = new ArrayList();
    public ArrayList TimeStampSelecoesErradasU2 = new ArrayList();

    public string TSQuadrados = "";
    public string TSCirculos = "";
    public string TSVaziosU1 = "";
    public string TSVaziosU2 = "";
    public string TSErradasU1 = "";
    public string TSErradasU2 = "";

    public double TempoSelecaoQuadrados;
    public double TempoSelecaoCirculos;
    public double TempoTotalTarefa;

    public int GodTimes = 0;
    public int SpaceTimes = 0;
    public int HTimes = 0;
   
    //Time:User:UserPos:UserRHPos:UserLHPos:UserPosToque:UserMaoDeToque:UserTouchType:UserAction:HoverUnityName:HoverObjectType:NQuadToSelect:NCircToSelect:LastCollidingObj:HandCubePos

    public List<string> text = new List<string>();
    public List<string> textAglomerate = new List<string>();
    public List<string> textStory = new List<string>();

    public void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Comecou a tarefa!");
            tarefaOn = 1;

            //Reiniciar Variáveis aqui 
            ResetAll();
            int collidersFB = colliderino.GetComponent<ColliderObj>().feedbackType;
            int tabuleirosCode = tabuleirino.GetComponent<Tabuleiros>().code;

            //Frames
            if (collidersFB == 1) text.Add("FEEDBACK IS PRIVATE!");
            if (collidersFB == 2) text.Add("FEEDBACK IS TASK DEPENDENT!");
            if (collidersFB == 3) text.Add("FEEDBACK IS PUBLIC!");
            if (tabuleirosCode == 1) text.Add("BOARD WITHOUT TRIANGLES");
            if (tabuleirosCode == 2) text.Add("BOARD WITH TRIANGLES");

            //Aglomerado
            if (collidersFB == 1) textAglomerate.Add("FEEDBACK IS PRIVATE!");
            if (collidersFB == 2) textAglomerate.Add("FEEDBACK IS TASK DEPENDENT!");
            if (collidersFB == 3) textAglomerate.Add("FEEDBACK IS PUBLIC!");
            if (tabuleirosCode == 1) textAglomerate.Add("BOARD WITHOUT TRIANGLES");
            if (tabuleirosCode == 2) textAglomerate.Add("BOARD WITH TRIANGLES");

            //Story
            if (collidersFB == 1) textStory.Add("FEEDBACK IS PRIVATE!");
            if (collidersFB == 2) textStory.Add("FEEDBACK IS TASK DEPENDENT!");
            if (collidersFB == 3) textStory.Add("FEEDBACK IS PUBLIC!");
            if (tabuleirosCode == 1) textStory.Add("BOARD WITHOUT TRIANGLES");
            if (tabuleirosCode == 2) textStory.Add("BOARD WITH TRIANGLES");

            //StartLogging
            text.Add(
                "Time:" +
                "User:" +
                "UserPosX:" +
                "UserPosY:" +
                "UserPosZ:" +
                "UserRHPosX:" +
                "UserRHPosY:" +
                "UserRHPosZ:" +
                "UserLHPosX:" +
                "UserLHPosY:" +
                "UserLHPosZ:" +
                "UserHasTouch:" +
                "UserPosToqueX:" +
                "UserPosToqueY:" +
                "UserPosToqueZ:" +
                "UserTouchType:" +
                "UserAction:" +
                "HoverUnityName:" +
                "HoverObjectType:" +
                "NQuadToSelect:" +
                "NCircToSelect:" +
                "LastCollidingObj:" +
                "LastCollidingObjectType:" +
                "HandCubePosX:" +
                "HandCubePosY:" +
                "HandCubePosZ:" +
                "God Key: " +
                "Space Key: " +
                "H Key: ");

        }
        
        if (tarefaOn == 1)
        {
            LogFileFrameWriting();
            LogFileTellAStoryWriting();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            carregouNoS();
        }
    }


    private void carregouNoS()
    {
        tarefaOn = 0;
        print("Tarefa finito");
        textStory.Add("At " + timestamp.TotalMilliseconds + " task was stopped");
        finalizou = DateTime.Now;
        TempoTotalTarefa = (finalizou - taskStart).TotalMilliseconds;


         DateTime now = DateTime.Now;

        // FRAME A FRAME
        using (StreamWriter sw = new StreamWriter(@"kinglog" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
        {
            foreach (string s in text)
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            sw.Close();
        }

        // AGLOMERATE
        //Rolling dos TS
        foreach (double t in TimeStampQuadrados) TSQuadrados += t + ":";
        foreach (double t in TimeStampCirculos) TSCirculos += t + ":";
        foreach (double t in TimeStampVaziosU1) TSVaziosU1 += t + ":";
        foreach (double t in TimeStampVaziosU2) TSVaziosU2 += t + ":";
        foreach (double t in TimeStampSelecoesErradasU1) TSErradasU1 += t + ":";
        foreach (double t in TimeStampSelecoesErradasU2) TSErradasU2 += t + ":";
        LogFileAglomerateWriting();

        // TELL A STORY
        using (StreamWriter sws = new StreamWriter(@"kinglogTellAStory" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
        {
            foreach (string s in textStory)
            {
                sws.WriteLine(s);
            }
            sws.Flush();
            sws.Close();
        }
    }

    private void ResetAll()
    {
        taskStart = DateTime.Now;

        CompletedTask = false;
        text = new List<string>();
        textAglomerate = new List<string>();
        textStory = new List<string>();
        //POSICAO USER de novo
        User1Posicao = User1Pos.transform.position;
        User2Posicao = User2Pos.transform.position;

        //POSICAO MAOS USER de novo
        U1RH = User1RightHandPos.transform.position;
        U1LH = User1LeftHandPos.transform.position;
        U2RH = User2RightHandPos.transform.position;
        U2LH = User1LeftHandPos.transform.position;
        User1hasTouch = false;
        User2hasTouch = false;
        HandCube1Pos.transform.position = Vector3.zero;
        HandCube2Pos.transform.position = Vector3.zero;
        //incSQ = NQuadToSelect.GetComponent<ColliderObj>().squares_inc;
        //incCC = NCircToSelect.GetComponent<ColliderObj>().circles_inc;
        incSQ = 0;
        incCC = 0;
        NumQuadsToSelect = NQuadToSelect.GetComponent<ColliderObj>().squares_findTotal;
        NumCircsToSelect = NCircToSelect.GetComponent<ColliderObj>().circles_findTotal;
        U1LastColliding = null;
        U2LastColliding = null;
        HoverOTU1 = null;
        HoverOTU2 = null;
        LastCollidingTypeU1 = null;
        LastCollidingTypeU2 = null;
        U1TouchType = null;
        U2TouchType = null;
        NumSelecoesVaziasU1 = 0;
        NumSelecoesVaziasU2 = 0;
        NumSelecoesErradasTU1 = 0;
        NumSelecoesErradasTU2 = 0;
        NumSelecoesErradasOU1 = 0;
        NumSelecoesErradasOU2 = 0;
        TSQuadrados = "";
        TSCirculos = "";
        TSVaziosU1 = "";
        TSVaziosU2 = "";
        TSErradasU1 = "";
        TSErradasU2 = "";
        TimeStampQuadrados = new ArrayList();
        TimeStampCirculos = new ArrayList();
        TimeStampVaziosU1 = new ArrayList();
        TimeStampVaziosU2 = new ArrayList();
        TimeStampSelecoesErradasU1 = new ArrayList();
        TimeStampSelecoesErradasU2 = new ArrayList();
        TempoSelecaoQuadrados = 0;
        TempoSelecaoCirculos = 0;
        TempoTotalTarefa = 0;
        User1TouchTime = 0;
        User2TouchTime = 0;
        UserSimultaneousTouchTime = 0;
        TargetReentersU1 = 0;
        TargetReentersU2 = 0;
        GodTimes = 0;
        SpaceTimes = 0;
        HTimes = 0;
        User1TouchTime = 0;
        User2TouchTime = 0;

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

        //POSICAO DO TOQUE e TEMPO DE TOQUE DE CADA USER:
        bool newUser1hasTouch = User1Pos.GetComponent<User>().handRight.userTouch.touch != null;
        if (!User1hasTouch && newUser1hasTouch)
        {
            User1TouchStart = timestamp;
            if (User2hasTouch)
                UserSimultaneousStart = timestamp;
        }
        if (User1hasTouch && !newUser1hasTouch)
        {
            User1TouchTime += (timestamp - User1TouchStart).TotalMilliseconds;
            if (User2hasTouch)
            {
                UserSimultaneousEnd = timestamp;
                UserSimultaneousTouchTime += (UserSimultaneousEnd - UserSimultaneousStart).TotalMilliseconds;
            }
        }

        User1hasTouch = newUser1hasTouch;
        if (User1hasTouch)
            PosTouchU1 = User1Pos.GetComponent<User>().handRight.userTouch.touch.transform.position;


        bool newUser2hasTouch = User2Pos.GetComponent<User>().handRight.userTouch.touch != null;
        if (!User2hasTouch && newUser2hasTouch)
        {
            User2TouchStart = timestamp;
            if (User1hasTouch)
                UserSimultaneousStart = timestamp;
        }
        if (User2hasTouch && !newUser2hasTouch)
        {
            User2TouchTime += (timestamp - User2TouchStart).TotalMilliseconds;
            if (User1hasTouch)
            {
                UserSimultaneousEnd = timestamp;
                UserSimultaneousTouchTime += (UserSimultaneousEnd - UserSimultaneousStart).TotalMilliseconds;
            }
        }


        User2hasTouch = newUser2hasTouch;
        if (User2hasTouch)
            PosTouchU2 = User2Pos.GetComponent<User>().handRight.userTouch.touch.transform.position;
        

        //TIPO DE TOQUE - Tap, DoubleTap, Drag
        U1TouchType = User1TouchType.GetComponent<UserTouch>().typeOfTouch;
        U2TouchType = User2TouchType.GetComponent<UserTouch>().typeOfTouch;

        if (U1TouchType != "drag" || U2TouchType != "drag")
        {
            User1TouchType.GetComponent<UserTouch>().typeOfTouch = User2TouchType.GetComponent<UserTouch>().typeOfTouch = null; 
        }

        //TIPO DE ACAO - in_object, Select, Error, Exit
        U1Action = User1Action.GetComponent<ColliderObj>().actionIsNow;
        U2Action = User2Action.GetComponent<ColliderObj>().actionIsNow;

        User1Action.GetComponent<ColliderObj>().actionIsNow = User2Action.GetComponent<ColliderObj>().actionIsNow = null;
        
        //NOME DO OBJETO NO UNITY
        HoverUNU1 = HoverU1.GetComponent<ColliderObj>().collidingObject;
        HoverUNU2 = HoverU2.GetComponent<ColliderObj>().collidingObject;

        //TIPO DE OBJETO - Quadrado, Circulo, Triangulo
        HoverOTU1 = HoverU1.GetComponent<ColliderObj>().objectHoverName;
        HoverOTU2 = HoverU2.GetComponent<ColliderObj>().objectHoverName;

        //CONTAGEM DE SELECOES E TOTAIS
        sqTotal = NQuadToSelect.GetComponent<ColliderObj>().squares_findTotal;
        ccTotal = NCircToSelect.GetComponent<ColliderObj>().circles_findTotal;
        incSQ = NQuadToSelect.GetComponent<ColliderObj>().squares_inc;
        incCC = NCircToSelect.GetComponent<ColliderObj>().circles_inc;
        NumQuadsToSelect = sqTotal - incSQ; //pelo User1
        NumCircsToSelect = ccTotal - incCC; //pelo User2

        //LAST COLLIDING OBJECT
        U1LastColliding = LastCollidingObj1.GetComponent<ColliderObj>().lastCollidingObject;
        U2LastColliding = LastCollidingObj2.GetComponent<ColliderObj>().lastCollidingObject;
        LastCollidingTypeU1 = HoverU1.GetComponent<ColliderObj>().objectName;
        LastCollidingTypeU2 = HoverU2.GetComponent<ColliderObj>().objectName;

        //POSICAO DO CUBINHO
        HandCubeU1 = HandCube1Pos.transform.position;
        HandCubeU2 = HandCube2Pos.transform.position;

        //Keys
        GodTimes = HoverU1.GetComponent<ColliderObj>().pressGod;
        SpaceTimes = repocess.GetComponent<NewTouch>().repro;
        HTimes = repocess.GetComponent<NewTouch>().agás;

        if (HoverU1.GetComponent<ColliderObj>().PressingG) GodIs = "GOD ON"; else GodIs = "-";
        if (repocess.GetComponent<NewTouch>().isRep) SpaceIs = "SPACE ON"; else SpaceIs = "-";
        if (repocess.GetComponent<NewTouch>().isH) HIs = "Trocou toque com tecla"; else HIs = "-";

        /*****************
         PARA O AGLOMERATE
         *****************/

        //Numero de Nulos, triangulos e outros que tentaram ser selecionados
        //E TIMESTAMPS
       
        if (U1TouchType == "double-tap")
        {
            if (LastCollidingTypeU1 == "triangle")
            {
                NumSelecoesErradasTU1++;
                TimeStampSelecoesErradasU1.Add(timestamp.TotalMilliseconds);
            }
            if (LastCollidingTypeU1 == "circle")
            {
                NumSelecoesErradasOU1++;
                TimeStampSelecoesErradasU1.Add(timestamp.TotalMilliseconds);
            }
            if (LastCollidingTypeU1 != "circle" && LastCollidingTypeU1 != "triangle")
            {
                NumSelecoesVaziasU1++;
                TimeStampVaziosU1.Add(timestamp.TotalMilliseconds);
            }
        }
        if (U2TouchType == "double-tap")
        {
            if (LastCollidingTypeU2 == "triangle")
            {
                NumSelecoesErradasTU2++;
                TimeStampSelecoesErradasU2.Add(timestamp.TotalMilliseconds);
            }
            if (LastCollidingTypeU2 == "square")
            {
                NumSelecoesErradasOU2++;
                TimeStampSelecoesErradasU2.Add(timestamp.TotalMilliseconds);
            }
            if (LastCollidingTypeU2 != "square" && LastCollidingTypeU2 != "triangle")
            {
                NumSelecoesVaziasU2++;
                TimeStampVaziosU2.Add(timestamp.TotalMilliseconds);
            }
        }

        if (U1Action == "exit")
        {
            LastLastColliding1 = U1LastColliding;
        }
        if(U1Action == "in_objeto")
        {
            if (LastLastColliding1 == U1LastColliding)
            {
                if (LastCollidingTypeU1 == "square") // sao os target do user 1
                {
                    TargetReentersU1++;
                }
            }
        }

        if (U2Action == "exit")
        {
            LastLastColliding2 = U2LastColliding;
        }
        if (U2Action == "in_objeto")
        {
            if (LastLastColliding2 == U2LastColliding)
            {
                if (LastCollidingTypeU2 == "circle") // sao os targets do user 2
                {
                    TargetReentersU2++;
                }
            }
        }

        // Adiciona o texto ao documento Log frame-a-frame
        text.Add(timestamp.TotalMilliseconds + ":" + "User 1" + ":" + 
            User1Posicao.x + ":" + User1Posicao.y + ":" + User1Posicao.z + ":" +
            U1RH.x + ":" + U1RH.y + ":" + U1RH.z + ":" + 
            U1LH.x + ":" + U1LH.y + ":" + U1LH.z + ":" + 
            User1hasTouch + ":" + 
            (User1hasTouch? "" + (PosTouchU1.x + ":" + PosTouchU1.y + ":" + PosTouchU1.z) : "" + null + ":" + null + ":" + null) + ":" + 
            U1TouchType + ":" + 
            U1Action + ":" + 
            HoverUNU1 + ":" + 
            HoverOTU1 + ":" + 
            NumQuadsToSelect + ":" + 
            NumCircsToSelect + ":" + 
            U1LastColliding + ":" +  
            LastCollidingTypeU1 + ":" +  
            HandCubeU1.x + ":" + HandCubeU1.y + ":" + HandCubeU1.z + ":" +
            GodIs + ":" +
            SpaceIs + ":" +
            HIs);

        text.Add(timestamp.TotalMilliseconds + ":" + "User 2" + ":" +
            User2Posicao.x + ":" + User2Posicao.y + ":" + User2Posicao.z + ":" +
            U2RH.x + ":" + U2RH.y + ":" + U2RH.z + ":" +
            U2LH.x + ":" + U2LH.y + ":" + U2LH.z + ":" +
            User2hasTouch + ":" + 
            (User2hasTouch ? "" + (PosTouchU2.x + ":" + PosTouchU2.y + ":" + PosTouchU2.z) : "" + null + ":" + null + ":" + null) + ":" + 
            U2TouchType + ":" + 
            U2Action + ":" + 
            HoverUNU2 + ":" + 
            HoverOTU2 + ":" + 
            NumQuadsToSelect + ":" + 
            NumCircsToSelect + ":" + 
            U2LastColliding + ":" +
            LastCollidingTypeU2 + ":" +
            HandCubeU2.x + ":" + HandCubeU2.y + ":" + HandCubeU2.z + ":" + 
            GodIs + ":" +
            SpaceIs + ":" + 
            HIs);

    }

    public void LogFileAglomerateWriting()
    {
        //Numero de selecoes vazias de ambos users
        int NumVaziasU1 = NumSelecoesVaziasU1;
        int NumVaziasU2 = NumSelecoesVaziasU2;
        int NumSelecoesVaziasAmbos = NumVaziasU1 + NumVaziasU2;

        //Numero de selecoes de triangulos de cada
        int NumTriangulosErrosU1 = NumSelecoesErradasTU1;
        int NumTriangulosErrosU2 = NumSelecoesErradasTU2;
        int NumSelecoesErradasTAmbos = NumTriangulosErrosU1 + NumTriangulosErrosU2;

        //Numero de selecoes erradas obj
        int NumErradasU1 = NumSelecoesErradasOU1;
        int NumErradasU2 = NumSelecoesErradasOU2;
        int NumErradasOAmbos = NumErradasU1 + NumErradasU2;

        //Numero de erros no total
        int NumErrosAmbosTOTAL = NumSelecoesVaziasAmbos + NumSelecoesErradasTAmbos + NumErradasOAmbos;

        textAglomerate.Add("Tarefa Completada" + ":" + CompletedTask);
        textAglomerate.Add("Numero de Quadrados Selecionados" + ":" + incSQ);
        textAglomerate.Add("Numero de Circulos Selecionados" + ":" + incCC);
        textAglomerate.Add("Numero de Selecoes Vazias" + ":" + NumSelecoesVaziasAmbos);
        textAglomerate.Add("Numero de Selecoes Triangulos" + ":" + NumSelecoesErradasTAmbos);
        textAglomerate.Add("Numero de Selecoes de Objetos indevidos" + ":" + NumErradasOAmbos);
        textAglomerate.Add("Numero de Erros no Total" + ":" + NumErrosAmbosTOTAL);
        
        //timestamps
        textAglomerate.Add("Selecoes Quadrados" + ":" + TSQuadrados);
        textAglomerate.Add("Selecoes Circulos" + ":" + TSCirculos);
        textAglomerate.Add("Erros Vazios User 1" + ":" + TSVaziosU1);
        textAglomerate.Add("Erros Vazios User 2" + ":" + TSVaziosU2);
        textAglomerate.Add("Erros Triangulo ou Circulo User 1" + ":" + TSErradasU1);
        textAglomerate.Add("Erros Triangulo ou Quadrado User 2" + ":" + TSErradasU2);
        textAglomerate.Add("Tempo Total de Selecao de Quadrados" + ":" + TempoSelecaoQuadrados);
        textAglomerate.Add("Tempo Total de Selecao de Circulos" + ":" + TempoSelecaoCirculos);
        
        // Ou quando sao todos selecionados ou quando se carrega na tecla "s"
        textAglomerate.Add("Tempo total da tarefa" + ":" + TempoTotalTarefa);

        textAglomerate.Add("Tempo Total de Toque do User 1" + ":" + User1TouchTime);
        textAglomerate.Add("Tempo Total de Toque do User 2" + ":" + User2TouchTime);
        textAglomerate.Add("Tempo Total de Toque em simultâneo" + ":" + UserSimultaneousTouchTime);
        textAglomerate.Add("Target Re-enters User 1" + ":" + TargetReentersU1);
        textAglomerate.Add("Target Re-enters User 2" + ":" + TargetReentersU2);
        textAglomerate.Add("GOD times" + ":" + GodTimes);
        textAglomerate.Add("SPACE times" + ":" + SpaceTimes);
        textAglomerate.Add("H times" + ":" + HTimes);


        DateTime now = DateTime.Now;
        // AGLOMERATE
        using (StreamWriter swa = new StreamWriter(@"kinglogAglomerate" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + ".txt"))
        {
            foreach (string s in textAglomerate)
            {
                swa.WriteLine(s);
            }
            swa.Flush();
            swa.Close();
        }
    }

    public void LogFileTellAStoryWriting()
    {
        // Adiciona o texto ao documento Log Tell A Story
        // Time:User:Action:ObjUnity:NumSelectForSelection
        //timestamp selecao cada user
        if (U1Action == "selected" && NumQuadsToSelect >= 0)
        {
            if(NumQuadsToSelect != 0)
            {
                TimeStampQuadrados.Add(timestamp.TotalMilliseconds);
                TempoSelecaoQuadrados = timestamp.TotalMilliseconds;
                textStory.Add("At " + timestamp.TotalMilliseconds + " User1 selected " + LastCollidingTypeU1 + " and there is still " + NumQuadsToSelect + " squares to select.");
            }
            else
            {
                TempoSelecaoQuadrados = timestamp.TotalMilliseconds;
                TimeStampQuadrados.Add(timestamp.TotalMilliseconds);
                textStory.Add("At " + timestamp.TotalMilliseconds + " User 1 selected all the squares.");
            }
        }
        if (U1TouchType == "double-tap" && LastCollidingTypeU1 == "circle" || U1TouchType == "double-tap" && LastCollidingTypeU1 == "triangle") // aka error
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User1 tried to select " + LastCollidingTypeU1 + " and that is not possible.");
        }
        if (U1TouchType == "double-tap" && LastCollidingTypeU1 == "square" || U1TouchType == "double-tap" && LastCollidingTypeU1 == null) // aka error do vazio
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User1 tried to select " + LastCollidingTypeU1 + ", but it's empty, so that is not possible.");
        }
        if (U2Action == "selected" && NumCircsToSelect >= 0)
        {
            if(NumCircsToSelect != 0)
            {
                TimeStampCirculos.Add(timestamp.TotalMilliseconds);
                TempoSelecaoCirculos = timestamp.TotalMilliseconds;
                textStory.Add("At " + timestamp.TotalMilliseconds + " User2 selected " + LastCollidingTypeU2 + " and there is still " + NumCircsToSelect + " circles to select.");
            }
            else
            {
                TempoSelecaoCirculos = timestamp.TotalMilliseconds;
                TimeStampCirculos.Add(timestamp.TotalMilliseconds);
                textStory.Add("At " + timestamp.TotalMilliseconds + " User 2 selected all the circles.");
            }
        }
        if (U2TouchType == "double-tap" && LastCollidingTypeU2 == "square" || U2TouchType == "double-tap" && LastCollidingTypeU2 == "triangle") //aka error
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User2 tried to select " + LastCollidingTypeU2 + " and that is not possible.");
        }
        if (U2TouchType == "double-tap" && LastCollidingTypeU2 == "circle" || U2TouchType == "double-tap" && LastCollidingTypeU2 == null) //aka error vazio
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " User2 tried to select " + LastCollidingTypeU2 + ", but it's empty, so that is not possible.");
        }

        if (NumQuadsToSelect == 0 && NumCircsToSelect == 0) //squares_inc == sqTotal && circles_inc == ccTotal)
        {
            textStory.Add("At " + timestamp.TotalMilliseconds + " All squares and circles were selected. Task completed!");
            CompletedTask = true;
            finalizou = DateTime.Now;
            TempoTotalTarefa = (finalizou-taskStart).TotalMilliseconds;
            carregouNoS();
        }

        if(!HoverU1.GetComponent<ColliderObj>().godUp) textStory.Add("At " + timestamp.TotalMilliseconds + " GOD just occurred!");
        HoverU1.GetComponent<ColliderObj>().godUp = true;
        if (repocess.GetComponent<NewTouch>().isRep) textStory.Add("At " + timestamp.TotalMilliseconds + " REPROCESS was Pressed!");
        repocess.GetComponent<NewTouch>().isRep = false;
        if (repocess.GetComponent<NewTouch>().isH) textStory.Add("At " + timestamp.TotalMilliseconds + " Troca Toques Occurred!");
        repocess.GetComponent<NewTouch>().isH = false;
    }

    void OnGUI()
    {
        if(tarefaOn == 1) GUI.Label(new Rect(10, 160, 200, 35), "Tarefa a Decorrer!");
        if(tarefaOn == 0) GUI.Label(new Rect(10, 160, 200, 35), "Tarefa Terminada!");
    }
}