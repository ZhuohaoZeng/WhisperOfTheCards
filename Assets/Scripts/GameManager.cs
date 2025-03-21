using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private int playerHealth;

    public OptionsManager OptionsManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public DeckManager DeckManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void InitializeManagers()
    {
        //get existing managers
        OptionsManager = GetComponentInChildren<OptionsManager>();
        AudioManager = GetComponentInChildren<AudioManager>();
        DeckManager = GetComponentInChildren<DeckManager>();

        //if they don't exist, create them
        if (OptionsManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/OptionsManager");
            if (prefab == null) { Debug.Log("OptionsManager Prefab not found"); }
            else { 
                Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
                OptionsManager = GetComponentInChildren<OptionsManager>();
            }
        
        }
        if (AudioManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/AudioManager");
            if (prefab == null) { Debug.Log("AudioManager Prefab not found"); }
            else
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
                AudioManager = GetComponentInChildren<AudioManager>();
            }

        }
        if (DeckManager == null)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/DeckManager");
            if (prefab == null) { Debug.Log("DeckManager Prefab not found"); }
            else
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
                DeckManager = GetComponentInChildren<DeckManager>();
            }

        }
        OptionsManager.AudioManager = AudioManager;
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }
}
