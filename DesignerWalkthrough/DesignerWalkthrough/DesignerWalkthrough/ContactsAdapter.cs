using System;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.App;
using Android.Provider;
using System.Collections.Generic;

namespace DesignerWalkthrough
{
    public class ContactsAdapter : BaseAdapter
    {
        List<Contact> _contactList;
        Activity _activity;
        
        public ContactsAdapter (Activity activity)
        {
            _activity = activity;
            
            FillContacts ();
        }
        
        public override int Count {
            get { return _contactList.Count; }
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return null;
        }

        public override long GetItemId (int position)
        {
            return _contactList [position].Id;
        }
        
        public override View GetView (int position, View convertView, ViewGroup parent)
        {          
            var view = convertView ?? _activity.LayoutInflater.Inflate (Resource.Layout.ListItem, parent, false);
            var contactName = view.FindViewById<TextView> (Resource.Id.textView1);
            var textView2 = view.FindViewById<TextView> (Resource.Id.textView2);
            var contactImage = view.FindViewById<ImageView> (Resource.Id.imageView1);
            
            textView2.Text = _contactList[position].Number;
            
            contactName.Text = _contactList [position].DisplayName;
            
            if (_contactList [position].PhotoId == null) {
                
                contactImage = view.FindViewById<ImageView> (Resource.Id.imageView1);
                contactImage.SetImageResource (Resource.Drawable.Placeholder);
                
            } else {
                
                var contactUri = ContentUris.WithAppendedId (ContactsContract.Contacts.ContentUri, _contactList [position].Id);
                var contactPhotoUri = Android.Net.Uri.WithAppendedPath (contactUri, ContactsContract.Contacts.Photo.ContentDirectory);
    
                contactImage.SetImageURI (contactPhotoUri);
            }
            return view;
        }
        
        void FillContacts ()
        {
            var uri = ContactsContract.Contacts.ContentUri;
            
            string[] projection = { 
                ContactsContract.Contacts.InterfaceConsts.Id, 
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoId
            };
          
            var cursor = _activity.ManagedQuery (uri, projection, null, null, null);
            
            _contactList = new List<Contact> ();   
            
            if (cursor.MoveToFirst ()) {
                do {
                    _contactList.Add (new Contact{
                        Id = cursor.GetLong (cursor.GetColumnIndex (projection [0])),
                        DisplayName = cursor.GetString (cursor.GetColumnIndex (projection [1])),
                        PhotoId = cursor.GetString (cursor.GetColumnIndex (projection [2])),
                        Number = "(123) 456 - 7890"
                    });
                } while (cursor.MoveToNext());
            }
        }
        
        class Contact
        {
            public long Id { get; set; }

            public string DisplayName{ get; set; }
            
            public string PhotoId { get; set; }
            
            public string Number { get; set; }
        }
    }
}

