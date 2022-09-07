using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Image EndScreen;
    public Text EndText;
    Color ImageColor = new Color();
    Color TextColor = new Color();
    int n;
    bool delayForRestart=false;

    void Start()
    {
        EndScreen.color = ImageColor;
        EndText.color = TextColor;
        ImageColor = Color.black;
        TextColor = Color.white;
    }

    void Update()
    {
        if (EndScreen.color!=ImageColor || EndText.color !=TextColor)
        {
            EndScreen.color = Color.Lerp(EndScreen.color, ImageColor, Time.deltaTime * 2);
            EndText.color = Color.Lerp(EndText.color, TextColor, Time.deltaTime * 2);
        }
        else delayForRestart = true;
        Restart();
    }
    void Restart()
    {
        if (delayForRestart)
        {
            System.Threading.Thread.Sleep(2000);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
