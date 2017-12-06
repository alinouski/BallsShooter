using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

	public static ScreenManager Instance
    {
        get { return m_instance; }
    }
    private static ScreenManager m_instance;

    public CoinsScreenController coins;
    public MainScreenController main;
    public GameScreenController game;
    public PauseScreenController pause;
    public GameOverScreenController gameOver;


    void Awake () {
		if(m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
