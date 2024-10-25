using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Player player;
    private int cratesDestroyed = 0;

    private int[] crateGoals = { 3, 5, 8 };

    void Start()
    {
        player = FindObjectOfType<Player>();
        ResetLevel();
    }

    public void ResetLevel()
    {
        cratesDestroyed = 0;
    }

    public void CrateDestroyed()
    {
        cratesDestroyed++;
        Debug.Log("Crate destroyed! Total: " + cratesDestroyed);

        if (cratesDestroyed >= crateGoals[Mathf.Clamp(player.level - 1, 0, crateGoals.Length - 1)])
        {
            Debug.Log("Level Completed!");
            player.AdvanceLevel();
            ResetLevel();
        }
    }

    public void LevelFailed()
    {
        Debug.Log("Level Failed.");
        player.DropLevel();
        ResetLevel();
    }
}
