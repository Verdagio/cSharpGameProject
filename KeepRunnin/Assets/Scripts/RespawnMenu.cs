using UnityEngine;

public class RespawnMenu : MonoBehaviour
{
    public int state;

    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
    }//restart

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
}