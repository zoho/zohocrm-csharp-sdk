using Com.Zoho.Crm.API.Util;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Users
{

	public class TabTheme : Model
	{
		private string fontColor;
		private string background;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string FontColor
		{
			/// <summary>The method to get the fontColor</summary>
			/// <returns>string representing the fontColor</returns>
			get
			{
				return  this.fontColor;

			}
			/// <summary>The method to set the value to fontColor</summary>
			/// <param name="fontColor">string</param>
			set
			{
				 this.fontColor=value;

				 this.keyModified["font_color"] = 1;

			}
		}

		public string Background
		{
			/// <summary>The method to get the background</summary>
			/// <returns>string representing the background</returns>
			get
			{
				return  this.background;

			}
			/// <summary>The method to set the value to background</summary>
			/// <param name="background">string</param>
			set
			{
				 this.background=value;

				 this.keyModified["background"] = 1;

			}
		}

		/// <summary>The method to check if the user has modified the given key</summary>
		/// <param name="key">string</param>
		/// <returns>int? representing the modification</returns>
		public int? IsKeyModified(string key)
		{
			if((( this.keyModified.ContainsKey(key))))
			{
				return  this.keyModified[key];

			}
			return null;


		}

		/// <summary>The method to mark the given key as modified</summary>
		/// <param name="key">string</param>
		/// <param name="modification">int?</param>
		public void SetKeyModified(string key, int? modification)
		{
			 this.keyModified[key] = modification;


		}


	}
}