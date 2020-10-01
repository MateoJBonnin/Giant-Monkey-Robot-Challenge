using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// In charge of displaying the Challenge data to the user.
/// </summary>
public class ChallengeContentView : BaseMBView
{
    public event Action OnRefreshRequested;

    [SerializeField]
    private ChallengeContentColumnData contentColumnsPrefab;
    [SerializeField]
    private TextContent contentHeaderPrefab;
    [SerializeField]
    private TextContent contentPrefab;
    [SerializeField]
    private VerticalLayoutGroup contentContainer;
    [SerializeField]
    private Button refreshButton;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text failedDataText;

    private List<ChallengeContentColumnData> cachedColumnContent = new List<ChallengeContentColumnData>();

    /// <summary>
    /// Setups the whole view, displays the challenge to the user.
    /// </summary>
    /// <param name="title">Shown title</param>
    /// <param name="headers">Shown highlited headers</param>
    /// <param name="data">Shown data</param>
    public void SetupContentView(string title, List<string> headers, List<List<string>> data)
    {
        //Clears old data in case there was any.
        ClearData();

        //Proceed to setup the rest of the challenge's view.
        SetupTitle(title);
        SetupHeaders(headers);
        SetupContentData(data);
    }

    /// <summary>
    /// Shows a message to the client in case the data was not correctly loaded
    /// </summary>
    public void DisplayFailedLoadingData()
    {
        //Clears old data in case there was any.
        ClearData();
        failedDataText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Binds the events, in this case the refresh button.
    /// </summary>
    public void BindHooks()
    {
        refreshButton.onClick.AddListener(OnRefreshButtonClicked);
    }

    //Safely notifies that the refresh button was clicked.
    private void OnRefreshButtonClicked()
    {
        OnRefreshRequested?.Invoke();
    }

    /// <summary>
    /// Clears old data from the view of the user. This could be handled better with a pool and factory design patterns.
    /// </summary>
    private void ClearData()
    {
        failedDataText.gameObject.SetActive(false);

        SetupTitle("");
        for (int i = cachedColumnContent.Count - 1; i >= 0; i--)
        {
            cachedColumnContent[i].Clear();
            Destroy(cachedColumnContent[i].gameObject);
        }

        cachedColumnContent.Clear();
    }

    /// <summary>
    /// Highlights the headers by using a special prefab that bolds the text.
    /// </summary>
    /// <param name="headers">Headers to highlight</param>
    private void SetupHeaders(List<string> headers)
    {
        ChallengeContentColumnData headerContentData = GameObject.Instantiate(contentColumnsPrefab, contentContainer.transform);
        headerContentData.SetupContentData(contentHeaderPrefab, headers);
        cachedColumnContent.Add(headerContentData);
    }

    /// <summary>
    /// Displays the content data without highlight.
    /// </summary>
    /// <param name="contentData">Data to display</param>
    private void SetupContentData(List<List<string>> contentData)
    {
        for (int i = 0; i < contentData.Count; i++)
        {
            ChallengeContentColumnData data = GameObject.Instantiate(contentColumnsPrefab, contentContainer.transform);
            data.SetupContentData(contentPrefab, contentData[i]);
            cachedColumnContent.Add(data);
        }
    }

    /// <summary>
    /// Sets the displayed title in the center of the challenge view.
    /// </summary>
    /// <param name="title">Displayed title</param>
    private void SetupTitle(string title)
    {
        titleText.text = title;
    }
}