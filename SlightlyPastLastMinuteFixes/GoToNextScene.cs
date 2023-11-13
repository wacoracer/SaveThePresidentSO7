using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public GameObject textFirst;
    public GameObject textSecond;
    private GameObject mainMenu;
    [SerializeField] float firstWait = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GameObject.FindWithTag("ThisIsTheOneBBG");
        StartCoroutine(NextScene());
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            mainMenu.GetComponent<MainMenu>().MenuButton();
        }
    }


    IEnumerator NextScene()
    {
        textFirst.SetActive(true);
        yield return new WaitForSeconds(firstWait);
        textSecond.SetActive(true);
    }
}
