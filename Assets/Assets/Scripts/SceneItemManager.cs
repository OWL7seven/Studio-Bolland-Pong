using UnityEngine;

public class SceneItemManager : MonoBehaviour
{
    public static SceneItemManager Instance { get; private set; }

    public WallController leftWall;
    public WallController rightWall;
    public WallController topWall;
    public WallController bottomWall;

    public GameObject players;

    void Awake()
    {
        Instance = this;
    }
}
