using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Tilemaps;

[System.Serializable]
public class LevelGenerator : MonoBehaviour
{
    #region Fields

    public int progress;
    //private int jumpHeightTiles = 0;
    //private int dropHeightTiles = 0;
    //private int topEdge = 0;
    //private int bottomEdge = 0;
    //private int leftEdge = 0;
    //private int rightEdge = 0;
    private int numberOfPlatforms = 20;
    private int platformMaxLength = 6;
    private int maxGap = 4;
    [SerializeField]
    private Tilemap ground = null;
    [SerializeField]
    private Tilemap background = null;
    [SerializeField]
    private Tile[] groundSoloTiles = null;
    [SerializeField]
    private Tile[] groundFloatingTiles = null;
    [SerializeField]
    private Tile[] groundRegularTiles = null;
    [SerializeField]
    private Tile[] backgroundTiles = null;
    private static System.Random random = new System.Random();

    #endregion

    #region Properties

    #endregion

    #region Methods


    private void GenerateGround(ref Tile[] type, Vector3Int startCell, int patternStart, int tilesPerPattern, int numberOfTiles)
    {
        for (var i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                ground.SetTile(startCell, type[patternStart]);
            else if (i == numberOfTiles - 1)
                ground.SetTile(startCell, type[patternStart + tilesPerPattern - 1]);
            else
            {
                // TO DO: Randomize middle tiles as not all patterns might have just 1 middle
                ground.SetTile(startCell, type[patternStart + 1]);
            }
            startCell.x += 1;
        }
    }
    private void GenerateBackground()
    {

    }

    private void GenerateScenery()
    {

    }

    public void GenerateLevel()
    {
        Vector3Int currentCell = ground.WorldToCell(transform.position);
        ground.SetTile(currentCell, groundFloatingTiles[random.Next(groundFloatingTiles.Length)]);
        while (numberOfPlatforms > 0)
        {
            
            int pattern, patternLength;
            int platformLength = 0;
            int gap = random.Next(0, maxGap);
            int type = random.Next(0, 2);
            switch (type)
            {
                case 0:
                    platformLength = 1;
                    patternLength = 1;
                    pattern = random.Next(groundSoloTiles.Length);
                    GenerateGround(ref groundSoloTiles, currentCell, pattern, patternLength, platformLength);
                    break;
                case 1:
                    platformLength = random.Next(2, platformMaxLength);
                    patternLength = 3;
                    pattern = SelectPattern(groundFloatingTiles.Length, 3);
                    GenerateGround(ref groundFloatingTiles, currentCell, pattern, patternLength, platformLength);
                    break;
                case 2:
                    platformLength = random.Next(2, platformMaxLength);
                    patternLength = 3;
                    pattern = SelectPattern(groundRegularTiles.Length, 3);
                    GenerateGround(ref groundRegularTiles, currentCell, pattern, patternLength, platformLength);
                    //GenerateBackground();
                    //int backgroundCount = random.Next(0, length / 2);
                    break;
            }
            currentCell.x += platformLength + gap;
            numberOfPlatforms--;

        }
    }

    private int SelectPattern(int numberOfTiles, int patternSize)
    {
        int[] values = new int[numberOfTiles / patternSize];
        values[0] = 0;
        for (var i = 1; i < values.Length; i++)
            values[i] = values[i - 1] + patternSize;
        return values[random.Next(values.Length)];
    }


    // Start is called before the first frame update
    void Start()
    {
        // Verification of how much impact the level generator has.
#if DEBUG
        Profiler.BeginSample("LevelGeneration");
#endif
        GenerateLevel();
#if DEBUG
        Profiler.EndSample();
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
}
