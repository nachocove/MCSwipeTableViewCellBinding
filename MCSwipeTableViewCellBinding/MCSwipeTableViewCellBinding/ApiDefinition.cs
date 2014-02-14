using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;

namespace MCSwipeTableViewCellBinding
{
    public delegate void MCSwipeCompletionBlock (MCSwipeTableViewCell cell, MCSwipeTableViewCellState state, MCSwipeTableViewCellMode mode);
    public delegate void SwipeToOriginCompletion ();
    [BaseType (typeof(UITableViewCell))]
    public partial interface MCSwipeTableViewCell
    {
        [Export("initWithStyle:reuseIdentifier:")]
        IntPtr Constructor (UITableViewCellStyle style, string reuseIndentifier);

        [Export ("delegate", ArgumentSemantic.Assign)]
        MCSwipeTableViewCellDelegate Delegate { get; set; }

        [Export ("damping")]
        float Damping { get; set; }

        [Export ("velocity")]
        float Velocity { get; set; }

        [Export ("animationDuration")]
        double AnimationDuration { get; set; }

        [Export ("defaultColor", ArgumentSemantic.Retain)]
        UIColor DefaultColor { get; set; }

        [Export ("color1", ArgumentSemantic.Retain)]
        UIColor Color1 { get; set; }

        [Export ("color2", ArgumentSemantic.Retain)]
        UIColor Color2 { get; set; }

        [Export ("color3", ArgumentSemantic.Retain)]
        UIColor Color3 { get; set; }

        [Export ("color4", ArgumentSemantic.Retain)]
        UIColor Color4 { get; set; }

        [Export ("view1", ArgumentSemantic.Retain)]
        UIView View1 { get; set; }

        [Export ("view2", ArgumentSemantic.Retain)]
        UIView View2 { get; set; }

        [Export ("view3", ArgumentSemantic.Retain)]
        UIView View3 { get; set; }

        [Export ("view4", ArgumentSemantic.Retain)]
        UIView View4 { get; set; }

        [Export ("completionBlock1", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock1 { get; set; }

        [Export ("completionBlock2", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock2 { get; set; }

        [Export ("completionBlock3", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock3 { get; set; }

        [Export ("completionBlock4", ArgumentSemantic.Copy)]
        MCSwipeCompletionBlock CompletionBlock4 { get; set; }

        [Export ("firstTrigger")]
        float FirstTrigger { get; set; }

        [Export ("secondTrigger")]
        float SecondTrigger { get; set; }

        [Export ("modeForState1")]
        MCSwipeTableViewCellMode ModeForState1 { get; set; }

        [Export ("modeForState2")]
        MCSwipeTableViewCellMode ModeForState2 { get; set; }

        [Export ("modeForState3")]
        MCSwipeTableViewCellMode ModeForState3 { get; set; }

        [Export ("modeForState4")]
        MCSwipeTableViewCellMode ModeForState4 { get; set; }

        [Export ("isDragging")]
        bool IsDragging { get; }

        [Export ("shouldDrag")]
        bool ShouldDrag { get; set; }

        [Export ("shouldAnimateIcons")]
        bool ShouldAnimateIcons { get; set; }

        [Export ("setSwipeGestureWithView:color:mode:state:completionBlock:")]
        void SetSwipeGestureWithView (UIView view, UIColor color, MCSwipeTableViewCellMode mode, MCSwipeTableViewCellState state, MCSwipeCompletionBlock completionBlock);

        [Export ("swipeToOriginWithCompletion:")]
        void SwipeToOriginWithCompletion (SwipeToOriginCompletion completion);
    }

    [Model, BaseType (typeof(NSObject))]
    public partial interface MCSwipeTableViewCellDelegate
    {
        [Export ("swipeTableViewCellDidStartSwiping:")]
        void  SwipeTableViewCellDidStartSwiping (MCSwipeTableViewCell cell);

        [Export ("swipeTableViewCellDidEndSwiping:")]
        void  SwipeTableViewCellDidEndSwiping (MCSwipeTableViewCell cell);

        [Export ("swipeTableViewCell:didSwipeWithPercentage:")]
        void DidSwipeWithPercentage (MCSwipeTableViewCell cell, float percentage);
    }
}
