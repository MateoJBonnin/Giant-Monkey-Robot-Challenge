using System;
using System.Collections.Generic;

/// <summary>
/// Data structure used by the JSON.
/// </summary>
[Serializable]
public class ChallengeDataObject
{
    public List<Dictionary<string, string>> Data { get; }
    public List<string> ColumnHeaders { get; }
    public string Title { get; }

    public ChallengeDataObject(List<Dictionary<string, string>> data, List<string> columnHeaders, string title)
    {
        Data = data;
        ColumnHeaders = columnHeaders;
        Title = title;
    }
}

/// <summary>
/// Data structured used by the challenge.
/// </summary>
public class ChallengeData
{
    public List<List<string>> Data { get; }
    public List<string> ColumnHeaders { get; }
    public string Title { get; }

    public ChallengeData(List<List<string>> data, List<string> columnHeaders, string title)
    {
        Data = data;
        ColumnHeaders = columnHeaders;
        Title = title;
    }
}