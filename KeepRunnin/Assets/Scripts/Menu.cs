using UnityEngine;

public class Menu : MonoBehaviour
{
    public string level;

    public void Play()
    {
        Application.LoadLevel(level);
    }//play

    public void Quit()
    {
        Application.Quit();
    }
}