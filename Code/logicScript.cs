using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject win;
    public GameObject loose;
    private hardLandingScript hardlanding;
    void Start()
    {
        hardlanding = GameObject.FindGameObjectWithTag("hard landing").GetComponent<hardLandingScript>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void winGame()
    {
        win.SetActive(true);
    }
    public void looseGame()
    {
        loose.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
