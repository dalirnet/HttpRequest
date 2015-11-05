# HttpRequest
Easy Http Request In C#

```c#
HttpRequest.PostItem["name"] = "amir";
HttpRequest.PostItem["code"] = "90";
HttpRequest.Post("http://x.x.x.x/file.php");
Console.WriteLine(HttpRequest.ResponseString);
//
HttpRequest.Get("http://x.x.x.x/file.php",true);
Console.WriteLine(HttpRequest.Json.status_message);
```
