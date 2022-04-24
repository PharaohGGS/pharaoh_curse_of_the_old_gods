using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using SaveDataManager = Pharaoh.Managers.SaveDataManager;

public class PauseMenu: MonoBehaviour
{

    [Header("Menu displaying")]
    public static bool isGamePaused = false;
    public InputReader inputReader;
    public GameObject pausePanel;

    [Header("Canopic Jars")]
    public MeshFilter[] jars;
    public Mesh[] openedMeshes;
    public GameObject[] labels;
    public PlayerSkills playerSkills;

    private void OnEnable()
    {
        inputReader.exitPerformedEvent += OnPauseMenu;
    }

    private void OnDisable()
    {
        inputReader.exitPerformedEvent -= OnPauseMenu;
    }

    public void OnPauseMenu()
    {
        if (isGamePaused)
            UnpauseGame();
        else
            PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);

        DisplaySkills();

        isGamePaused = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

        isGamePaused = false;
    }

    public void Continue()
    {
        UnpauseGame();
    }

    public void Save()
    {
        SaveDataManager.Instance.Save();
    }

    public void MainMenu()
    {
        UnpauseGame();
        SceneManager.LoadScene(0);
    }

    private void DisplaySkills()
    {
        if (playerSkills.HasDash)
        {
            jars[0].mesh = openedMeshes[0];
            labels[0].SetActive(true);
        }
        if (playerSkills.HasGrapplingHook)
        {
            jars[1].mesh = openedMeshes[1];
            labels[1].SetActive(true);
        }
        if (playerSkills.HasSwarmDash)
        {
            jars[2].mesh = openedMeshes[2];
            labels[2].SetActive(true);
        }
        if (playerSkills.HasSandSoldier)
        {
            jars[3].mesh = openedMeshes[3];
            labels[3].SetActive(true);
        }
        if (playerSkills.HasHeart)
        {
            jars[4].mesh = openedMeshes[4];
        }
    }

}
