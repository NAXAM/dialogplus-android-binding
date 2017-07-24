using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Orhanobut.Dialogplus;
using Java.Lang;
using System;

namespace DialogPlusQs
{
    [Activity(Label = "DialogPlusQs", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppBaseTheme")]
    public class MainActivity : Activity
    {
        private RadioGroup radioGroup;
        private CheckBox headerCheckBox;
        private CheckBox footerCheckBox;
        private CheckBox expandedCheckBox;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitInterface();
        }

        public void InitInterface()
        {
            radioGroup = FindViewById<RadioGroup>(Resource.Id.radio_group);
            headerCheckBox = FindViewById<CheckBox>(Resource.Id.header_check_box);
            footerCheckBox = FindViewById<CheckBox>(Resource.Id.footer_check_box);
            expandedCheckBox = FindViewById<CheckBox>(Resource.Id.expanded_check_box);

            FindViewById<Button>(Resource.Id.button_bottom).Click += (s, e) =>
            {
                ShowDialog
                (
                    radioGroup.CheckedRadioButtonId,
                    GravityFlags.Bottom,
                    headerCheckBox.Checked,
                    footerCheckBox.Checked,
                    expandedCheckBox.Checked
                );
            };

            FindViewById<Button>(Resource.Id.button_center).Click += (s, e) =>
            {
                ShowDialog(
                    radioGroup.CheckedRadioButtonId,
                    GravityFlags.Center,
                    headerCheckBox.Checked,
                    footerCheckBox.Checked,
                    expandedCheckBox.Checked
                );

            };

            FindViewById<Button>(Resource.Id.button_top).Click += (s, e) =>
            {
                ShowDialog(
                    radioGroup.CheckedRadioButtonId,
                    GravityFlags.Top,
                    headerCheckBox.Checked,
                    footerCheckBox.Checked,
                    expandedCheckBox.Checked
                );
            };
        }

        private void ShowDialog(int holderId, GravityFlags gravity, bool showHeader, bool showFooter, bool expanded)
        {
            bool isGrid;
            Com.Orhanobut.Dialogplus.IHolder holder;
            switch (holderId)
            {
                case Resource.Id.basic_holder_radio_button:
                    holder = new ViewHolder(Resource.Layout.content);
                    isGrid = false;
                    break;
                case Resource.Id.list_holder_radio_button:
                    holder = new ListHolder();
                    isGrid = false;
                    break;
                default:
                    holder = new GridHolder(3);
                    isGrid = true;
                    break;
            }

            OnClickListener clickListener = new OnClickListener()
            {
                ClickAction = (s, v) =>
                {

                }
            };

            OnItemClickListener itemClickListener = new OnItemClickListener()
            {
                ItemClick = (d, i, v, p) =>
                {
                    TextView textView = v.FindViewById<TextView>(Resource.Id.text_view);
                    string clickedAppName = textView.Text;
                    Toast.MakeText(this, clickedAppName + "Clicked", ToastLength.Short).Show();
                }
            };

            OnDismissListener dismissListener = new OnDismissListener()
            {
                Dimissed = (d) =>
                {
                    Toast.MakeText(this, "dismiss listener invoked!", ToastLength.Short).Show();
                }
            };

            OnCancelListener cancelListener = new OnCancelListener()
            {
                Canceled = (d) =>
                {
                    Toast.MakeText(this, "cancel listener invoked!", ToastLength.Short).Show();
                }
            };

            DialogPlusQs.Views.SimpleAdapter adapter = new DialogPlusQs.Views.SimpleAdapter(this, isGrid);

            if (showHeader && showFooter)
            {
                ShowCompleteDialog(holder, gravity, adapter, clickListener, itemClickListener, dismissListener, cancelListener,
                    expanded);
                return;
            }

            if (showHeader && !showFooter)
            {
                ShowNoFooterDialog(holder, gravity, adapter, clickListener, itemClickListener, dismissListener, cancelListener,
                    expanded);
                return;
            }

            if (!showHeader && showFooter)
            {
                ShowNoHeaderDialog(holder, gravity, adapter, clickListener, itemClickListener, dismissListener, cancelListener,
                    expanded);
                return;
            }

            ShowOnlyContentDialog(holder, gravity, adapter, itemClickListener, dismissListener, cancelListener, expanded);
        }

        private void ShowCompleteDialog(IHolder holder, GravityFlags gravity, BaseAdapter adapter,
                                  IOnClickListener clickListener, OnItemClickListener itemClickListener,
                                  OnDismissListener dismissListener, OnCancelListener cancelListener,
                                  bool expanded)
        {
            DialogPlus dialog = DialogPlus.NewDialog(this)
                .SetContentHolder(holder)
                .SetHeader(Resource.Layout.header)
                .SetFooter(Resource.Layout.footer)
                .SetCancelable(true)
                .SetGravity((int)gravity)
                .SetAdapter(adapter)
                .SetOnClickListener(clickListener)
                .SetOnItemClickListener(new OnItemClickListener()
                {
                    ItemClick = (p0, p1, p2, p3) =>
                    {
                        Toast.MakeText(this, "DialogPlus: " + " onItemClick() called with: " + "item = [" +
                            p1 + "], position = [" + p3 + "]", ToastLength.Short).Show();
                    }
                })
                .SetOnDismissListener(dismissListener)
                .SetExpanded(expanded)
                //.SetContentWidth(800)
                .SetContentHeight(ViewGroup.LayoutParams.WrapContent)
                .SetOnCancelListener(cancelListener)
                .SetOverlayBackgroundResource(Android.Resource.Color.Transparent)
                //.SetContentBackgroundResource(R.drawable.corner_background)
                //.SetOutMostMargin(0, 100, 0, 0)
                .Create();
            dialog.Show();
        }

        private void ShowNoFooterDialog(IHolder holder, GravityFlags gravity, BaseAdapter adapter,
                                  OnClickListener clickListener, OnItemClickListener itemClickListener,
                                  OnDismissListener dismissListener, OnCancelListener cancelListener,
                                  bool expanded)
        {
            DialogPlus dialog = DialogPlus.NewDialog(this)
                .SetContentHolder(holder)
                .SetHeader(Resource.Layout.header)
                .SetCancelable(true)
                .SetGravity((int)gravity)
                .SetAdapter(adapter)
                .SetOnClickListener(clickListener)
                .SetOnItemClickListener(new OnItemClickListener()
                {
                    ItemClick = (p0, p1, p2, p3) =>
                    {
                        Toast.MakeText(this, "DialogPlus: " + " onItemClick() called with: " + "item = [" +
                            p1 + "], position = [" + p3 + "]", ToastLength.Short).Show();
                    }
                })
                .SetOnDismissListener(dismissListener)
                .SetOnCancelListener(cancelListener)
                .SetExpanded(expanded)
                .Create();
            dialog.Show();

            
        }

        private void ShowNoHeaderDialog(IHolder holder, GravityFlags gravity, BaseAdapter adapter,
                                  OnClickListener clickListener, OnItemClickListener itemClickListener,
                                  OnDismissListener dismissListener, OnCancelListener cancelListener,
                                  bool expanded)
        {
            DialogPlus dialog = DialogPlus.NewDialog(this)
                .SetContentHolder(holder)
                .SetFooter(Resource.Layout.footer)
                .SetCancelable(true)
                .SetGravity((int)gravity)
                .SetAdapter(adapter)
                .SetOnClickListener(clickListener)
                .SetOnItemClickListener(new OnItemClickListener()
                {
                    ItemClick = (p0, p1, p2, p3) =>
                    {
                        Toast.MakeText(this, "DialogPlus: " + " onItemClick() called with: " + "item = [" +
                            p1 + "], position = [" + p3 + "]", ToastLength.Short).Show();
                    }
                })
                .SetOnDismissListener(dismissListener)
                .SetOnCancelListener(cancelListener)
                .SetExpanded(expanded)
                .Create();
            dialog.Show();
        }

        private void ShowOnlyContentDialog(IHolder holder, GravityFlags gravity, BaseAdapter adapter,
                                     OnItemClickListener itemClickListener, OnDismissListener dismissListener,
                                     OnCancelListener cancelListener, bool expanded)
        {
            DialogPlus dialog = DialogPlus.NewDialog(this)
               .SetContentHolder(holder)
               .SetGravity((int)gravity)
               .SetAdapter(adapter)
               .SetOnItemClickListener(new OnItemClickListener()
               {
                   ItemClick = (p0, p1, p2, p3) =>
                   {
                       Toast.MakeText(this, "DialogPlus: " + " onItemClick() called with: " + "item = [" +
                           p1 + "], position = [" + p3 + "]", ToastLength.Short).Show();
                   }
               })
               .SetOnDismissListener(dismissListener)
               .SetOnCancelListener(cancelListener)
               .SetExpanded(expanded)
               .SetCancelable(true)
               .Create();
            dialog.Show();
        }
    }

    class OnClickListener : Java.Lang.Object, IOnClickListener
    {
        public Action<DialogPlus, View> ClickAction;
        public void OnClick(DialogPlus p0, View p1)
        {
            ClickAction?.Invoke(p0, p1);
        }
    }

    class OnItemClickListener : Java.Lang.Object, IOnItemClickListener
    {
        public Action<DialogPlus, Java.Lang.Object, View, int> ItemClick { get; set; }
        public void OnItemClick(DialogPlus p0, Java.Lang.Object p1, View p2, int p3)
        {
            ItemClick?.Invoke(p0, p1, p2, p3);
        }
    }

    class OnDismissListener : Java.Lang.Object, IOnDismissListener
    {
        public Action<DialogPlus> Dimissed { get; set; }
        public void OnDismiss(DialogPlus p0)
        {
            Dimissed?.Invoke(p0);
        }
    }

    class OnCancelListener : Java.Lang.Object, IOnCancelListener
    {
        public Action<DialogPlus> Canceled { get; set; }
        public void OnCancel(DialogPlus p0)
        {
            Canceled?.Invoke(p0);
        }
    }

    class OnBackPressListener : Java.Lang.Object, IOnBackPressListener
    {
        public Action<DialogPlus> BackPressed { get; set; }
        public void OnBackPressed(DialogPlus p0)
        {
            BackPressed?.Invoke(p0);
        }
    }

}



