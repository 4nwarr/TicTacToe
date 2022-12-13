using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] Image canvasImage;
    [SerializeField] Sprite crossImage, circleImage;

    private void Start()
    {
        playerText.text = "Player 1";
        canvasImage.sprite = crossImage;
    }

    public void SwapPlayer()
    {
        if (playerText.text == "Player 1")
        {
            playerText.text = "Player 2";
            canvasImage.sprite = circleImage;
        }
        else
        {
            playerText.text = "Player 1";
            canvasImage.sprite = crossImage;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
