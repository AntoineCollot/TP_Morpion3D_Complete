using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    PlayCell selectedCell;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out RaycastHit hit, Mathf.Infinity))
        {
            if(hit.collider.TryGetComponent(out PlayCell cell))
            {
                SelectCell(cell);
            }
        }

        if(selectedCell != null && Input.GetMouseButtonDown(0))
        {
            gameManager.PlayInCell(selectedCell);
        }
    }

    void SelectCell(PlayCell cell)
    {
        if (selectedCell == cell)
            return;
        if (selectedCell != null)
            selectedCell.OnHoverExit();
        selectedCell = cell;
        selectedCell.OnHoverEnter();
    }
}
