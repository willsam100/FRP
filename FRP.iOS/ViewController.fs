namespace FRP.iOS

open System
open Foundation
open UIKit
open FRP.Core

[<Register ("ViewController")>]
type ViewController (handle:IntPtr) as this =
    inherit UIViewController (handle)

    override x.ViewDidLoad () =
        base.ViewDidLoad ()

        let button = UIButton.FromType(UIButtonType.RoundedRect)
        button.Frame <- CoreGraphics.CGRect(nfloat(0.), nfloat(0.), this.View.Frame.Width, this.View.Frame.Height)
        this.View.AddSubview button

        let updateUi count = button.SetTitle (sprintf "%d clicks!" count, UIControlState.Normal)

        do Core.addStream updateUi button.TouchUpInside