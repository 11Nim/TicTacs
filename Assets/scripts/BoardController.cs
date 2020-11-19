using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class BoardController : MonoBehaviour //ver se dá problema derivar o boardcontroller de spot p usar o symbol
{
    public int BoardSize = 3;
    public Symbol[,] Tabuleiro;
    

    public bool Loner = true;
    public bool botStart = false;
   
    public int player; //player 0 = jogador 1, player 1 = entre estados, player 2 = jogador 
    
    private void Awake()
    {
        player = 0;
        Tabuleiro = new Symbol[BoardSize, BoardSize];



        if(Loner && botStart)
        {
            MiniMacsPlay();
        }
        
    }



    public void MiniMacsPlay()
    {
        if(botStart)//
        {
            player = 1;
            Play novaJogada = new Play();
            DoMiniMacs(Tabuleiro, Symbol.Besouro, Symbol.Fumiga, out novaJogada);
            Tabuleiro[novaJogada.Line, novaJogada.Column] = Symbol.Fumiga;//tem q ajeitar isso aqui, fazer mudar o negócio no spot
            if(HasWinner(Tabuleiro))
            {
                Debug.Log("Fumiga won");
                return;
            }
            player = 0;
        }else{
            player = 1;
            Play novaJogada = new Play();
            DoMiniMacs(Tabuleiro, Symbol.Besouro, Symbol.Besouro, out novaJogada);
            Tabuleiro[novaJogada.Line, novaJogada.Column] = Symbol.Besouro;
            if(HasWinner(Tabuleiro))
            {
                Debug.Log("Besouro won");
                return;
            }
            player = 0;
        }
    }





    public void SpotClickedPlayer(Spot spot)//movimenta a peça contra bot
    {
        
        player = 1; //seta jogador para um estado intermediário p/ ninguem realizar ações
        if(botStart)
        {
            Tabuleiro[spot.Line, spot.Column] = Symbol.Besouro;
            spot.CurrentSymbol = Symbol.Besouro;//esse codigo vai ligar o symbol e fazer ele andar
            if(HasWinner(Tabuleiro))
            {
                Debug.Log("Besouro won");   
                return;
            }
        }else
        {
            Tabuleiro[spot.Line, spot.Column] = Symbol.Fumiga;
            spot.CurrentSymbol = Symbol.Fumiga;//esse codigo vai ligar o symbol e fazer ele andar
            if(HasWinner(Tabuleiro))
            {
                Debug.Log("Fumiga won");   
                return;
            }
        }
        Debug.Log("clicked " + spot.Line + "," + spot.Column);   
        
        
        if(NoMorePlays(Tabuleiro))
        {
            Debug.Log("it's a draw");
            return;
        }

        MiniMacsPlay();//no termino do minimacs o jogador é setado para 0
         
    }

    public void SpotClickedFumiga(Spot spot)//movimenta a formiga no pvp
    {
        
        player = 1; //seta jogador para um estado intermediário p/ ninguem realizar ações
        Tabuleiro[spot.Line, spot.Column] = Symbol.Fumiga;
    //put code here
        spot.CurrentSymbol = Symbol.Fumiga;//esse codigo vai ligar o symbol e fazer ele andar
        Debug.Log("clicked " + spot.Line + "," + spot.Column);   
        if(HasWinner(Tabuleiro))
        {
            Debug.Log("Fumiga won");   
            return;
        }
        
        if(NoMorePlays(Tabuleiro))
        {
            Debug.Log("it's a draw");
            return;
        }
        player = 0; //permite que o outro jogador jogue  
    }

    public void SpotClickedBesouro(Spot spot)//movimenta o besouro no pvp
    {
        
        player = 1; //seta jogador para um estado intermediário p/ ninguem realizar ações
        Tabuleiro[spot.Line, spot.Column] = Symbol.Besouro;
    //put code here
        spot.CurrentSymbol = Symbol.Besouro;//vai ligar o symbol e fazer ele andar
        Debug.Log("clicked " + spot.Line + "," + spot.Column);
        if(HasWinner(Tabuleiro))
        {
            Debug.Log("Besouro won");
            return;
        }
        if(NoMorePlays(Tabuleiro))
        {
            Debug.Log("it's a draw");
            return;
        }
        player = 2; //permite que o outro jogador jogue
    }






    //***********************************************términos*************************************************************





    public bool HasWinner(Symbol[,] symbol) //verifica todas as possibilidades de vitória e retorna true se alguem ganhou
    {                                       //obs: nao funciona se mudar o tabuleiro
        if ((symbol[0,0] == symbol[0,1] && symbol[0,0] == symbol[0,2] && symbol[0,0] != Symbol.None) ||
            (symbol[1,0] == symbol[1,1] && symbol[1,0] == symbol[1,2] && symbol[1,0] != Symbol.None) ||
            (symbol[2,0] == symbol[2,1] && symbol[2,0] == symbol[2,2] && symbol[2,0] != Symbol.None) ||
            (symbol[0,0] == symbol[1,0] && symbol[0,0] == symbol[2,0] && symbol[0,0] != Symbol.None) ||
            (symbol[0,1] == symbol[1,1] && symbol[0,1] == symbol[2,1] && symbol[0,1] != Symbol.None) ||
            (symbol[0,2] == symbol[1,2] && symbol[0,2] == symbol[2,2] && symbol[0,2] != Symbol.None) ||
            (symbol[0,0] == symbol[1,1] && symbol[0,0] == symbol[2,2] && symbol[0,0] != Symbol.None) ||
            (symbol[2,0] == symbol[1,1] && symbol[2,0] == symbol[0,2] && symbol[2,0] != Symbol.None))
            return true;
        else
            return false;       
            
    }


    public bool NoMorePlays(Symbol[,] symbol)//verifica se ainda há locais vagos no tabuleiro
    {
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if(symbol[i,j] == Symbol.None)
                    return false;
            }
        }
        return true;
    }

    
    //************************************************************minimax********************************************************
    
    public struct Play
    {
        public int Line, Column;
        
    }



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


}
