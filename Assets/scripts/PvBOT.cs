using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvBOT : MonoBehaviour
{
    
    public Button botao1;
    public GameObject botaopvbot;
    public GameObject botaopvp;
    public GameObject botaoBOTS;
    public GameObject botaoPS;
    public GameObject botaoFumigaWon;
    public GameObject botaoBorboWon;
    public GameObject botaoQuit;
    public GameObject botaoDraw;

    public void Update()
    {
        if(GetComponentInParent<BoardController>().Empate)
        {
            GetComponentInParent<BoardController>().Empate = false;
            botaoDraw.gameObject.SetActive(botaoDraw);
            botaoQuit.gameObject.SetActive(botaoQuit);
        }

        if(GetComponentInParent<BoardController>().FumigaGanhou)
        {
            GetComponentInParent<BoardController>().FumigaGanhou = false;
            botaoFumigaWon.gameObject.SetActive(botaoFumigaWon);
            botaoQuit.gameObject.SetActive(botaoQuit);
        }
        if(GetComponentInParent<BoardController>().BorboGanhou)
        {
            GetComponentInParent<BoardController>().BorboGanhou = false;
            botaoBorboWon.gameObject.SetActive(botaoBorboWon);
            botaoQuit.gameObject.SetActive(botaoQuit);
        }

    }
    
    public void TheBotStart()
    {
        
        botaoBOTS.gameObject.SetActive(!botaoBOTS);
        botaoPS.gameObject.SetActive(!botaoPS);
        GetComponentInParent<BoardController>().botStart = true;
        GetComponentInParent<BoardController>().GameStart = true;
        GetComponentInParent<BoardController>().MiniMacsPlay();
        GetComponentInParent<BoardController>().player = 0;

    }

    public void ThePStart()
    {
        
        botaoBOTS.gameObject.SetActive(!botaoBOTS);
        botaoPS.gameObject.SetActive(!botaoPS);
        GetComponentInParent<BoardController>().botStart = false;
        GetComponentInParent<BoardController>().GameStart = true;
        GetComponentInParent<BoardController>().player = 0;

    }
    
    public void PlayvBOT()
    {
        botaopvbot.gameObject.SetActive(!botaopvbot);
        botaopvp.gameObject.SetActive(!botaopvp);
        GetComponentInParent<BoardController>().Loner = true;
        botaoBOTS.gameObject.SetActive(botaoBOTS);
        botaoPS.gameObject.SetActive(botaoPS);

    }

    public void PlayvPlay()
    {
        botaopvbot.gameObject.SetActive(!botaopvbot);
        botaopvp.gameObject.SetActive(!botaopvp);
        GetComponentInParent<BoardController>().Loner = false;
        GetComponentInParent<BoardController>().GameStart = true;
        GetComponentInParent<BoardController>().player = 0;

    }

    public void BorboWon()
    {
        botaoBorboWon.gameObject.SetActive(!botaoBorboWon);
        botaoQuit.gameObject.SetActive(!botaoQuit);
        botaopvbot.gameObject.SetActive(botaopvbot);
        botaopvp.gameObject.SetActive(botaopvp);
        GetComponentInParent<BoardController>().ResetaTabuleiro();
    }

    public void FumigaWon()
    {
        botaoFumigaWon.gameObject.SetActive(!botaoFumigaWon);
        botaoQuit.gameObject.SetActive(!botaoQuit);
        botaopvbot.gameObject.SetActive(botaopvbot);
        botaopvp.gameObject.SetActive(botaopvp);
        GetComponentInParent<BoardController>().ResetaTabuleiro();
    }

    public void Quit()
    {
        botaoBorboWon.gameObject.SetActive(!botaoBorboWon);
        botaoFumigaWon.gameObject.SetActive(!botaoFumigaWon);
        botaoDraw.gameObject.SetActive(!botaoDraw);
        botaoQuit.gameObject.SetActive(!botaoQuit);
    }

    public void Draw()
    {
        botaoDraw.gameObject.SetActive(!botaoDraw);
        botaoQuit.gameObject.SetActive(!botaoQuit);
        botaopvbot.gameObject.SetActive(botaopvbot);
        botaopvp.gameObject.SetActive(botaopvp);
        GetComponentInParent<BoardController>().ResetaTabuleiro();
    }

}
