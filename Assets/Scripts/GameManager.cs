using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    private int turn = 1;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        // Shuffle decks, draw opening hands
        for (int i = 0; i < 3; i++)
        {
            player1.DrawCard();
            player2.DrawCard();
        }
    }

    public void EndTurn()
    {
        turn++;
        if (turn % 2 == 1)
        {
            Debug.Log("Player 1's turn");
            player1.DrawCard();
        }
        else
        {
            Debug.Log("Player 2's turn");
            player2.DrawCard();
        }
    }
}
