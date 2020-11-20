using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Symbol
    {
        None,
        Besouro,
        Fumiga
    }

public class Spot : MonoBehaviour
{

    public int Line;
    public int Column;
    public GameObject BesouroObjectRoot;
    public GameObject FumigaObjectRoot;
    
    
    


    private Symbol _currentsymbol;

    public Symbol CurrentSymbol
    {
        set
        {
            
                _currentsymbol = value; 
                BesouroObjectRoot.SetActive(_currentsymbol == Symbol.Besouro);
                
                FumigaObjectRoot.SetActive(_currentsymbol == Symbol.Fumiga);
           
        }
        get
        {
            return _currentsymbol;
        }
    }

    private void start()
    {
        CurrentSymbol = Symbol.None;
    }


    void Update()
    {
        //if(GetComponentInParent<BoardController>().Tabuleiro[Line,Column] == Symbol.Besouro)
            CurrentSymbol = GetComponentInParent<BoardController>().Tabuleiro[Line,Column];
    }

    private void OnMouseDown()
    {
        
        if((CurrentSymbol == Symbol.None) && GetComponentInParent<BoardController>().GameStart) //se o jogador estiver jogando sozinho
        {
            if(GetComponentInParent<BoardController>().Loner && GetComponentInParent<BoardController>().player == 0)
            {
                if(GetComponentInParent<BoardController>().player == 0)
                    GetComponentInParent<BoardController>().SpotClickedPlayer(this);

            }else //se ele estiver jogando com outra pessoa
            if((GetComponentInParent<BoardController>().player == 0 || GetComponentInParent<BoardController>().player == 2) && !GetComponentInParent<BoardController>().Loner)
            {
                if(GetComponentInParent<BoardController>().player == 0)
                    GetComponentInParent<BoardController>().SpotClickedBesouro(this);
                 else if(GetComponentInParent<BoardController>().player == 2)
                    GetComponentInParent<BoardController>().SpotClickedFumiga(this);  
        }
        }
    }


    
    /*
    private void MoveCross()
    {
        CurrentSymbol = Symbol.Besouro;
        GetComponentInParent<BoardController>().player = 1; //seta jogador para um estado intermediário p/ ninguem realizar ações
        
    //put code here

        Debug.Log("clicked " + Line + "," + Column + CurrentSymbol);
        GetComponentInParent<BoardController>().player = 2; //permite que o outro jogador jogue
    }

    private void MoveFumiga()
    {
        CurrentSymbol = Symbol.Fumiga;
        GetComponentInParent<BoardController>().player = 1; //seta jogador para um estado intermediário p/ ninguem realizar ações

    //put code here

        Debug.Log("clicked " + Line + "," + Column + CurrentSymbol);       
        GetComponentInParent<BoardController>().player = 0; //permite que o outro jogador jogue
    }
    */
}
