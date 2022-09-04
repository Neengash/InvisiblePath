using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Feto;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField] public BoardScriptable boardConfig;
    [SerializeField] InputManager playerInput;
    [SerializeField] TextMeshProUGUI p1Turn, p2Turn;
    public GameCell[][] gameBoard;

    Player currentTurn;

    public void StartGame() {
        ScoreManager.Instance.ResetScores();

        CellData[][] boardData = BoardData.Generate(boardConfig.boardSize);
        gameBoard = GameBoard.Generate(boardData);

        // Set scoring space

        SetTurn(Player.FIRST);

        playerInput.enabled = true;
    }

    private void SetTurn(Player newTurn) {
        currentTurn = newTurn;
        p1Turn.text = (currentTurn == Player.FIRST) ? "TURN" : " ";
        p2Turn.text = (currentTurn == Player.FIRST) ? " " : "TURN";
    }

    public void NextTurn() {
        Player nextTurn = currentTurn == Player.FIRST
            ? Player.SECOND
            : Player.FIRST;
        SetTurn(nextTurn);
        // TODO: Coroutine might not be necessary
        playerInput.enabled = true;
    }

}
