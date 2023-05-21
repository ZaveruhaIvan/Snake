using GameServices;
using GameServices.Assets;
using UnityEngine;

public class Project : MonoBehaviour
{
    public static Project Instance { get; private set; }

    public IServices Services { get; private set; }
    [SerializeField] private Assets _assets;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Services = new Services(_assets);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}