using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Slider coffeeBar;
    public float coffeeAmmount;
    private float drainRate = 4;
    public Text gameEndText;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        coffeeAmmount = 100;
        coffeeBar.maxValue = coffeeAmmount;
        gameEndText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coffeeBar.value = coffeeAmmount;
        if (gameOver == false)
        {
            if (coffeeAmmount > 0)
            {
                coffeeAmmount -= Time.deltaTime * drainRate;
            } else
            {
                gameOver = true;
                gameEndText.text = "Too little coffee, fell alseep.";
                gameEndText.gameObject.SetActive(true);
                GetComponent<CharacterController>().enabled = false;
                Invoke("Restart", 2);
            }

            if (coffeeAmmount > 100)
            {
                coffeeAmmount = 100;
            }
        }        
    }

    public void Win()
    {
        gameOver = true;
        gameEndText.text = "Documents found. Your job is safe!";
        gameEndText.gameObject.SetActive(true);
        GetComponent<CharacterController>().enabled = false;
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
