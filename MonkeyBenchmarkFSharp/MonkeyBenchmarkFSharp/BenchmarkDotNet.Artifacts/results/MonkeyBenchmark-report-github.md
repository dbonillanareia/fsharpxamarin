``` ini

BenchmarkDotNet=v0.10.14, OS=macOS High Sierra 10.13.5 (17F77) [Darwin 17.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.4
  [Host]   : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT DEBUG  [AttachedDebugger]
  QuickJob : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT
  ShortRun : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT

LaunchCount=1  WarmupCount=3  

```
|      Method |      Job | InvocationCount | TargetCount | UnrollFactor |     N |           Mean |           Error |         StdDev | Rank |
|------------ |--------- |---------------- |------------ |------------- |------ |---------------:|----------------:|---------------:|-----:|
| **AddMonkeyss** | **QuickJob** |             **100** |           **5** |            **1** |   **100** |      **10.305 us** |       **8.4861 us** |      **2.2042 us** |    **2** |
|  AddMonkeys | QuickJob |             100 |           5 |            1 |   100 |      11.177 us |       5.8730 us |      1.5255 us |    2 |
|  GetMonkeys | QuickJob |             100 |           5 |            1 |   100 | 345,435.276 us |  51,604.7188 us | 13,404.1337 us |    4 |
| AddMonkeyss | ShortRun |               1 |           3 |           16 |   100 |       6.790 us |       0.1384 us |      0.0078 us |    1 |
|  AddMonkeys | ShortRun |               1 |           3 |           16 |   100 |      25.923 us |     236.4523 us |     13.3600 us |    2 |
|  GetMonkeys | ShortRun |               1 |           3 |           16 |   100 | 358,079.757 us | 590,123.7522 us | 33,343.0863 us |    4 |
| **AddMonkeyss** | **QuickJob** |             **100** |           **5** |            **1** | **10000** |   **1,920.307 us** |     **815.4627 us** |    **211.8134 us** |    **3** |
|  AddMonkeys | QuickJob |             100 |           5 |            1 | 10000 |   2,149.856 us |   1,237.5691 us |    321.4540 us |    3 |
|  GetMonkeys | QuickJob |             100 |           5 |            1 | 10000 | 342,773.659 us |  74,075.1772 us | 19,240.7517 us |    4 |
| AddMonkeyss | ShortRun |               1 |           3 |           16 | 10000 |   1,810.704 us |      90.9701 us |      5.1400 us |    3 |
|  AddMonkeys | ShortRun |               1 |           3 |           16 | 10000 |   2,969.151 us |  26,416.0867 us |  1,492.5579 us |    3 |
|  GetMonkeys | ShortRun |               1 |           3 |           16 | 10000 | 367,372.417 us | 732,894.9807 us | 41,409.9255 us |    4 |
