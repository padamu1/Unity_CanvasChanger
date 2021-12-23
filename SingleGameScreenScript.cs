using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleGameScreenScript : MonoBehaviour
{
    private int selector;
    public void LoadMap()
    {
        selector = 1;
        StartCoroutine(DoActive());
    }

    public void Undo()
    {
        selector = 2;
        StartCoroutine(DoActive());
    }

    IEnumerator DoActive()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
        switch (selector)
        {
            case 1:
                Debug.Log("active 1");
                CanvasChanger.instance.activateScreen("title");
                SceneManager.LoadScene("SinglePlay");
                break;
            case 2:
                CanvasChanger.instance.undoScreen();
                break;
            default:
                break;
        }
    }
}
