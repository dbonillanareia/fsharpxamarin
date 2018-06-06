using System;
using System.Collections.Generic;
using System.Net.Http;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using Newtonsoft.Json;

namespace MonkeyBenchmarkCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<MonkeyBenchmark>();
        }
    }

    //[MonoJob]
    [SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: 100, id: "QuickJob")]
    [ShortRunJob]
    [RPlotExporter, RankColumn]
    public class MonkeyBenchmark
    {
        private List<Monkey> monkeys;
        private List<Photo> photos;

        [Params(100, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            monkeys = new List<Monkey>(N);
            photos = new List<Photo>(N);
        }

        [Benchmark]
        public void AddMonkeys()
        {
            for (int i = 1; i <= N; i++)
            {
                var monkey = new Monkey
                {
                    Name = i.ToString(),
                    Avatar = "https://i.imgur.com/c9FK01J.png",
                };

                monkeys.Add(monkey);
            }
        }

        [Benchmark]
        public void GetMonkeys()
        {
            var client = new HttpClient();
            try
            {
                //30 monkeys
                var json = client.GetStringAsync("https://my-json-server.typicode.com/dbonillanareia/fsharpxamarin/monkeys").Result;

                var items = JsonConvert.DeserializeObject<List<Monkey>>(json);

                foreach (var item in items)
                    monkeys.Add(item);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!!!!!!!!! " + ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }

        [Benchmark]
        public void GetPhotos()
        {
            var client = new HttpClient();
            try
            {
                //5000 photos
                var json = client.GetStringAsync("https://jsonplaceholder.typicode.com/photos").Result;

                var items = JsonConvert.DeserializeObject<List<Photo>>(json);

                foreach (var item in items)
                    photos.Add(item);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!!!!!!!!! " + ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }
    }

    public class Monkey
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }

    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
