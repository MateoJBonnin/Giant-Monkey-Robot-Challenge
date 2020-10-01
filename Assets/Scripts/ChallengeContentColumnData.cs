using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Encapsulates the columns data.
/// </summary>
public class ChallengeContentColumnData : MonoBehaviour
{
    private List<TextContent> cachedContent = new List<TextContent>();

    /// <summary>
    /// Displays certain content.
    /// </summary>
    /// <param name="textContentPrefab">Whether to use the bold or the common text content prefab</param>
    /// <param name="content">The data to be displayed in the column</param>
    public void SetupContentData(TextContent textContentPrefab, List<string> content)
    {
        //Hides the old data from the user if there was any.
        this.Clear();

        //Concretely displays the content to the user.
        for (int i = 0; i < content.Count; i++)
        {
            TextContent contentText = GameObject.Instantiate(textContentPrefab, transform);
            contentText.SetupHeader(content[i]);
            cachedContent.Add(contentText);
        }
    }

    /// <summary>
    /// Clears the data if any.
    /// </summary>
    public void Clear()
    {
        for (int i = cachedContent.Count - 1; i >= 0; i--)
        {
            Destroy(cachedContent[i].gameObject);
        }

        cachedContent.Clear();
    }
}