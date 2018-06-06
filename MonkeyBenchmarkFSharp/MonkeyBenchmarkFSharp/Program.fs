open BenchmarkDotNet.Running
open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Attributes;
open BenchmarkDotNet.Attributes.Columns
open BenchmarkDotNet.Attributes.Exporters
open BenchmarkDotNet.Attributes.Jobs
open System.Collections.Generic
open System.Net.Http
open Newtonsoft.Json

type Monkey = {
    Name: string
    Avatar: string
}

[<SimpleJob (1, 3, 5, 100, "QuickJob")>]
[<ShortRunJob>]
[<RPlotExporter>]
[<RankColumn>]
type MonkeyBenchmark() =
    let mutable monkeyss : Monkey list = []
    let monkeys = new List<Monkey>()

    [<Params (100, 10000)>]
    member val public N = 0 with get, set

    [<Benchmark>]
    member this.AddMonkeyss() =
        let rec loop theMonkeys max current =
            if current > max then
                theMonkeys
            else
                let monkey = {
                    Name = current.ToString()
                    Avatar = "https://i.imgur.com/c9FK01J.png"
                }

                loop (monkey::theMonkeys) max (current+1)

        monkeyss <- loop [] this.N 1

    [<Benchmark>]
    member this.AddMonkeys() =

        for i = 1 to this.N do
            let monkey = {
                Name = i.ToString()
                Avatar = "https://i.imgur.com/c9FK01J.png"
            }

            monkeys.Add(monkey)


    [<Benchmark>]
    member this.GetMonkeys() =

        let doJsonStuff = async { 
                let client = new HttpClient()
                let! json = client.GetStringAsync("https://my-json-server.typicode.com/dbonillanareia/fsharpxamarin/monkeys")                         
                                |> Async.AwaitTask                                                     

                let items = JsonConvert.DeserializeObject<Monkey list>(json)

                for item in items do monkeys.Add(item)
            }

        doJsonStuff |> Async.RunSynchronously  

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<MonkeyBenchmark>() 
        |> ignore
    0
