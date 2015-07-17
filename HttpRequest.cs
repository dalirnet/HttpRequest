static class HttpRequest
    {
        public static IDictionary<string, string> PostItem = new Dictionary<string, string>();
        public static string ResponseString;
        public static dynamic Json;

        public static void Post(string Url, bool JsonOut = false)
        {
            List<string> PostArray = new List<string>();
            foreach(KeyValuePair<string, string> Item in PostItem)
            {
                PostArray.Add(Item.Key + "=" + Item.Value);
            }
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(@Url);
            var PostData = Encoding.ASCII.GetBytes(string.Join("&",PostArray.ToArray()));
            Request.Method = "POST";
            Request.ContentType = "application/x-www-form-urlencoded";
            Request.ContentLength = PostData.Length;
            using(var Stream = Request.GetRequestStream())
            {
                Stream.Write(PostData, 0, PostData.Length);
            }
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            ResponseString = new StreamReader(Response.GetResponseStream()).ReadToEnd();
            if (JsonOut == true)
            {
                Parse(ResponseString);
            }
        }

        public static void Get(string Url,bool JsonOut = false)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(@Url);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            ResponseString = new StreamReader(Response.GetResponseStream()).ReadToEnd();
            if(JsonOut == true)
            {
                Parse(ResponseString);
            }
        }

        public static void Parse(string JsonInput)
        {
            Json = JsonConvert.DeserializeObject(JsonInput);
        }

    }
