using System;

namespace Com.Zoho.Crm.API
{
	/// <summary>
	/// The class to configure the SDK.
	/// </summary>
	public class SDKConfig
	{
		/// <summary>
		/// The Builder class to build SDKConfig
		/// </summary>
		public class Builder
		{
			private bool autoRefreshFields = false;

			private bool pickListValidation = true;

			/// <summary>
			/// This is a setter method to set autoRefreshFields.
			/// </summary>
			/// <param name="autoRefreshFields">A boolean</param>
			/// <returns>An instance of Builder</returns>
			public Builder SetAutoRefreshFields(bool autoRefreshFields)
			{
				this.autoRefreshFields = autoRefreshFields;

				return this;
			}

			/// <summary>
			/// This is a setter method to set pickListValidation.
			/// </summary>
			/// <param name="pickListValidation">A boolean</param>
			/// <returns>An instance of Builder</returns>
			public Builder SetPickListValidation(bool pickListValidation)
			{
				this.pickListValidation = pickListValidation;

				return this;
			}

			/// <summary>
			/// The method to build the SDKConfig instance
			/// </summary>
			/// <returns>An instance of SDKConfig</returns>
			public SDKConfig Build()
			{
				return new SDKConfig(autoRefreshFields, pickListValidation);
			}
		}

		private bool autoRefreshFields;

		private bool pickListValidation;

		/// <summary>
		/// Creates an instance of SDKConfig with the given parameters
		/// </summary>
		/// <param name="autoRefreshFields">A boolean representing autoRefreshFields</param>
		/// <param name="pickListValidation">A boolean representing pickListValidation</param>
		private SDKConfig(bool autoRefreshFields, bool pickListValidation)
		{
			this.autoRefreshFields = autoRefreshFields;

			this.pickListValidation = pickListValidation;
		}

		/// <summary>
		/// This is a getter method to get autoRefreshFields.
		/// </summary>
		/// <returns>A boolean representing autoRefreshFields</returns>
		public bool AutoRefreshFields
		{
            get
            {
				return autoRefreshFields;
			}
		}

		/// <summary>
		/// This is a getter method to get pickListValidation.
		/// </summary>
		/// <returns>A boolean representing pickListValidation</returns>
		public bool PickListValidation
		{
			get
			{
				return pickListValidation;
			}
		}
	}
}
