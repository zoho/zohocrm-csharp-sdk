using System;
using System.Collections;
using System.Collections.Generic;

using System.Globalization;

using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Com.Zoho.Crm.API.Util
{
	/// <summary>
	/// This class converts JSON value to the expected data type.
	/// </summary>
	/// <typeparam name="T">T is CSharp permitted data type</typeparam>
	public class DataTypeConverter<T>
    {
        private delegate T PreConverter(object obj);

        private delegate object PostConverter(T obj);

        private static readonly Dictionary<string, PreConverter> PRE_CONVERTER_MAP = new Dictionary<string, PreConverter>();

        private static readonly Dictionary<string, PostConverter> POST_CONVERTER_MAP = new Dictionary<string, PostConverter>();

		static readonly PreConverter preCommonTypeConverter = (obj) =>
		{
			return (T)Convert.ChangeType(obj, typeof(T));
		};

		static readonly PostConverter postCommonTypeConverter = (obj) =>
		{
			return (T)Convert.ChangeType(obj, typeof(T));
		};

		/// <summary>
		/// This method is to initialize the PreConverter and PostConverter lambda functions.
		/// </summary>
		private static void Init()
		{
			if (PRE_CONVERTER_MAP.Count > 0 && POST_CONVERTER_MAP.Count > 0)
			{
				return;
			}

			AddToDictionary(typeof(DateTimeOffset).FullName,
            (obj) =>
			{
				DateTimeOffset dateTime = DateTimeOffset.Parse(obj.ToString()).ToLocalTime();

				return (T)Convert.ChangeType(dateTime, typeof(T));
			},
            (obj) =>
			{
				DateTimeOffset dateTime = (DateTimeOffset)Convert.ChangeType(obj, typeof(T));

				return dateTime.ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
			});

			AddToDictionary(typeof(long).FullName,
			(obj) =>
			{
				long value = long.Parse(obj.ToString());

				return (T)Convert.ChangeType(value, typeof(T));
			},
			(obj) =>
			{
				return obj;
			});
			
			AddToDictionary(typeof(double).FullName,
			(obj) =>
			{
				double value = double.Parse(obj.ToString());

				return (T)Convert.ChangeType(value, typeof(T));
			},
			(obj) =>
			{
				return obj;
			});

			AddToDictionary(typeof(bool).FullName,
			(obj) =>
			{
				bool value = bool.Parse(obj.ToString());

				return (T)Convert.ChangeType(value, typeof(T));
			},
			(obj) =>
			{
				return obj;
			});

			AddToDictionary(typeof(object).FullName,
			(obj) =>
			{
				return (T)PreConvertObjectData(obj);
			},
			(obj) =>
            {
				return PostConvertObjectData(obj);

			});

			AddToDictionary(typeof(string).FullName,
			(obj) =>
			{
				return (T)Convert.ChangeType(Convert.ToString(obj), typeof(T));
			},
			(obj) =>
			{
				return Convert.ToString(obj);
			});

			AddToDictionary(typeof(DateTime).FullName,
			(obj) =>
			{
				DateTime dateTime = DateTime.Parse(obj.ToString());

				return (T)Convert.ChangeType(dateTime, typeof(T));
			},
			(obj) =>
			{
				DateTime dateTime = (DateTime)Convert.ChangeType(obj, typeof(T));

				return dateTime.ToString("yyyy-MM-dd");
			});
		}

		public static object PreConvertObjectData(object obj)
		{
			if (obj is JToken)
			{
				JToken keyData = (JToken)obj;

				JTokenType tokenType = keyData.Type;

				if (tokenType is JTokenType.Null)
				{
					return null;
				}
			}

			if (obj is JArray)
			{
				JArray jsonArray = (JArray)obj;

				List<object> values = new List<object>();
			
				if(jsonArray.Count > 0)
				{
					foreach (object response in jsonArray)
					{
						values.Add(PreConvertObjectData(response));
					}
				}
			
				return values;
			}
			else if (obj is JObject)
			{
				JObject jsonObject = (JObject)obj;

				Dictionary<object, object> mapInstance = new Dictionary<object, object>();

				if (jsonObject.Count > 0)
				{
                    foreach (KeyValuePair<string, JToken> memberName in jsonObject)
					{
						object jsonValue = memberName.Value;

						mapInstance.Add(memberName.Key, PreConvertObjectData(jsonValue));
					}
				}

				return mapInstance;
			}
			else if (obj.GetType().Name.Equals("Object", StringComparison.OrdinalIgnoreCase))
			{
				return obj;
			}
			else
			{
				if(obj is JToken || obj is JValue)
                {
					JToken keyData = (JToken)obj;

					JTokenType tokenType = keyData.Type;

					if (tokenType is JTokenType.Null)
					{
						return null;
					}
					else
                    {
						string type = Converter.GetType(tokenType);

						if (type.Equals(Constants.CSHARP_INT_NAME))
						{
							long number = (long)keyData;

							if (!(number >= Int32.MinValue && number <= Int32.MaxValue))
							{
								type = Constants.CSHARP_LONG_NAME;
							}
						}

						Type t = Type.GetType(Constants.DATATYPECONVERTER.Replace(Constants._TYPE, type));

						MethodInfo method = t.GetMethod("PreConvert");

						var data = (T)method.Invoke(null, new object[] { obj, type });

						return data;
					}
				}

				return obj;
			}
		}

		public static object PostConvertObjectData(object obj)
		{
			if(obj == null)
            {
				return JValue.CreateNull();
			}

			if(obj is IList)
			{
				JArray list = new JArray();

				foreach (object value in (IList)obj)
				{
					list.Add(PostConvertObjectData(value));
				}

				return list;
			}
			else if (obj is IDictionary)
			{
				JObject value = new JObject();

				IDictionary requestObject = (IDictionary) obj;

				if (requestObject.Count > 0)
				{
					foreach (object key in requestObject.Keys)
					{
						object keyValue = requestObject[key];

						value.Add((string)key, JToken.FromObject(PostConvertObjectData(keyValue)));
					}
				}

				return value;
			}
			else if (obj.GetType().Name.Equals("Object", StringComparison.OrdinalIgnoreCase))
			{
				return obj;
			}
			else
			{
				Type t = Type.GetType(Constants.DATATYPECONVERTER.Replace(Constants._TYPE, obj.GetType().FullName));

				MethodInfo method = t.GetMethod("PostConvert");

				return method.Invoke(null, new object[] { obj, obj.GetType().FullName });
			}
		}

        private static void AddToDictionary(string name, PreConverter preConverter, PostConverter postConverter)
        {
			PRE_CONVERTER_MAP[name] = preConverter;

			POST_CONVERTER_MAP[name] = postConverter;
		}

        private static PreConverter GetPreConverter(string type)
        {
			if(PRE_CONVERTER_MAP.ContainsKey(type))
            {
				return PRE_CONVERTER_MAP[type];
			}

			return preCommonTypeConverter;
		}

		private static PostConverter GetPostConverter(string type)
		{
			if (POST_CONVERTER_MAP.ContainsKey(type))
			{
				return POST_CONVERTER_MAP[type];
			}

			return postCommonTypeConverter;
		}

		/// <summary>
		/// This method is to convert JSON value to expected data value.
		/// </summary>
		/// <param name="obj">A object containing the JSON value.</param>
		/// <param name="type">A string containing the expected method return type.</param>
		/// <returns>A T containing the expected data value.</returns>
		public static T PreConvert(object obj, string type)
        {
	        Init();

			return GetPreConverter(type)(obj);
	    }

		/// <summary>
		/// This method to convert CSharp data to JSON data value.
		/// </summary>
		/// <param name="obj">A T containing the CSharp data value.</param>
		/// <param name="type">A string containing the expected method return type.</param>
		/// <returns>A object containing the expected data value.</returns>
		public static object PostConvert(T obj, string type)
		{
			Init();

			return GetPostConverter(type)(obj);
		}
	}
}
