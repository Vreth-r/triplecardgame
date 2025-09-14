using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    private Player currentPlayer;
    private int turnNumber = 0;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            player1.DrawAll();
            player2.DrawAll();
        }

        // Player 1 starts
        currentPlayer = player1;
        StartTurn();
    }

    void StartTurn()
    {
        turnNumber++;
        Debug.Log($"--- Turn {turnNumber} --- {currentPlayer.playerName}'s turn");

        // Gain mana
        currentPlayer.GainMana();

        // Draw from each deck
        currentPlayer.DrawAll();

        // Now player can take actions (play cards, attack, etc.)
    }

    public void EndTurn()
    {
        currentPlayer = (currentPlayer == player1) ? player2 : player1;
        StartTurn();
    }
}
