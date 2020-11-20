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
    
    public void TheBotStart()
    {
        
        botaoBOTS.gameObject.SetActive(!botaoBOTS);
        botaoPS.gameObject.SetActive(!botaoPS);
        GetComponentInParent<BoardController>().botStart = true;
        GetComponentInParent<BoardController>().GameStart = true;
        GetComponentInParent<BoardController>().MiniMacsPlay();

    }

    public void ThePStart()
    {
        
        botaoBOTS.gameObject.SetActive(!botaoBOTS);
        botaoPS.gameObject.SetActive(!botaoPS);
        GetComponentInParent<BoardController>().botStart = false;
        GetComponentInParent<BoardController>().GameStart = true;

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

    }

}
