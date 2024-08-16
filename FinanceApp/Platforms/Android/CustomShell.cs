using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using ShellItem = Microsoft.Maui.Controls.ShellItem;
using Color = Microsoft.Maui.Graphics.Color;

namespace FinanceApp.Platforms.Android;

public class CustomShell : ShellRenderer
{
    public CustomShell()
    {
        
    }

    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        return new CustomShellBottomViewAppearnce(this, shellItem);
    }

    protected override IShellTabLayoutAppearanceTracker CreateTabLayoutAppearanceTracker(ShellSection shellSection)
    {
        return new CustomShellTabLayoutAppearance(this);
    }
}

public class CustomShellTabLayoutAppearance : ShellTabLayoutAppearanceTracker
{
    public CustomShellTabLayoutAppearance(IShellContext shellSection) : base(shellSection)
    {
    }

    public override void SetAppearance(TabLayout tabLayout, ShellAppearance appearance)
    {
        base.SetAppearance(tabLayout, appearance);

        tabLayout.TabMode = TabLayout.ModeFixed;
        tabLayout.TabGravity = TabLayout.GravityFill;
        tabLayout.SetSelectedTabIndicatorHeight(0);
        tabLayout.SetTabTextColors(Color.FromArgb("ADADAD").ToInt(), Color.FromArgb("#666666").ToInt());

        var backgroundDrawable = new GradientDrawable();
        backgroundDrawable.SetShape(ShapeType.Rectangle);
        backgroundDrawable.SetCornerRadius(18);
        backgroundDrawable.SetColor(Color.FromArgb("EDEDED").ToPlatform());
        tabLayout.SetBackground(backgroundDrawable);

        var layoutParams = tabLayout.LayoutParameters;
        if (layoutParams is ViewGroup.MarginLayoutParams marginLayoutParams)
        {
            marginLayoutParams.Height = 130;
            marginLayoutParams.LeftMargin = 90;
            marginLayoutParams.RightMargin = 90;
            marginLayoutParams.TopMargin = 60;
            tabLayout.LayoutParameters = layoutParams;
        }

    }
}

public class CustomShellBottomViewAppearnce : ShellBottomNavViewAppearanceTracker
{
    public CustomShellBottomViewAppearnce(IShellContext shellContext, Microsoft.Maui.Controls.ShellItem shellItem) : base(shellContext, shellItem)
    {
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;
        bottomView.ItemIconSize = 70;
        bottomView.SetBackgroundColor(Color.FromArgb("#F7F7F7").ToPlatform());
        bottomView.ItemIconTintList = ColorStateList.ValueOf(Color.FromArgb("#ADADAD").ToPlatform());

        BottomNavigationMenuView? bottomNavView = bottomView.GetChildAt(0) as BottomNavigationMenuView;

        for (int i = 0; i < bottomNavView?.ChildCount; i++)
        {
            if (bottomNavView.GetChildAt(i)!.Selected)
            {
                var item = bottomNavView.GetChildAt(i) as BottomNavigationItemView;

                item!.SetIconSize(80);
                item!.SetIconTintList(ColorStateList.ValueOf(Color.FromArgb("#8AAD90").ToPlatform()));
            }
            
        }
    }
}
