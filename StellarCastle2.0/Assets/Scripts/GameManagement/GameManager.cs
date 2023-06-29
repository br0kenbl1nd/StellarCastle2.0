using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerBase;

    public GameOver gameOver;
    public GamePaused gamePaused;
    public GameWon gameWon;
    public UIManager uiManager;

    private void Update()
    {
        if (playerBase == null)
        {
            GameOver();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            GamePaused();
        }

    } //update


    public void GameOver()
    {
        gameOver.PlayerGameOver();

    } //game over

    void GamePaused()
    {
        gamePaused.PlayerGamePaused();
    }

    void GameWon()
    {
        gameWon.PlayerGameWon();
    }

} //class
