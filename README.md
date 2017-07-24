Dialogplus - Xamarin Android Binding Library
==========

<img src='https://github.com/nr4bt/dialogplus/blob/master/art/dialogplus.gif' height='400'/> <img src='https://github.com/nr4bt/dialogplus/blob/master/art/dialogplusanim.gif' height='400'/>

##### DialogPlus provides android L dialog animation

##### DialogPlus provides 3 position:
- Top : Dialog will appear at top with animation
- Center : Dialog will appear in the center with animation
- Bottom : Dialog will appear at the bottom of the screen with animation

##### DialogPlus provides 3 content types:
- ListHolder : Items will be shown in a listview
- GridHolder : Items will be shown in a gridview
- ViewHolder : Your customized view will be shown in the content

### NUGET
```
Install-Package Naxam.Dialogplus.Droid
```

### Usage
Use the builder to create the dialog.

Basic usage
```java
DialogPlus dialog = DialogPlus.newDialog(this)
  .SetAdapter(adapter)
  .SetOnItemClickListener(new OnItemClickListener() {
    ItemClick = (p0, p1, p2, p3) =>
		{
			// do something here
        }
  })
  .SetExpanded(true)  // This will enable the expand feature, (similar to android L share dialog)
  .Create();
dialog.show();
```

### More options
Enable expand animation same as Android L share dialog
```java
.SetExpanded(true) // default is false, only works for grid and list
```
Set expand animation default height
```java
.SetExpanded(true, 300)
```

Select different holder.

- Use ListView as content holder, note that this is default content type.
```java
SetContentHolder(new ListHolder())
```
- Use ViewHolder as content holder if you want to use a custom view for your dialog. Pass resource id
```java
.SetContentHolder(new ViewHolder(R.layout.content))
```
or pass view itself
```java
.SetContentHolder(new ViewHolder(view))
```
- Use GridHolder if you want to use GridView for the dialog. You must set column number.
```java
.SetContentHolder(new GridHolder(COLUMN_NUMBER))
```
- Get the holder view, ListView, GridView or your custom view
```java
View view = dialogPlus.HolderView;
```
- Set dialog position. BOTTOM (default), TOP or CENTER. You can also combine other Gravity options.
```java
.SetGravity(Gravity.CENTER)
```
- Define if the dialog is cancelable and should be closed when back pressed or out of dialog is clicked
```java
.SetCancelable(true)
```
- Set Adapter, this adapter will be used to fill the content for ListHolder and GridHolder. This is required if the content holder is ListHolder or GridHolder. It is not required if the content holder is ViewHolder.
```java
.SetAdapter(adapter);
```
- Set an item click listener when list or grid holder is chosen. In that way you can have callbacks when one of your items is clicked
```java

//create class OnItemClickListener extent IOnItemClickListener
class OnItemClickListener : Java.Lang.Object, IOnItemClickListener
    {
        public Action<DialogPlus, Java.Lang.Object, View, int> ItemClick { get; set; }
        public void OnItemClick(DialogPlus p0, Java.Lang.Object p1, View p2, int p3)
        {
            ItemClick?.Invoke(p0, p1, p2, p3);
        }
    }
// and SetOnItemClickListener 
.SetOnItemClickListener(new OnItemClickListener() {
	ItemClick = (p0, p1, p2, p3) =>
        {
            // do somthing here
        }
})
```
- Set a global click listener to you dialog in order to handle all the possible click events. You can then identify the view by using its id and handle the correct behaviour. Only views which has id will trigger this event.
```java

// create class OnClickListener extent OnClickListener
class OnClickListener : Java.Lang.Object, IOnClickListener
    {
        public Action<DialogPlus, View> ClickAction;
        public void OnClick(DialogPlus p0, View p1)
        {
            ClickAction?.Invoke(p0, p1);
        }
    }
// and SetOnClickListener
.SetOnClickListener(new OnClickListener() {
    ClickAction = (p0,p1)=>
	{
		// do something here
	}
})
```
- Add margins to your dialog. They are set to 0 except when gravity is center. In that case basic margins are applied
```java
.SetMargin(left, top, right, bottom)
```
- Set padding to the holder
```java
.SetPadding(left, top, right, bottom)
```
- Set the footer view using the id of the layout resource
```java
.SetFooter(R.layout.footer)
```
or use view
```java
.SetFooter(view)
```
- Get the footer view
```java
View view = dialogPlus.FooterView;
```
- Set the header view using the id of the layout resource
```java
.SetHeader(Resource.Layout.header)
```
or use view
```java
.SetHeader(view)
```
- Get the header view
```java
View view = dialogPlus.HeaderView;
```
- Set animation resources
```java
.SetInAnimation(Resource.animation.abc_fade_in)
.SetOutAnimation(Resource.animation.abc_fade_out)
```
- Set width and height for the content
```java
.SetContentWidth(ViewGroup.LayoutParamsFlag.wrap)  // or any custom width ie: 300
.SetContentHeight(ViewGroup.LayoutParams.WrapContent)
```

- Dismiss Listener, triggered when the dialog is dismissed
```java

// create OnDismissListener extent IOnDismissListener
class OnDismissListener : Java.Lang.Object, IOnDismissListener
    {
        public Action<DialogPlus> Dimissed { get; set; }
        public void OnDismiss(DialogPlus p0)
        {
            Dimissed?.Invoke(p0);
        }
    }
// and SetOnDismissListener
.SetOnDismissListener(new OnDismissListener() {
    Dimissed = (d) =>
        {
            // do something here
        }
})
```

- Cancel Listener, triggered when the dialog is cancelled by back button or clicking outside
```java

// create class OnCancelListener extent IOnCancelListener
class OnCancelListener : Java.Lang.Object, IOnCancelListener
    {
        public Action<DialogPlus> Canceled { get; set; }
        public void OnCancel(DialogPlus p0)
        {
            Canceled?.Invoke(p0);
        }
    }
// and SetOnCancelListener
.SetOnCancelListener(new OnCancelListener() {
    Canceled = (d) =>
        {
            // do something here
        }
})
```

- BackPress Listener, triggered when the back button is pressed
```java
.SetOnBackPressListener(new OnBackPressListener() {
    @Override
    public void onBackPressed(DialogPlus dialog) {

    }
})
```

- Change content container background, as default white
```java
.SetContentBackgroundResource(resource)
```

- Change overlay container background, as default it's semi-transparent black
```java
.SetOverlayBackgroundResource(resource)
```

#### Credites
- [Orhan Obut] (https://github.com/orhanobut): Native Library developer
