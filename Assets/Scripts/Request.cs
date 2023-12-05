using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Bson.Serialization.Attributes;

public class Request : MonoBehaviour {

    private string serverUrl = "http://localhost/ucm/planet_of_the_aliens/index.php?page=";
    private string postData = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
    
    public string GetUrl(string page) {
        return serverUrl + page;
    }

    private Dictionary<string, string> parameters = new Dictionary<string, string> {
        { "idPlayer", "1" },
        { "nickname", "holes" },
        { "password", "12345678" }
    };

    private string GetUrlWithParams(string url, Dictionary<string, string> parameters) {
        foreach (var param in parameters) {
            url += $"&{param.Key}={UnityWebRequest.EscapeURL(param.Value)}";
        }

        return url;
    }

    public IEnumerator Post(
        string page,
        WWWForm form,
        System.Action<string> successCallback,
        System.Action<string> errorCallback
    ) {
        //string postData = GetUrlWithParams("", parameters).Remove(0, 1);
        //Debug.Log("POST" + postData);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(GetUrl(page), form)) {
            webRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                errorCallback?.Invoke(webRequest.downloadHandler.text);
            } else {
                successCallback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator Get(
        string page,
        Dictionary<string, string>? parameters,
        System.Action<string> successCallback,
        System.Action<string> errorCallback
    ) {
        //var url = GetUrlWithParams(GetUrl(page), parameters);
        var url = GetUrl(page);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) {

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                errorCallback?.Invoke(webRequest.downloadHandler.text);
            } else {
                successCallback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    //public void Start() {
    //    IMongoCollection<BsonDocument> collection;
    //    MongoClient client = new MongoClient(new MongoUrl("mongodb://localhost"));
    //    IMongoDatabase db = client.GetDatabase("holes");

    //    collection = db.GetCollection<BsonDocument>("players");
    //    //var server = client.GetServer();
    //
    //    //Debug.Log("xxx");
    //    //Debug.Log(collection);

    //   findDocuments(collection);

    //    IMongoCollection<PlayerX> playerCollection = db.GetCollection<PlayerX>("players");
    //    //var filter = Builders<PlayerX>.Filter.Empty;

    //    List<PlayerX> players = playerCollection.Find(player => true).ToList();
    //    PlayerX[] playersArray = players.ToArray();
    //    //var players = playerCollection.Find(filter).ToList();

    //    foreach (var player in playersArray) {
    //        Debug.Log(player);
    //    }


    //    //Model_User e = new Model_User();
    //    //e.name = "hope";
    //    //userCollection.InsertOne(e);
    //    //List<Model_User> userModelList = userCollection.Find(user => true).ToList();
    //    //Model_User[] userAsap= userModelList.ToArray();
    //    //foreach(Model_User asap in userAsap)
    //    //{
    //    //    print(asap.name);
    //    //}
    //}

    ////private void InsertDocument() {
    ////    var document = new BsonDocument {
    ////        { "key1", "value1" },
    ////        { "key2", "value2" }
    ////    };

    ////    collection.InsertOne(document);
    ////}

    //private void findDocuments(IMongoCollection<BsonDocument> collection) {
    //    var filter = new BsonDocument();
    //    var documents = collection.Find(filter).ToList();

    //    foreach (var document in documents)
    //    {
    //        Debug.Log(document);
    //    }
    //}
}
