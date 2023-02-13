using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    private int _mazeSize = 10;
    private float _size = 1f;

    [SerializeField]
    private Transform _wallPrefab = null;
    [SerializeField]
    private Transform _cubePrefab = null;

    void Start()
    {
        var cube = Instantiate(_cubePrefab, transform) as Transform;
        cube.position = new Vector3(-_mazeSize * 0.05f, -_mazeSize * 0.45f, -_mazeSize * 0.05f);
        var cubeScale = _mazeSize - (_mazeSize / 10 + 0.9f);
        cube.localScale = new Vector3(cubeScale, cubeScale, cubeScale);

        var maze1 = MazeGenerator.Generate(_mazeSize, _mazeSize);
        var maze2 = MazeGenerator.Generate(_mazeSize, _mazeSize);
        var maze3 = MazeGenerator.Generate(_mazeSize, _mazeSize);
        var maze4 = MazeGenerator.Generate(_mazeSize, _mazeSize);
        var maze5 = MazeGenerator.Generate(_mazeSize, _mazeSize);
        var maze6 = MazeGenerator.Generate(_mazeSize, _mazeSize);

        var parent1 = new GameObject("Maze 1").transform;
        var parent2 = new GameObject("Maze 2").transform;
        var parent3 = new GameObject("Maze 3").transform;
        var parent4 = new GameObject("Maze 4").transform;
        var parent5 = new GameObject("Maze 5").transform;
        var parent6 = new GameObject("Maze 6").transform;

        parent1.transform.parent = transform;
        parent2.transform.parent = transform;
        parent3.transform.parent = transform;
        parent4.transform.parent = transform;
        parent5.transform.parent = transform;
        parent6.transform.parent = transform;

        Draw(maze1, parent1);
        Draw(maze2, parent2);
        Draw(maze3, parent3);
        Draw(maze4, parent4);
        Draw(maze5, parent5);
        Draw(maze6, parent6);

        parent1.position += new Vector3(0, 0, 0);
        parent1.eulerAngles += new Vector3(0, 0, 0);
        parent2.position += new Vector3(0, -_mazeSize * 0.5f, _mazeSize * 0.4f);
        parent2.eulerAngles += new Vector3(90, 0, 0);
        parent3.position += new Vector3(0, -_mazeSize * 0.5f, -_mazeSize * 0.5f);
        parent3.eulerAngles += new Vector3(90, 0, 0);
        parent4.position += new Vector3(0, -_mazeSize * 0.9f, 0);
        parent4.eulerAngles += new Vector3(0, 0, 0);
        parent5.position += new Vector3(_mazeSize * 0.4f, -_mazeSize * 0.4f, 0);
        parent5.eulerAngles += new Vector3(0, 0, 90);
        parent6.position += new Vector3(-_mazeSize * 0.5f, -_mazeSize * 0.4f, 0);
        parent6.eulerAngles += new Vector3(0, 0, 90);
    }

    private void Draw(WallState[,] maze, Transform parent)
    {
        for (int i = 0; i < _mazeSize; ++i)
        {
            for (int j = 0; j < _mazeSize; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-_mazeSize / 2 + i, 0, -_mazeSize / 2 + j);

                if (cell.HasFlag(WallState.UP) && j != _mazeSize - 1)
                {
                    var topWall = Instantiate(_wallPrefab, parent) as Transform;
                    topWall.position = position + new Vector3(0, 0, _size / 2);
                    topWall.localScale = new Vector3(_size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT) && i != 0)
                {
                    var leftWall = Instantiate(_wallPrefab, parent) as Transform;
                    leftWall.position = position + new Vector3(-_size / 2, 0, 0);
                    leftWall.localScale = new Vector3(_size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (cell.HasFlag(WallState.RIGHT) && i != _mazeSize - 1)
                {
                    var rightWall = Instantiate(_wallPrefab, parent) as Transform;
                    rightWall.position = position + new Vector3(+_size / 2, 0, 0);
                    rightWall.localScale = new Vector3(_size, rightWall.localScale.y, rightWall.localScale.z);
                    rightWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (cell.HasFlag(WallState.DOWN) && j != 0)
                {
                    var bottomWall = Instantiate(_wallPrefab, parent) as Transform;
                    bottomWall.position = position + new Vector3(0, 0, -_size / 2);
                    bottomWall.localScale = new Vector3(_size, bottomWall.localScale.y, bottomWall.localScale.z);
                }
            }

        }

    }
}
