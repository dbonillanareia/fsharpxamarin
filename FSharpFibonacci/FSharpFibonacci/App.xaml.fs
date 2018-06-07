namespace FSharpFibonacci

open Xamarin.Forms
open Elmish.XamarinForms  
open Elmish.XamarinForms.StaticViews

//inmutable
type Model =  
    {
        n : int
        fn: int
    }

type Msg =  
    | Calculate
    | Setn of string

type App() =
    inherit Application()

    let init () = 
        { 
            n = 0
            fn = 0
        }  

    // Fibonacci's function
    let rec fib n =
        match n with
        | 0 | 1 -> 1
        | n -> fib(n-1) + fib(n-2)

    let update msg model =
            match msg with
            | Calculate -> 
                { 
                    //new copy of model
                    fn = fib model.n
                    n = model.n
                }
            | Setn n -> { model with n = n |> int }

    let view () =  
        MainPage(),
        [ "fn" |> Binding.oneWay (fun m -> m.fn.ToString())
          "Calculate" |> Binding.msg Calculate
          "n" |> Binding.twoWay (fun m -> string m.n) (fun v -> Setn (string (v)))
        ]

    let runner =  
        Program.mkSimple init update view
        |> Program.withStaticView
        |> Program.run

    do base.MainPage <- runner.InitialMainPage