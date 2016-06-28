using common_lib;
using CoreGraphics;
using UIKit;

namespace StackView
{
    public class ViewController : SimpleViewController
    {
        UIScrollView ScrollView { get; set; }
        UIStackView stackView { get; set; }


        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            View.AddSubview (ScrollView = new UIScrollView ());
            ScrollView.TranslatesAutoresizingMaskIntoConstraints = false;




            ScrollView.AddSubview (stackView = new UIStackView ());

            stackView.TranslatesAutoresizingMaskIntoConstraints = false;
            stackView.Axis = UILayoutConstraintAxis.Vertical;
            stackView.Alignment = UIStackViewAlignment.Center;
            stackView.Distribution = UIStackViewDistribution.Fill;


        }

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);


            for (int i = 0; i < 56; i++) {


                IncreaseRating ();
            }

        }

        public override void WillAddConstraints ()
        {
            View.ConstrainLayout (() =>
                                  ScrollView.Frame.Top == View.Bounds.Top + sibling_sibling_margin &&
                                  ScrollView.Frame.Left == View.Bounds.Left + sibling_sibling_margin &&
                                  ScrollView.Frame.Right == View.Bounds.Right - sibling_sibling_margin &&
                                  ScrollView.Frame.Bottom == View.Bounds.Bottom - sibling_sibling_margin
                                 );

            ScrollView.ConstrainLayout (() =>
                                        stackView.Frame.Top == ScrollView.Bounds.Top + sibling_sibling_margin &&
                                        stackView.Frame.Left == ScrollView.Bounds.Left + sibling_sibling_margin &&
                                        stackView.Frame.Right == ScrollView.Bounds.Right - sibling_sibling_margin &&
                                        stackView.Frame.Bottom == ScrollView.Bounds.Bottom - sibling_sibling_margin &&
                                        stackView.Frame.Width == ScrollView.Bounds.Width - double_sibling_sibling_margin
                                 );
        }

        void IncreaseRating ()
        {

            // Create new rating icon and add it to stack
            var icon = new UIImageView (new UIImage ("icon.png"));
            icon.TranslatesAutoresizingMaskIntoConstraints = false;
            icon.ContentMode = UIViewContentMode.ScaleAspectFit;
            stackView.AddArrangedSubview (icon);



            // Animate stack
            //UIView.Animate (0.25, () => {
            //    // Adjust stack view
            //    stackView.LayoutIfNeeded ();
            //});

        }

        void DecreaseRating ()
        {

            // Get the last subview added
            var icon = stackView.ArrangedSubviews [stackView.ArrangedSubviews.Length - 1];

            // Remove from stack and screen
            stackView.RemoveArrangedSubview (icon);
            icon.RemoveFromSuperview ();

            // Animate stack
            UIView.Animate (0.25, () => {
                // Adjust stack view
                stackView.LayoutIfNeeded ();
            });
        }

        public static void apply_simple_border (UIView view, CGColor color = null)
        {
            view.Layer.BorderWidth = 1;
            view.Layer.BorderColor = color ?? UIColor.Black.CGColor;
        }
    }
}

