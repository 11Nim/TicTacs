using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMacs : BoardController
{
    /*public struct Play
    {
        public int Line, Column;
        
    }


/*
    public void CallMiniMacs(Symbol[,] plano, Symbol bot, out Play bestPlay)
    {
        
        int sla;
        sla = DoMiniMacs(plano, bot, bot, out bestPlay);
        //ajeitar aqui edpois pra retornar direito a bestplay e o spot
    }
*/
/*
    public Symbol Outro(Symbol um)
    {
        if (um == Symbol.Fumiga)
            return Symbol.Besouro;
        else if(um == Symbol.Besouro)
            return Symbol.Fumiga;
        else return Symbol.None;
    }

    public int DoMiniMacs(Symbol[,] plano, Symbol máquina, Symbol quemJoga, out Play bestPlay)
    {
        int bestValor;
        int newValor;
        int newLine = 0;
        int newColumn = 0;

        bestPlay.Line = 0;
        bestPlay.Column = 0;
        
        if (HasWinner(plano)) //verifica se alguém ganhou ou se deu velha
        {
            if(quemJoga != máquina)
                return 1;
            else 
                return -1;
        } else if(NoMorePlays(plano))
                return 0;






        if (quemJoga != máquina)
        {   
            quemJoga = máquina;
            bestValor = 2;
            
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if(plano[i,j] == Symbol.None) //pra cada espaço q não estiver preenchido
                    {
                        plano[i,j] = Outro(máquina); //seta no tabuleiro o simbolo do jogador
                        newValor = DoMiniMacs(plano, máquina, quemJoga, out bestPlay); //e chama a função em cima do novo tabuleiro
                    
                        if(bestValor > newValor)// se este lugar tiver a melhor jogada possivel salva os dados
                        {
                           bestValor = newValor;
                           newLine = i;
                           newColumn = j;
                        }
                        plano[i,j] = Symbol.None; // e reseta o tabuleiro 
                    }
                }
            }
            bestPlay.Line = newLine;
            bestPlay.Column = newColumn;
            return bestValor;

        } else 
        if (quemJoga == máquina)
        {   
            quemJoga = Outro(máquina);
            bestValor = -2;
            
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if(plano[i,j] == Symbol.None) //pra cada espaço q não estiver preenchido
                    {
                        plano[i,j] = máquina; //seta no tabuleiro o simbolo do jogador
                        newValor = DoMiniMacs(plano, máquina, quemJoga, out bestPlay); //e chama a função em cima do novo tabuleiro
                    
                        if(bestValor < newValor)// se este lugar tiver a melhor jogada possivel salva os dados
                        {
                           bestValor = newValor;
                           newLine = i;
                           newColumn = j;
                        }
                        plano[i,j] = Symbol.None; // e reseta o tabuleiro 
                    }
                }
            }
        bestPlay.Line = newLine;
        bestPlay.Column = newColumn;
        return bestValor;

        }





    return 999;


    }

*/
    
}
