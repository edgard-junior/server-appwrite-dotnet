using System;

public class ApiKeys
{
    private readonly string  endPoint = "http://127.0.0.1:8080/v1"; //Your api endpoint
    public string EndPoint
    {
        get { return endPoint; }
    }

    private readonly string project = "API_APPWRITE"; //Your project id
    public string Project
    {
        get { return project; }
    }

    private readonly string apiKey = "screctKey"; //Your secret key project
    public string ApiKey
    {
        get { return apiKey; }
    }

}