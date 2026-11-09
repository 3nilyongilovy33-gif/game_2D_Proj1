using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private string firstScene = "Scn_World";
    [SerializeField] private bool disableInput;
    private IMoveInput moveInput;

    void Awake()
    {
        if (disableInput) moveInput = new DisabledMoveInput();
        else moveInput = new InputSystemMoveInput();
    }

    IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(firstScene));
        FindAnyObjectByType<WorldInstaller>().Install(moveInput);
    }
}