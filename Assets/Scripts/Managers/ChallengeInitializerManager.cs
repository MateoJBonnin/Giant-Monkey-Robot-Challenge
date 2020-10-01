using UnityEngine;

public class ChallengeInitializerManager : MonoBehaviour
{
    [SerializeField]
    private ChallengeContentView challengeContentPrefab;
    [SerializeField]
    private Transform canvasContainer;

    private ChallengeContentArranger challengeContentArranger;
    private ChallengeContentView challengeContent;

    /// <summary>
    /// Uses the Start method to trigger the challenge.
    /// </summary>
    void Start()
    {
        this.DisplayChallenge();
    }

    /// <summary>
    /// Initializes and displays the challenge.
    /// </summary>
    private void DisplayChallenge()
    {
        //Instantiates the challenge view.
        challengeContent = GameObject.Instantiate(challengeContentPrefab, canvasContainer);

        string jsonLocationPath = Application.streamingAssetsPath + "/JsonChallenge.json";

        //Creates a JSON defined model for the Challenge.
        JSONDataGathererChallengeContentModel challengeModel = new JSONDataGathererChallengeContentModel(jsonLocationPath);

        //Finally, cretes the controller for this MVC structure.
        challengeContentArranger = new ChallengeContentArranger(challengeModel, challengeContent);
        challengeContentArranger.InitChallengeContent();
    }
}