namespace FRP.Droid

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open FRP.Core

[<Activity (Label = "FRP.Droid", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)
        this.SetContentView (Resource_Layout.Main)
        let button = this.FindViewById<Button>(Resource_Id.myButton)

        let updateUi count = 
            button.Text <- sprintf "%d clicks!" count

        do Core.addStream updateUi button.Click

