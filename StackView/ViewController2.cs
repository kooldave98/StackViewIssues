using Foundation;
using UIKit;

namespace StackView
{

    //
    //  SimpleScrollingStack.swift
    //  A super-simple demo of a scrolling UIStackView in iOS 9
    //
    //  Created by Paul Hudson on 10/06/2015.
    //  Learn Swift at www.hackingwithswift.com
    //  @twostraws
    //

    public class ViewController2 : UIViewController
    {
        UIScrollView scrollView;
        UIStackView stackView;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            View.BackgroundColor = UIColor.White;

            scrollView = new UIScrollView ();
            scrollView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview (scrollView);

            View.AddConstraints (
                NSLayoutConstraint
                .FromVisualFormat (
                    "H:|[scrollView]|",
                    NSLayoutFormatOptions.AlignAllCenterX,
                    new NSDictionary (),
                    NSDictionary.FromObjectAndKey (scrollView, new NSString ("scrollView"))
                )
            );

            View.AddConstraints (
                NSLayoutConstraint
                .FromVisualFormat (
                    "V:|[scrollView]|",
                    NSLayoutFormatOptions.AlignAllCenterX,
                    new NSDictionary (),
                    NSDictionary.FromObjectAndKey (scrollView, new NSString ("scrollView"))
                )
            );

            stackView = new UIStackView ();
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.Axis = UILayoutConstraintAxis.Vertical;
            stackView.Alignment = UIStackViewAlignment.Center;
            scrollView.AddSubview (stackView);

            scrollView.AddConstraints (
                NSLayoutConstraint
                .FromVisualFormat (
                    "H:|[stackView]|",
                    NSLayoutFormatOptions.AlignAllCenterX,
                    new NSDictionary (),
                    NSDictionary.FromObjectAndKey (stackView, new NSString ("stackView"))
                )
            );

            scrollView.AddConstraints (
                NSLayoutConstraint
                .FromVisualFormat (
                    "V:|[stackView]|",
                    NSLayoutFormatOptions.AlignAllCenterX,
                    new NSDictionary (),
                    NSDictionary.FromObjectAndKey (stackView, new NSString ("stackView"))
                )
            );


            ////This below constraint solves the alignment issues, see http://stackoverflow.com/questions/38074366/programmatic-layout-uistackview-alignment-doesnt-seem-to-work
            //scrollView.AddConstraints (
            //    NSLayoutConstraint
            //    .FromVisualFormat (
            //        "H:[stackView(==scrollView)]",
            //        NSLayoutFormatOptions.AlignAllCenterX,
            //        new NSDictionary (),
            //        NSDictionary.FromObjectsAndKeys (new NSObject [] { stackView, scrollView }, new NSString [] { new NSString ("stackView"), new NSString ("scrollView") })
            //    )
            //);

            for (var i = 0; i < 100; i++) {
                var vw = new UIButton (UIButtonType.System);
                vw.SetTitle ("Button", UIControlState.Normal);
                stackView.AddArrangedSubview (vw);
            }
        }
    }
}

