open System.Net
open System
open System.IO

let fetchUrl callback url = 
    let req = WebRequest.Create(Uri(url))
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url


let myCallback (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()
    let first1000 = html.Substring(0, 1000)
    printfn "Downloaded %s. First 1000 is \r\n %s" 
        <| url 
        <| first1000

let google = fetchUrl myCallback "http://google.com"
