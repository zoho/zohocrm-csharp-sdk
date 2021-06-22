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

			private int timeout = 100000;//The number of milliseconds to wait before the request times out. The default value is 100,000 milliseconds (100 seconds).

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
			/// This is a setter method to set timeout.
			/// </summary>
			/// <param name="timeout">A int</param>
			/// <returns>An instance of Builder</returns>
			public Builder Timeout(int timeout)
			{
				this.timeout = timeout != 100000 ? timeout: 100000;

				return this;
			}

			/// <summary>
			/// The method to build the SDKConfig instance
			/// </summary>
			/// <returns>An instance of SDKConfig</returns>
			public SDKConfig Build()
			{
				return new SDKConfig(autoRefreshFields, pickListValidation, timeout);
			}
		}

		private bool autoRefreshFields;

		private bool pickListValidation;

		private int timeout = 100000;

		/// <summary>
		/// Creates an instance of SDKConfig with the given parameters
		/// </summary>
		/// <param name="autoRefreshFields">A boolean representing autoRefreshFields</param>
		/// <param name="pickListValidation">A boolean representing pickListValidation</param>
		/// <param name="timeout">A int representing timeout</param>
		private SDKConfig(bool autoRefreshFields, bool pickListValidation, int timeout)
		{
			this.autoRefreshFields = autoRefreshFields;

			this.pickListValidation = pickListValidation;

			this.timeout = timeout;
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

		/// <summary>
		/// This is a getter method to get timeout.
		/// </summary>
		/// <returns>A int representing timeout</returns>
		public int Timeout
		{
			get
			{
				return timeout;
			}
		}
	}
}
