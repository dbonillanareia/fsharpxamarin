``` ini

BenchmarkDotNet=v0.10.14, OS=macOS High Sierra 10.13.5 (17F77) [Darwin 17.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.4
  [Host]   : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT  [AttachedDebugger]
  QuickJob : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT
  ShortRun : .NET Core 2.0.5 (CoreCLR 4.6.0.0, CoreFX 4.6.26018.01), 64bit RyuJIT

LaunchCount=1  WarmupCount=3  

```
|     Method |      Job | InvocationCount | TargetCount | UnrollFactor |     N |          Mean |            Error |         StdDev | Rank |
|----------- |--------- |---------------- |------------ |------------- |------ |--------------:|-----------------:|---------------:|-----:|
| **AddMonkeys** | **QuickJob** |             **100** |           **5** |            **1** |   **100** |      **10.91 us** |         **5.244 us** |       **1.362 us** |    **1** |
| GetMonkeys | QuickJob |             100 |           5 |            1 |   100 | 321,640.10 us |    91,716.109 us |  23,822.918 us |    4 |
|  GetPhotos | QuickJob |             100 |           5 |            1 |   100 | 579,239.05 us |   542,718.844 us | 140,969.201 us |    4 |
| AddMonkeys | ShortRun |               1 |           3 |           16 |   100 |      19.23 us |        58.374 us |       3.298 us |    2 |
| GetMonkeys | ShortRun |               1 |           3 |           16 |   100 | 354,784.11 us |   748,577.608 us |  42,296.023 us |    4 |
|  GetPhotos | ShortRun |               1 |           3 |           16 |   100 | 840,010.85 us | 3,664,670.127 us | 207,060.658 us |    4 |
| **AddMonkeys** | **QuickJob** |             **100** |           **5** |            **1** | **10000** |   **1,812.08 us** |       **725.369 us** |     **188.412 us** |    **3** |
| GetMonkeys | QuickJob |             100 |           5 |            1 | 10000 | 307,174.99 us |   122,132.695 us |  31,723.513 us |    4 |
|  GetPhotos | QuickJob |             100 |           5 |            1 | 10000 | 411,911.99 us |   444,600.422 us | 115,483.306 us |    4 |
| AddMonkeys | ShortRun |               1 |           3 |           16 | 10000 |   2,008.46 us |     1,626.831 us |      91.919 us |    3 |
| GetMonkeys | ShortRun |               1 |           3 |           16 | 10000 | 364,112.30 us |   513,435.842 us |  29,010.077 us |    4 |
|  GetPhotos | ShortRun |               1 |           3 |           16 | 10000 | 496,539.04 us | 1,860,780.224 us | 105,137.533 us |    4 |
