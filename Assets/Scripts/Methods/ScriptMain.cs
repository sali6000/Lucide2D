using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMain : MonoBehaviour 
{
    // GAMEOBJETCS (2) ET SCRIPTS (6)
	private GameObject[] Bots {get; set;}
	private GameObject Human {get; set;}
	private ScriptShowDialogue InterfaceDialogue {get; set;}
	private ScriptParler[] BotsDialogues { get; set;}
	private ScriptTrigger[] BotsTriggers {get; set;}
	private ScriptDeplacementAutomatique[] BotsDeplacements {get; set;}
	private ScriptDeplacementSupervise HumanDeplacement {get; set;}
	private ScriptPnjProperties[] BotsProperties {get; set;}
	private ScriptPnjProperties HumanPropertie {get; set;}
	private int i;
    private int j;
    private int frames;
    

    void Start()
	{
        // INITIALIZATION (4) (au démarrage)
        InitializationDesVariablesUtilitaires();
        InitializationDesInterfaces();
        InitializationDuJoueur();
        InitializationDesBots();
	}
    void Update()
	{
            // EVENTS (5) (à chaque framerate)
            frames++;
            FaireParlerLesBots();
            FaireBougerLesBots();
            HumanDeplacement.Deplacer(InterfaceDialogue, HumanPropertie);
	}

	// METHODES UPDATE
    /// <summary>
    /// Faire bouger les bots
    /// </summary>
	private void FaireBougerLesBots()
	{
		if(BotsDialogues != null)
		{
			i=0;
			foreach(GameObject bot in Bots)
			{
                j = UnityEditor.ArrayUtility.IndexOf(Bots, bot);
                if (!BotsDialogues[i].IsTalking)
				{
					BotsDeplacements[i].Deplacer(frames, BotsTriggers[j]);
				}
				i++;
			}
		}
	}
    /// <summary>
    /// Parler avec les bots
    /// </summary>
	private void FaireParlerLesBots()
	{
		// CONDITIONS
		if(Input.GetKeyDown(KeyCode.Space))
		{
			i = 0;
			foreach(GameObject bot in Bots)
			{
				i = UnityEditor.ArrayUtility.IndexOf(Bots,bot);

				if(BotsTriggers[i].IsOnTrigger)
				{
					 BotsDialogues[i].Parler(InterfaceDialogue);
				}
			}
		}
	}

    // METHODES START
    private void InitializationDesBots()
    {
            Bots = ScriptFactory.GetGameObjectsBot();
            BotsProperties = new ScriptPnjProperties[Bots.Length];
            BotsDialogues = new ScriptParler[Bots.Length];
            BotsTriggers = new ScriptTrigger[Bots.Length];
            BotsDeplacements = new ScriptDeplacementAutomatique[Bots.Length];

            foreach (GameObject bot in Bots)
            {
                Debug.Log("Chargement des bots...");

                BotsProperties[i] = ScriptFactory.GetScriptAttachedOnGO<ScriptPnjProperties>(bot);
                BotsDeplacements[i] = ScriptFactory.GetScriptAttachedOnGO<ScriptDeplacementAutomatique>(bot);
                BotsTriggers[i] = ScriptFactory.GetScriptTriggerInChildOf(bot);
                BotsDialogues[i] = ScriptFactory.GetScriptParler(bot);
                BotsDialogues[i].IsTalking = false;
                i++;
            }
    }
    private void InitializationDuJoueur()
    {
        Human = ScriptFactory.GetGameObjectHuman();
        HumanPropertie = ScriptFactory.GetScriptAttachedOnGO<ScriptPnjProperties>(Human);
        HumanDeplacement = ScriptFactory.GetScriptAttachedOnGO<ScriptDeplacementSupervise>(Human);
        HumanDeplacement.CanMove = true;
    }
    private void InitializationDesInterfaces()
    {
        InterfaceDialogue = ScriptFactory.GetScriptShowDialogue();
    }
    private void InitializationDesVariablesUtilitaires()
    {
        frames = 0;
        i = 0;
    }
}
