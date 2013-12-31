using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;

namespace Dia1Ex6
{
	public class CustomAdapter: BaseAdapter<string>
	{
		string[] items;
		Activity context;
		int resource;
		string[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex;

		public CustomAdapter (Activity context, int resource, string[] items) : base ()
		{
			this.context = context;
			this.items = items;
			this.resource = resource;

			alphaIndex = new Dictionary<string, int>();
			for (int i = 0; i < items.Length; i++) { // loop through items
				var key = items[i][0].ToString();
				if (!alphaIndex.ContainsKey(key))
					alphaIndex.Add(key, i); // add each 'new' letter to the index
			}
			sections = new string[alphaIndex.Keys.Count];
			alphaIndex.Keys.CopyTo(sections, 0); // convert letters list to string[]
			// Interface requires a Java.Lang.Object[], so we create one here
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (int i = 0; i < sections.Length; i++) {
				sectionsObjects[i] = new Java.Lang.String(sections[i]);
			}
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionsObjects;
		}

		public int GetPositionForSection(int section)
		{
			return alphaIndex[sections[section]];
		}

		public int GetSectionForPosition(int position)
		{   // this method isn't called in this example, but code is provided for completeness
			int prevSection = 0;
			for (int i = 0; i < sections.Length; i++) {
				if (GetPositionForSection(i) > position && prevSection <= position) {
					prevSection = i; break;
				}
			}
			return prevSection;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override string this [int position] {  
			get { return items [position]; }
		}

		public override int Count {
			get { return items.Length; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-usa uma view existente, se uma estiver dispomnível
			if (view == null)        // ou então cria uma nova
				view = context.LayoutInflater.Inflate (resource, null);

			Random rnd = new Random ();
			// ajusta as propriedades da view para refletir os dados da linha
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position];

			if (resource == Android.Resource.Layout.SimpleListItem2 ||
				resource == Android.Resource.Layout.TwoLineListItem) 
			{
				// ajusta as propriedades da view para o subtítulo da primeira linha
				view.FindViewById<TextView> (Android.Resource.Id.Text2).Text = String.Format ("{0} itens", rnd.Next (0, 100));
			}

			if (resource == Android.Resource.Layout.ActivityListItem)
			{
				// ajusta as propriedades da view para a imagem
				view.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageResource(Resource.Drawable.Icon);
			}

			// retorna a view, populadpa com informações, para mostrar
			return view;
		}
	}
}

