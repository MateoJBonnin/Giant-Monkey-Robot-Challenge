using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Will gather the necessary data to feed the Challenge from a JSON File.
/// </summary>
public class JSONDataGathererChallengeContentModel : IChallengeContentModel
{
    public ChallengeData ChallengeData
    {
        get
        {
            return challengeData;
        }
    }

    private ChallengeDataObject jsonChallengeData;
    private ChallengeData challengeData;
    private string jsonLocationPath;

    /// <summary>
    /// Sets the location of the json.
    /// </summary>
    /// <param name="jsonLocationPath">Json location</param>
    public JSONDataGathererChallengeContentModel(string jsonLocationPath)
    {
        this.jsonLocationPath = jsonLocationPath;
    }

    /// <summary>
    /// Searches for the JSON and loads the data.
    /// </summary>
    public bool RefreshData()
    {
        try
        {
            string json = LoadJSONFromPath(this.jsonLocationPath);
            DeserializeData(json);
            ValidateData(jsonChallengeData);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Creates the data object from a JSON.
    /// </summary>
    /// <param name="json">JSON to deserialize</param>
    private void DeserializeData(string json)
    {
        jsonChallengeData = JsonConvert.DeserializeObject<ChallengeDataObject>(json);
    }

    /// <summary>
    /// Goes through the data object to check if there's something that needs to be addressed before being used by the view.
    /// </summary>
    /// <param name="challengeDataObject"></param>
    private void ValidateData(ChallengeDataObject challengeDataObject)
    {
        List<List<string>> userData = new List<List<string>>();

        for (int i = 0; i < challengeDataObject.Data.Count; i++)
        {
            List<string> finalUserData = new List<string>();
            //In case there's a missing header for the data we include a default one so the view wont be corrupted.
            //Used to also order the data based on the header paremeters.
            for (int j = 0; j < challengeDataObject.ColumnHeaders.Count; j++)
            {
                string header = challengeDataObject.ColumnHeaders[j];
                finalUserData.Add(challengeDataObject.Data[i].ContainsKey(header) ? challengeDataObject.Data[i][header] : "");
            }

            userData.Add(finalUserData);
        }

        challengeData = new ChallengeData(userData, challengeDataObject.ColumnHeaders, challengeDataObject.Title);
    }

    /// <summary>
    /// Tries to load the json from the path.
    /// </summary>
    /// <param name="path">Location of the JSON</param>
    /// <returns></returns>
    private string LoadJSONFromPath(string path)
    {
        //Gathers the data from a JSON located in the Streaming Assets folder.
        StreamReader streamReader = new StreamReader(path);
        string jsonData = streamReader.ReadToEnd();

        return jsonData;
    }
}