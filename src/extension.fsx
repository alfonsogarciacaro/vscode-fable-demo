#r "../node_modules/fable-core/Fable.Core.dll"
#load "../node_modules/fable-import-vscode/Fable.Import.VSCode.fs"
 
open Fable.Core
open Fable.Import
open Fable.Import.vscode
    
let pollingF () =
  window.showInformationMessage "Hello from polling!"
  |> ignore

let helloWorld () =
    let rec infiniteHello() =
        async {
            do! Async.Sleep 3000
            pollingF()
            return! infiniteHello()
        }
    infiniteHello() |> Async.StartAsPromise

let activate (ctx: vscode.ExtensionContext) =
    commands.registerCommand("extension.sayHello", fun _ -> helloWorld() |> unbox)
    |> ctx.subscriptions.Add    