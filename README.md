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
  .setAdapter(adapter)
  .setOnItemClickListener(new OnItemClickListener() {
    @Override
    public void onItemClick(DialogPlus dialog, Object item, View view, int position) {
    }
  })
  .setExpanded(true)  // This will enable the expand feature, (similar to android L share dialog)
  .create();
dialog.show();
```

### More options
Enable expand animation same as Android L share dialog
```java
.setExpanded(true) // default is false, only works for grid and list
```
Set expand animation default height
```java
.setExpanded(true, 300)
```

Select different holder.

- Use ListView as content holder, note that this is default content type.
```java
setContentHolder(new ListHolder())
```
- Use ViewHolder as content holder if you want to use a custom view for your dialog. Pass resource id
```java
.setContentHolder(new ViewHolder(R.layout.content))
```
or pass view itself
```java
.setContentHolder(new ViewHolder(view))
```
- Use GridHolder if you want to use GridView for the dialog. You must set column number.
```java
.setContentHolder(new GridHolder(COLUMN_NUMBER))
```
- Get the holder view, ListView, GridView or your custom view
```java
View view = dialogPlus.getHolderView();
```
- Set dialog position. BOTTOM (default), TOP or CENTER. You can also combine other Gravity options.
```java
.setGravity(Gravity.CENTER)
```
- Define if the dialog is cancelable and should be closed when back pressed or out of dialog is clicked
```java
.setCancelable(true)
```
- Set Adapter, this adapter will be used to fill the content for ListHolder and GridHolder. This is required if the content holder is ListHolder or GridHolder. It is not required if the content holder is ViewHolder.
```java
.setAdapter(adapter);
```
- Set an item click listener when list or grid holder is chosen. In that way you can have callbacks when one of your items is clicked
```java
.setOnItemClickListener(new OnItemClickListener() {
  @Override
  public void onItemClick(DialogPlus dialog, Object item, View view, int position) {
  }
})
```
- Set a global click listener to you dialog in order to handle all the possible click events. You can then identify the view by using its id and handle the correct behaviour. Only views which has id will trigger this event.
```java
.setOnClickListener(new OnClickListener() {
    @Override
    public void onClick(DialogPlus dialog, View view) {

    }
})
```
- Add margins to your dialog. They are set to 0 except when gravity is center. In that case basic margins are applied
```java
.setMargin(left, top, right, bottom)
```
- Set padding to the holder
```java
.setPadding(left, top, right, bottom)
```
- Set the footer view using the id of the layout resource
```java
.setFooter(R.layout.footer)
```
or use view
```java
.setFooter(view)
```
- Get the footer view
```java
View view = dialogPlus.getFooterView();
```
- Set the header view using the id of the layout resource
```java
.setHeader(R.layout.header)
```
or use view
```java
.setHeader(view)
```
- Get the header view
```java
View view = dialogPlus.getHeaderView();
```
- Set animation resources
```java
.setInAnimation(R.anim.abc_fade_in)
.setOutAnimation(R.anim.abc_fade_out)
```
- Set width and height for the content
```java
.setContentWidth(ViewGroup.LayoutParams.WRAP_CONTENT)  // or any custom width ie: 300
.setContentHeight(ViewGroup.LayoutParams.WRAP_CONTENT)
```

- Dismiss Listener, triggered when the dialog is dismissed
```java
.setOnDismissListener(new OnDismissListener() {
    @Override
    public void onDismiss(DialogPlus dialog) {

    }
})
```

- Cancel Listener, triggered when the dialog is cancelled by back button or clicking outside
```java
.setOnCancelListener(new OnCancelListener() {
    @Override
    public void onCancel(DialogPlus dialog) {

    }
})
```

- BackPress Listener, triggered when the back button is pressed
```java
.setOnBackPressListener(new OnBackPressListener() {
    @Override
    public void onBackPressed(DialogPlus dialog) {

    }
})
```

- Change content container background, as default white
```java
.setContentBackgroundResource(resource)
```

- Change overlay container background, as default it's semi-transparent black
```java
.setOverlayBackgroundResource(resource)
```

#### Credites
- [Orhan Obut] (https://github.com/orhanobut): Native Library developer
