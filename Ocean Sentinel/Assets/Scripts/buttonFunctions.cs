using UnityEngine;
using UnityEngine.SceneManagement;

//script created by Brock Barlow
//this script will give buttons things to do when clicked.;

public class buttonFunctions : MonoBehaviour {

	public void startGame() //this function is used to load the game scene.
    {                       //this function will also be used for the restart button.
        SceneManager.LoadScene("Game");
    }

    public void viewBoard() //this function is used to load the leaderboard scene.
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void returnTitle() //this function will reload the main/title scene.
    {
        SceneManager.LoadScene("Main");
    }

    public void viewControls() //this function will load the controls scene.
    {
        SceneManager.LoadScene("Controls");
    }

    public void exitGame() //this function is used to exit the game (will only work when built as an exe)
    {
        Application.Quit();
    }
}