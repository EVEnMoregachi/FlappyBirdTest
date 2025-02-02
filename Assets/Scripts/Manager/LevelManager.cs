using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public List<Level> levels;
    public int currentLevelID = 1;
    public Level level;

    public void LoadLevel(int levelID)
    {
        this.level = Instantiate<Level>(levels[levelID - 1]);
    }
}
