/// <summary>
/// Interface that will determine how to gather the Challenge Data.
/// </summary>
public interface IChallengeContentModel : IModel
{
    ChallengeData ChallengeData { get; }
    bool RefreshData();
}