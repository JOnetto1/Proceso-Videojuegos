using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapController : MonoBehaviour
{
    public static MapController instance;

    public int activeLevel = 0;
    public List<GameObject> levels;
    public GameObject player;

    public void TravelToPortal(Portal portal)
    {
        if(portal.OriginScene < 0)
        {
            Debug.LogError("ERROR: Portal no tiene escena linkeada -> " + portal.OriginScene);
            return;
        }

        portal.isOnCoolDown = true;
        if(portal.OriginScene != activeLevel)
        {
            activeLevel = portal.OriginScene;
        }
        player.transform.position = portal.transform.position;
    }
    private Portal FindRandomUnlinkedPortal(int levelId)
    {
        Debug.Log("Finding Portal for level " + levelId);
        GameObject level = levels[levelId];
        List<Portal> levelPortals = new List<Portal>(level.GetComponentsInChildren<Portal>());
        Debug.Log("Found " + levelPortals.Count + " portals.");
        List<Portal> unLinkedScenePortals = (from portal in levelPortals where portal.isLinked == false select portal).ToList();
        Debug.Log("Found " + unLinkedScenePortals.Count + " unlinked portals.");
        return unLinkedScenePortals[Random.Range(0, unLinkedScenePortals.Count)];
    }
    private void CoordinatePortals()
    {
        // linkea escena al azar con inicio y con fin
        Portal startLevelPortal = FindRandomUnlinkedPortal(0);
        int nextLevelId = Random.Range(1, levels.Count - 1);
        Portal nextToStartPortal = FindRandomUnlinkedPortal(nextLevelId);
        Portal.LinkPortals(startLevelPortal, nextToStartPortal);

        Portal finalLevelPortal = FindRandomUnlinkedPortal(levels.Count - 1);
        int prevLevelId = Random.Range(1, levels.Count - 1);
        while (prevLevelId == nextLevelId)
        {
            prevLevelId = Random.Range(1, levels.Count - 1);
        }
        Portal prevToFinalPortal = FindRandomUnlinkedPortal(prevLevelId);
        Portal.LinkPortals(finalLevelPortal, prevToFinalPortal);


        // linkea todas las escenas intermediarias entre si
        for (int i = 1; i < levels.Count - 2; i++)
        {
            for(int j = i + 1; j < levels.Count - 1; j++)
            {
                Debug.Log("Linking "+ i + " and " + j);
                Portal portalToLinkFrom = FindRandomUnlinkedPortal(i);
                Portal portalToLinkTo = FindRandomUnlinkedPortal(j);

                Portal.LinkPortals(portalToLinkFrom, portalToLinkTo);
            }
        }
    }

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this);
        }

        //DontDestroyOnLoad(this.gameObject);
        CoordinatePortals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("RipScene");
    }
}
