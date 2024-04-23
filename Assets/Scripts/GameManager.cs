using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayer;
    public Player[] players;

    // Start is called before the first frame update
    void Start()
    {
        //Init for first player
        currentPlayer = -1;
        NextPlayerTurn();
    }

    public bool PlayInCell(PlayCell cell)
    {
        if (cell.HasToken)
            return false;

        //Spawn prefab
        GameObject newToken = Instantiate(players[currentPlayer].tokenPrefab, cell.transform);
        newToken.transform.localPosition = Vector3.zero;
        cell.SetToken(newToken);

        //Update player
        players[currentPlayer].AddCoords(cell.coords);
        CheckVictory();

        //Next turn
        NextPlayerTurn();
        return true;
    }

    public void NextPlayerTurn()
    {
        currentPlayer++;
        currentPlayer = currentPlayer % players.Length;

        Shader.SetGlobalColor("_CurrentPlayerColor", players[currentPlayer].color);
    }

    public void CheckVictory()
    {
        if(players[currentPlayer].HasWon())
        {
            Debug.Log($"Player {currentPlayer} wins!");
        }
    }
}
