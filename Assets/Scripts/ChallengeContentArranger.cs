/// <summary>
/// Since the Challenge was to gather data and to display it it seemed to me that it was great for a MVC design pattern to be used, so this is the Controller.
/// In charge of displaying the correct data whenever necessary.
/// </summary>
public class ChallengeContentArranger : BaseController<ChallengeContentView, IChallengeContentModel>
{
    public ChallengeContentArranger(IChallengeContentModel model, ChallengeContentView view) : base(model, view)
    {
    }

    public void InitChallengeContent()
    {
        View.BindHooks();
        View.OnRefreshRequested += LoadAndDisplay;
        LoadAndDisplay();
    }

    /// <summary>
    /// Loads the data and display it through the view.
    /// </summary>
    private void LoadAndDisplay()
    {
        if (LoadModelData())
        {
            InitView();
        }
        else
        {
            DisplayFailedLoading();
        }
    }

    /// <summary>
    /// Refreshes the data.
    /// </summary>
    private bool LoadModelData()
    {
        return Model.RefreshData();
    }

    /// <summary>
    /// Initializes the view, it will show the data to the user.
    /// </summary>
    private void InitView()
    {
        ChallengeData challengeData = Model.ChallengeData;
        View.SetupContentView(challengeData.Title, challengeData.ColumnHeaders, challengeData.Data);
    }

    /// <summary>
    /// In case the data was not loaded correctly display a message to the user.
    /// </summary>
    private void DisplayFailedLoading()
    {
        View.DisplayFailedLoadingData();
    }
}