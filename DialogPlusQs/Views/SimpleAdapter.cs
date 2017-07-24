using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace DialogPlusQs.Views
{
    public class SimpleAdapter : BaseAdapter
    {
        private LayoutInflater layoutInflater;
        private bool isGrid;

        public SimpleAdapter(Context context, bool isGrid)
        {
            layoutInflater = LayoutInflater.From(context);
            this.isGrid = isGrid;
        }
        public override int Count
        {
            get { return 6; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            IViewHolder viewHolder;
            View view = convertView;

            if (view == null)
            {
                if (isGrid) view = layoutInflater.Inflate(Resource.Layout.simple_grid_item, parent, false);
                else view = layoutInflater.Inflate(Resource.Layout.simple_list_item, parent, false);


                viewHolder = new IViewHolder()
                {
                    textView = view.FindViewById<TextView>(Resource.Id.text_view),
                    imageView = view.FindViewById<ImageView>(Resource.Id.image_view)
                };
                view.Tag = viewHolder;
            }
            else viewHolder = (IViewHolder)view.Tag;

            Context context = parent.Context;
            switch (position)
            {
                case 0:
                    viewHolder.textView.Text = context.GetString(Resource.String.google_plus_title);
                    viewHolder.imageView.SetImageResource(Resource.Drawable.ic_google_plus_icon);
                    break;
                case 1:
                    viewHolder.textView.Text = context.GetString(Resource.String.google_maps_title);
                    viewHolder.imageView.SetImageResource(Resource.Drawable.ic_google_maps_icon);
                    break;
                default:
                    viewHolder.textView.Text = context.GetString(Resource.String.google_messenger_title);
                    viewHolder.imageView.SetImageResource(Resource.Drawable.ic_google_messenger_icon);
                    break;
            }
            return view;
        }

        public class IViewHolder : Java.Lang.Object
        {
            public TextView textView;
            public ImageView imageView;
        }
    }
}