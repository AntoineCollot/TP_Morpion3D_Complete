using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public GameObject tokenPrefab;
    public Color color;

    List<Vector3Int> playedCoords = new List<Vector3Int>();

    public void AddCoords(Vector3Int coords)
    {
        playedCoords.Add(coords);
    }

    public bool HasWon()
    {
        //Create a list of coords to check if they won or not
        //Use a new list that we can modify, to avoid messing up the playedCoords list.
        List<Vector3Int> openList = new List<Vector3Int>(playedCoords);

        //While there are item in the list
        while(openList.Count > 0)
        {
            //Pick the first item on the list
            Vector3Int currentCell = openList[0];
            //Immediatly remove it from the list, as if it's not part of an alignement we don't need to care about it anymore
            openList.RemoveAt(0);

            //For each other cell in the list
            foreach (Vector3Int candidate in openList)
            {
                //Find the vector of translation in between the current and the candidate
                Vector3Int delta = candidate - currentCell;
                //If there is another cell in the same direction from the candidate cell, it means 3 are aligned
                if (openList.Contains(candidate + delta))
                    return true;
                //Also check the other side, aka the inverse direction from the current cell.
                if (openList.Contains(currentCell - delta))
                    return true;
            }
        }
        return false;
    }
}
