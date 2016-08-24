namespace FRP.Core

module Core =
    let always x = fun _ -> x
 
    let addStream updateUi event = 
        event
            |> Observable.map (always 1)
            |> Observable.scan (+) 0
            |> Observable.subscribe updateUi
            |> ignore