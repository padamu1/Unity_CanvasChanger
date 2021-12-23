using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    public static CanvasChanger instance = null;

    public Canvas titleCanvas;
    public Canvas menuCanvas;
    public Canvas singleGameCanvas;
    public CanvasGroup titleScreen;
    public CanvasGroup menuScreen;
    public CanvasGroup singleGameScreen;

    private int activeScreen;
    private Stack<int> beforeSelect;
    void Awake()
    {
        if (instance == null)
            instance = this;
        beforeSelect = new Stack<int>();
        titleScreen.alpha = 1;
        titleCanvas.enabled = true;
        menuScreen.alpha = 0;
        menuCanvas.enabled = false;
        singleGameScreen.alpha = 0;
        singleGameCanvas.enabled = false;
        beforeSelect.Push(1);
        activeScreen = 1;
    }

    public void activateScreen(string selectScreen)
    {
        switch (selectScreen)
        {
            case "title":
                Debug.Log("active 1");
                titleScreenActive();
                beforeSelect = new Stack<int>();
                break;
            case "menu":
                beforeSelect.Push(activeScreen);
                Debug.Log("active 2");
                menuScreenActive();
                break;
            case "single":
                beforeSelect.Push(activeScreen);
                Debug.Log("active 3");
                singleGameScreenActive();
                break;
            default:
                break;
        }
    }
    
    public void undoScreen()
    {
        switch (beforeSelect.Pop())
        {
            case 1:
                Debug.Log("active 1");
                titleScreenActive();
                break;
            case 2:
                Debug.Log("active 2");
                menuScreenActive();
                break;
            case 3:
                Debug.Log("active 3");
                singleGameScreenActive();
                break;
            default:
                break;
        }
    }

    public void titleScreenActive()
    {
        activeScreen = 1;
        titleScreen.alpha = 1;
        titleScreen.interactable = true;
        titleCanvas.enabled = true;
        menuCanvas.enabled = false;
    }
    
    public void menuScreenActive()
    {
        activeScreen = 2;
        menuScreen.alpha = 1;
        menuScreen.interactable = true;
        titleCanvas.enabled = false;
        menuCanvas.enabled = true;
        singleGameCanvas.enabled = false;
    }

    public void singleGameScreenActive()
    {
        activeScreen = 3;
        singleGameScreen.alpha = 1;
        singleGameScreen.interactable = true;
        menuCanvas.enabled = false;
        singleGameCanvas.enabled = true;
    }
}
