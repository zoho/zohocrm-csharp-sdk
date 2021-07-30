using Com.Zoho.Crm.API.Layouts;
using Com.Zoho.Crm.API.Tags;
using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Record
{

	public class Field<T>
	{
		private string apiName;

		/// <summary>		/// Creates an instance of Field with the given parameters
		/// <param name="apiName">string</param>
		
		public Field(string apiName)
		{
			 this.apiName=apiName;


		}

		public string APIName
		{
			/// <summary>The method to get the aPIName</summary>
			/// <returns>string representing the apiName</returns>
			get
			{
				return  this.apiName;

			}

		}


	}
	public static class Products
	{
		public static readonly Field<Choice<string>> PRODUCT_CATEGORY=new Field<Choice<string>>("Product_Category");
		public static readonly Field<double?> QTY_IN_DEMAND=new Field<double?>("Qty_in_Demand");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Record> VENDOR_NAME=new Field<Record>("Vendor_Name");
		public static readonly Field<List<Choice<string>>> TAX=new Field<List<Choice<string>>>("Tax");
		public static readonly Field<DateTime?> SALES_START_DATE=new Field<DateTime?>("Sales_Start_Date");
		public static readonly Field<bool?> PRODUCT_ACTIVE=new Field<bool?>("Product_Active");
		public static readonly Field<string> RECORD_IMAGE=new Field<string>("Record_Image");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> PRODUCT_CODE=new Field<string>("Product_Code");
		public static readonly Field<Choice<string>> MANUFACTURER=new Field<Choice<string>>("Manufacturer");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<DateTime?> SUPPORT_EXPIRY_DATE=new Field<DateTime?>("Support_Expiry_Date");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<double?> COMMISSION_RATE=new Field<double?>("Commission_Rate");
		public static readonly Field<string> PRODUCT_NAME=new Field<string>("Product_Name");
		public static readonly Field<User> HANDLER=new Field<User>("Handler");
		public static readonly Field<DateTime?> SUPPORT_START_DATE=new Field<DateTime?>("Support_Start_Date");
		public static readonly Field<Choice<string>> USAGE_UNIT=new Field<Choice<string>>("Usage_Unit");
		public static readonly Field<double?> QTY_ORDERED=new Field<double?>("Qty_Ordered");
		public static readonly Field<double?> QTY_IN_STOCK=new Field<double?>("Qty_in_Stock");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<DateTime?> SALES_END_DATE=new Field<DateTime?>("Sales_End_Date");
		public static readonly Field<double?> UNIT_PRICE=new Field<double?>("Unit_Price");
		public static readonly Field<bool?> TAXABLE=new Field<bool?>("Taxable");
		public static readonly Field<double?> REORDER_LEVEL=new Field<double?>("Reorder_Level");
	}


	public static class Tasks
	{
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<DateTime?> DUE_DATE=new Field<DateTime?>("Due_Date");
		public static readonly Field<Choice<string>> PRIORITY=new Field<Choice<string>>("Priority");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<DateTimeOffset?> CLOSED_TIME=new Field<DateTimeOffset?>("Closed_Time");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<bool?> SEND_NOTIFICATION_EMAIL=new Field<bool?>("Send_Notification_Email");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<RecurringActivity> RECURRING_ACTIVITY=new Field<RecurringActivity>("Recurring_Activity");
		public static readonly Field<Record> WHAT_ID=new Field<Record>("What_Id");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<RemindAt> REMIND_AT=new Field<RemindAt>("Remind_At");
		public static readonly Field<Record> WHO_ID=new Field<Record>("Who_Id");
	}


	public static class Vendors
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> EMAIL=new Field<string>("Email");
		public static readonly Field<string> CATEGORY=new Field<string>("Category");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> VENDOR_NAME=new Field<string>("Vendor_Name");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> WEBSITE=new Field<string>("Website");
		public static readonly Field<string> CITY=new Field<string>("City");
		public static readonly Field<string> RECORD_IMAGE=new Field<string>("Record_Image");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> PHONE=new Field<string>("Phone");
		public static readonly Field<string> STATE=new Field<string>("State");
		public static readonly Field<Choice<string>> GL_ACCOUNT=new Field<Choice<string>>("GL_Account");
		public static readonly Field<string> STREET=new Field<string>("Street");
		public static readonly Field<string> COUNTRY=new Field<string>("Country");
		public static readonly Field<string> ZIP_CODE=new Field<string>("Zip_Code");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
	}


	public static class Calls
	{
		public static readonly Field<string> CALL_DURATION=new Field<string>("Call_Duration");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Choice<string>> REMINDER=new Field<Choice<string>>("Reminder");
		public static readonly Field<string> CALLER_ID=new Field<string>("Caller_ID");
		public static readonly Field<bool?> CTI_ENTRY=new Field<bool?>("CTI_Entry");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<DateTimeOffset?> CALL_START_TIME=new Field<DateTimeOffset?>("Call_Start_Time");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<string> CALL_AGENDA=new Field<string>("Call_Agenda");
		public static readonly Field<string> CALL_RESULT=new Field<string>("Call_Result");
		public static readonly Field<Choice<string>> CALL_TYPE=new Field<Choice<string>>("Call_Type");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<Record> WHAT_ID=new Field<Record>("What_Id");
		public static readonly Field<int?> CALL_DURATION_IN_SECONDS=new Field<int?>("Call_Duration_in_seconds");
		public static readonly Field<Choice<string>> CALL_PURPOSE=new Field<Choice<string>>("Call_Purpose");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<string> DIALLED_NUMBER=new Field<string>("Dialled_Number");
		public static readonly Field<Choice<string>> CALL_STATUS=new Field<Choice<string>>("Call_Status");
		public static readonly Field<Record> WHO_ID=new Field<Record>("Who_Id");
	}


	public static class Leads
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> COMPANY=new Field<string>("Company");
		public static readonly Field<string> EMAIL=new Field<string>("Email");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Choice<string>> RATING=new Field<Choice<string>>("Rating");
		public static readonly Field<string> WEBSITE=new Field<string>("Website");
		public static readonly Field<string> TWITTER=new Field<string>("Twitter");
		public static readonly Field<Choice<string>> SALUTATION=new Field<Choice<string>>("Salutation");
		public static readonly Field<DateTimeOffset?> LAST_ACTIVITY_TIME=new Field<DateTimeOffset?>("Last_Activity_Time");
		public static readonly Field<string> FIRST_NAME=new Field<string>("First_Name");
		public static readonly Field<string> FULL_NAME=new Field<string>("Full_Name");
		public static readonly Field<Choice<string>> LEAD_STATUS=new Field<Choice<string>>("Lead_Status");
		public static readonly Field<Choice<string>> INDUSTRY=new Field<Choice<string>>("Industry");
		public static readonly Field<string> RECORD_IMAGE=new Field<string>("Record_Image");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> SKYPE_ID=new Field<string>("Skype_ID");
		public static readonly Field<string> PHONE=new Field<string>("Phone");
		public static readonly Field<string> STREET=new Field<string>("Street");
		public static readonly Field<string> ZIP_CODE=new Field<string>("Zip_Code");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<bool?> EMAIL_OPT_OUT=new Field<bool?>("Email_Opt_Out");
		public static readonly Field<string> DESIGNATION=new Field<string>("Designation");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> CITY=new Field<string>("City");
		public static readonly Field<int?> NO_OF_EMPLOYEES=new Field<int?>("No_of_Employees");
		public static readonly Field<string> MOBILE=new Field<string>("Mobile");
		public static readonly Field<DateTimeOffset?> CONVERTED_DATE_TIME=new Field<DateTimeOffset?>("Converted_Date_Time");
		public static readonly Field<string> LAST_NAME=new Field<string>("Last_Name");
		public static readonly Field<Layout> LAYOUT=new Field<Layout>("Layout");
		public static readonly Field<string> STATE=new Field<string>("State");
		public static readonly Field<Choice<string>> LEAD_SOURCE=new Field<Choice<string>>("Lead_Source");
		public static readonly Field<bool?> IS_RECORD_DUPLICATE=new Field<bool?>("Is_Record_Duplicate");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<string> FAX=new Field<string>("Fax");
		public static readonly Field<double?> ANNUAL_REVENUE=new Field<double?>("Annual_Revenue");
		public static readonly Field<string> SECONDARY_EMAIL=new Field<string>("Secondary_Email");
	}


	public static class Deals
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Record> CAMPAIGN_SOURCE=new Field<Record>("Campaign_Source");
		public static readonly Field<DateTime?> CLOSING_DATE=new Field<DateTime?>("Closing_Date");
		public static readonly Field<DateTimeOffset?> LAST_ACTIVITY_TIME=new Field<DateTimeOffset?>("Last_Activity_Time");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<int?> LEAD_CONVERSION_TIME=new Field<int?>("Lead_Conversion_Time");
		public static readonly Field<string> DEAL_NAME=new Field<string>("Deal_Name");
		public static readonly Field<double?> EXPECTED_REVENUE=new Field<double?>("Expected_Revenue");
		public static readonly Field<int?> OVERALL_SALES_DURATION=new Field<int?>("Overall_Sales_Duration");
		public static readonly Field<Choice<string>> STAGE=new Field<Choice<string>>("Stage");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> TERRITORY=new Field<string>("Territory");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<double?> AMOUNT=new Field<double?>("Amount");
		public static readonly Field<int?> PROBABILITY=new Field<int?>("Probability");
		public static readonly Field<string> NEXT_STEP=new Field<string>("Next_Step");
		public static readonly Field<Record> CONTACT_NAME=new Field<Record>("Contact_Name");
		public static readonly Field<int?> SALES_CYCLE_DURATION=new Field<int?>("Sales_Cycle_Duration");
		public static readonly Field<Choice<string>> TYPE=new Field<Choice<string>>("Type");
		public static readonly Field<Choice<string>> DEAL_CATEGORY_STATUS=new Field<Choice<string>>("Deal_Category_Status");
		public static readonly Field<Choice<string>> LEAD_SOURCE=new Field<Choice<string>>("Lead_Source");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
	}


	public static class Campaigns
	{
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> CAMPAIGN_NAME=new Field<string>("Campaign_Name");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<DateTime?> END_DATE=new Field<DateTime?>("End_Date");
		public static readonly Field<Choice<string>> TYPE=new Field<Choice<string>>("Type");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<long?> NUM_SENT=new Field<long?>("Num_sent");
		public static readonly Field<double?> EXPECTED_REVENUE=new Field<double?>("Expected_Revenue");
		public static readonly Field<double?> ACTUAL_COST=new Field<double?>("Actual_Cost");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<long?> EXPECTED_RESPONSE=new Field<long?>("Expected_Response");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<Record> PARENT_CAMPAIGN=new Field<Record>("Parent_Campaign");
		public static readonly Field<DateTime?> START_DATE=new Field<DateTime?>("Start_Date");
		public static readonly Field<double?> BUDGETED_COST=new Field<double?>("Budgeted_Cost");
	}


	public static class Quotes
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<double?> DISCOUNT=new Field<double?>("Discount");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> SHIPPING_STATE=new Field<string>("Shipping_State");
		public static readonly Field<double?> TAX=new Field<double?>("Tax");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<Record> DEAL_NAME=new Field<Record>("Deal_Name");
		public static readonly Field<DateTime?> VALID_TILL=new Field<DateTime?>("Valid_Till");
		public static readonly Field<string> BILLING_COUNTRY=new Field<string>("Billing_Country");
		public static readonly Field<Record> ACCOUNT_NAME=new Field<Record>("Account_Name");
		public static readonly Field<string> TEAM=new Field<string>("Team");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<Choice<string>> CARRIER=new Field<Choice<string>>("Carrier");
		public static readonly Field<Choice<string>> QUOTE_STAGE=new Field<Choice<string>>("Quote_Stage");
		public static readonly Field<double?> GRAND_TOTAL=new Field<double?>("Grand_Total");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> BILLING_STREET=new Field<string>("Billing_Street");
		public static readonly Field<double?> ADJUSTMENT=new Field<double?>("Adjustment");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> TERMS_AND_CONDITIONS=new Field<string>("Terms_and_Conditions");
		public static readonly Field<double?> SUB_TOTAL=new Field<double?>("Sub_Total");
		public static readonly Field<string> BILLING_CODE=new Field<string>("Billing_Code");
		public static readonly Field<List<InventoryLineItems>> PRODUCT_DETAILS=new Field<List<InventoryLineItems>>("Product_Details");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<Record> CONTACT_NAME=new Field<Record>("Contact_Name");
		public static readonly Field<string> SHIPPING_CITY=new Field<string>("Shipping_City");
		public static readonly Field<string> SHIPPING_COUNTRY=new Field<string>("Shipping_Country");
		public static readonly Field<string> SHIPPING_CODE=new Field<string>("Shipping_Code");
		public static readonly Field<string> BILLING_CITY=new Field<string>("Billing_City");
		public static readonly Field<long?> QUOTE_NUMBER=new Field<long?>("Quote_Number");
		public static readonly Field<string> BILLING_STATE=new Field<string>("Billing_State");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<string> SHIPPING_STREET=new Field<string>("Shipping_Street");
	}


	public static class Invoices
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<double?> DISCOUNT=new Field<double?>("Discount");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> SHIPPING_STATE=new Field<string>("Shipping_State");
		public static readonly Field<double?> TAX=new Field<double?>("Tax");
		public static readonly Field<DateTime?> INVOICE_DATE=new Field<DateTime?>("Invoice_Date");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> BILLING_COUNTRY=new Field<string>("Billing_Country");
		public static readonly Field<Record> ACCOUNT_NAME=new Field<Record>("Account_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<Record> SALES_ORDER=new Field<Record>("Sales_Order");
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<double?> GRAND_TOTAL=new Field<double?>("Grand_Total");
		public static readonly Field<double?> SALES_COMMISSION=new Field<double?>("Sales_Commission");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTime?> DUE_DATE=new Field<DateTime?>("Due_Date");
		public static readonly Field<string> BILLING_STREET=new Field<string>("Billing_Street");
		public static readonly Field<double?> ADJUSTMENT=new Field<double?>("Adjustment");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> TERMS_AND_CONDITIONS=new Field<string>("Terms_and_Conditions");
		public static readonly Field<double?> SUB_TOTAL=new Field<double?>("Sub_Total");
		public static readonly Field<long?> INVOICE_NUMBER=new Field<long?>("Invoice_Number");
		public static readonly Field<string> BILLING_CODE=new Field<string>("Billing_Code");
		public static readonly Field<List<InventoryLineItems>> PRODUCT_DETAILS=new Field<List<InventoryLineItems>>("Product_Details");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<Record> CONTACT_NAME=new Field<Record>("Contact_Name");
		public static readonly Field<double?> EXCISE_DUTY=new Field<double?>("Excise_Duty");
		public static readonly Field<string> SHIPPING_CITY=new Field<string>("Shipping_City");
		public static readonly Field<string> SHIPPING_COUNTRY=new Field<string>("Shipping_Country");
		public static readonly Field<string> SHIPPING_CODE=new Field<string>("Shipping_Code");
		public static readonly Field<string> BILLING_CITY=new Field<string>("Billing_City");
		public static readonly Field<string> PURCHASE_ORDER=new Field<string>("Purchase_Order");
		public static readonly Field<string> BILLING_STATE=new Field<string>("Billing_State");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<string> SHIPPING_STREET=new Field<string>("Shipping_Street");
	}


	public static class Attachments
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> FILE_NAME=new Field<string>("File_Name");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> SIZE=new Field<string>("Size");
		public static readonly Field<Record> PARENT_ID=new Field<Record>("Parent_Id");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
	}


	public static class Price_Books
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<bool?> ACTIVE=new Field<bool?>("Active");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<List<PricingDetails>> PRICING_DETAILS=new Field<List<PricingDetails>>("Pricing_Details");
		public static readonly Field<Choice<string>> PRICING_MODEL=new Field<Choice<string>>("Pricing_Model");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> PRICE_BOOK_NAME=new Field<string>("Price_Book_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
	}


	public static class Sales_Orders
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<double?> DISCOUNT=new Field<double?>("Discount");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> CUSTOMER_NO=new Field<string>("Customer_No");
		public static readonly Field<string> SHIPPING_STATE=new Field<string>("Shipping_State");
		public static readonly Field<double?> TAX=new Field<double?>("Tax");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<Record> DEAL_NAME=new Field<Record>("Deal_Name");
		public static readonly Field<string> BILLING_COUNTRY=new Field<string>("Billing_Country");
		public static readonly Field<Record> ACCOUNT_NAME=new Field<Record>("Account_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<Choice<string>> CARRIER=new Field<Choice<string>>("Carrier");
		public static readonly Field<Record> QUOTE_NAME=new Field<Record>("Quote_Name");
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<double?> SALES_COMMISSION=new Field<double?>("Sales_Commission");
		public static readonly Field<double?> GRAND_TOTAL=new Field<double?>("Grand_Total");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTime?> DUE_DATE=new Field<DateTime?>("Due_Date");
		public static readonly Field<string> BILLING_STREET=new Field<string>("Billing_Street");
		public static readonly Field<double?> ADJUSTMENT=new Field<double?>("Adjustment");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> TERMS_AND_CONDITIONS=new Field<string>("Terms_and_Conditions");
		public static readonly Field<double?> SUB_TOTAL=new Field<double?>("Sub_Total");
		public static readonly Field<string> BILLING_CODE=new Field<string>("Billing_Code");
		public static readonly Field<List<InventoryLineItems>> PRODUCT_DETAILS=new Field<List<InventoryLineItems>>("Product_Details");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<Record> CONTACT_NAME=new Field<Record>("Contact_Name");
		public static readonly Field<double?> EXCISE_DUTY=new Field<double?>("Excise_Duty");
		public static readonly Field<string> SHIPPING_CITY=new Field<string>("Shipping_City");
		public static readonly Field<string> SHIPPING_COUNTRY=new Field<string>("Shipping_Country");
		public static readonly Field<string> SHIPPING_CODE=new Field<string>("Shipping_Code");
		public static readonly Field<string> BILLING_CITY=new Field<string>("Billing_City");
		public static readonly Field<long?> SO_NUMBER=new Field<long?>("SO_Number");
		public static readonly Field<string> PURCHASE_ORDER=new Field<string>("Purchase_Order");
		public static readonly Field<string> BILLING_STATE=new Field<string>("Billing_State");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<string> PENDING=new Field<string>("Pending");
		public static readonly Field<string> SHIPPING_STREET=new Field<string>("Shipping_Street");
	}


	public static class Contacts
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> EMAIL=new Field<string>("Email");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Record> VENDOR_NAME=new Field<Record>("Vendor_Name");
		public static readonly Field<string> MAILING_ZIP=new Field<string>("Mailing_Zip");
		public static readonly Field<string> REPORTS_TO=new Field<string>("Reports_To");
		public static readonly Field<string> OTHER_PHONE=new Field<string>("Other_Phone");
		public static readonly Field<string> MAILING_STATE=new Field<string>("Mailing_State");
		public static readonly Field<string> TWITTER=new Field<string>("Twitter");
		public static readonly Field<string> OTHER_ZIP=new Field<string>("Other_Zip");
		public static readonly Field<string> MAILING_STREET=new Field<string>("Mailing_Street");
		public static readonly Field<string> OTHER_STATE=new Field<string>("Other_State");
		public static readonly Field<Choice<string>> SALUTATION=new Field<Choice<string>>("Salutation");
		public static readonly Field<string> OTHER_COUNTRY=new Field<string>("Other_Country");
		public static readonly Field<DateTimeOffset?> LAST_ACTIVITY_TIME=new Field<DateTimeOffset?>("Last_Activity_Time");
		public static readonly Field<string> FIRST_NAME=new Field<string>("First_Name");
		public static readonly Field<string> FULL_NAME=new Field<string>("Full_Name");
		public static readonly Field<string> ASST_PHONE=new Field<string>("Asst_Phone");
		public static readonly Field<string> RECORD_IMAGE=new Field<string>("Record_Image");
		public static readonly Field<string> DEPARTMENT=new Field<string>("Department");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> SKYPE_ID=new Field<string>("Skype_ID");
		public static readonly Field<string> ASSISTANT=new Field<string>("Assistant");
		public static readonly Field<string> PHONE=new Field<string>("Phone");
		public static readonly Field<string> MAILING_COUNTRY=new Field<string>("Mailing_Country");
		public static readonly Field<Record> ACCOUNT_NAME=new Field<Record>("Account_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<bool?> EMAIL_OPT_OUT=new Field<bool?>("Email_Opt_Out");
		public static readonly Field<Record> REPORTING_TO=new Field<Record>("Reporting_To");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTime?> DATE_OF_BIRTH=new Field<DateTime?>("Date_of_Birth");
		public static readonly Field<string> MAILING_CITY=new Field<string>("Mailing_City");
		public static readonly Field<string> OTHER_CITY=new Field<string>("Other_City");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> TITLE=new Field<string>("Title");
		public static readonly Field<string> OTHER_STREET=new Field<string>("Other_Street");
		public static readonly Field<string> MOBILE=new Field<string>("Mobile");
		public static readonly Field<string> TERRITORIES=new Field<string>("Territories");
		public static readonly Field<string> HOME_PHONE=new Field<string>("Home_Phone");
		public static readonly Field<string> LAST_NAME=new Field<string>("Last_Name");
		public static readonly Field<Choice<string>> LEAD_SOURCE=new Field<Choice<string>>("Lead_Source");
		public static readonly Field<bool?> IS_RECORD_DUPLICATE=new Field<bool?>("Is_Record_Duplicate");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<string> FAX=new Field<string>("Fax");
		public static readonly Field<string> SECONDARY_EMAIL=new Field<string>("Secondary_Email");
	}


	public static class Solutions
	{
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> COMMENTS=new Field<string>("Comments");
		public static readonly Field<int?> NO_OF_COMMENTS=new Field<int?>("No_of_comments");
		public static readonly Field<Record> PRODUCT_NAME=new Field<Record>("Product_Name");
		public static readonly Field<string> ADD_COMMENT=new Field<string>("Add_Comment");
		public static readonly Field<long?> SOLUTION_NUMBER=new Field<long?>("Solution_Number");
		public static readonly Field<string> ANSWER=new Field<string>("Answer");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> SOLUTION_TITLE=new Field<string>("Solution_Title");
		public static readonly Field<bool?> PUBLISHED=new Field<bool?>("Published");
		public static readonly Field<string> QUESTION=new Field<string>("Question");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
	}


	public static class Events
	{
		public static readonly Field<bool?> ALL_DAY=new Field<bool?>("All_day");
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> CHECK_IN_STATE=new Field<string>("Check_In_State");
		public static readonly Field<string> CHECK_IN_ADDRESS=new Field<string>("Check_In_Address");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<DateTimeOffset?> START_DATETIME=new Field<DateTimeOffset?>("Start_DateTime");
		public static readonly Field<double?> LATITUDE=new Field<double?>("Latitude");
		public static readonly Field<List<Participants>> PARTICIPANTS=new Field<List<Participants>>("Participants");
		public static readonly Field<string> EVENT_TITLE=new Field<string>("Event_Title");
		public static readonly Field<DateTimeOffset?> END_DATETIME=new Field<DateTimeOffset?>("End_DateTime");
		public static readonly Field<User> CHECK_IN_BY=new Field<User>("Check_In_By");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> CHECK_IN_CITY=new Field<string>("Check_In_City");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<string> CHECK_IN_COMMENT=new Field<string>("Check_In_Comment");
		public static readonly Field<DateTimeOffset?> REMIND_AT=new Field<DateTimeOffset?>("Remind_At");
		public static readonly Field<Record> WHO_ID=new Field<Record>("Who_Id");
		public static readonly Field<string> CHECK_IN_STATUS=new Field<string>("Check_In_Status");
		public static readonly Field<string> CHECK_IN_COUNTRY=new Field<string>("Check_In_Country");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> VENUE=new Field<string>("Venue");
		public static readonly Field<string> ZIP_CODE=new Field<string>("ZIP_Code");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<double?> LONGITUDE=new Field<double?>("Longitude");
		public static readonly Field<DateTimeOffset?> CHECK_IN_TIME=new Field<DateTimeOffset?>("Check_In_Time");
		public static readonly Field<RecurringActivity> RECURRING_ACTIVITY=new Field<RecurringActivity>("Recurring_Activity");
		public static readonly Field<Record> WHAT_ID=new Field<Record>("What_Id");
		public static readonly Field<string> CHECK_IN_SUB_LOCALITY=new Field<string>("Check_In_Sub_Locality");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
	}


	public static class Purchase_Orders
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<double?> DISCOUNT=new Field<double?>("Discount");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Record> VENDOR_NAME=new Field<Record>("Vendor_Name");
		public static readonly Field<string> SHIPPING_STATE=new Field<string>("Shipping_State");
		public static readonly Field<double?> TAX=new Field<double?>("Tax");
		public static readonly Field<DateTime?> PO_DATE=new Field<DateTime?>("PO_Date");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> BILLING_COUNTRY=new Field<string>("Billing_Country");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<Choice<string>> CARRIER=new Field<Choice<string>>("Carrier");
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<double?> GRAND_TOTAL=new Field<double?>("Grand_Total");
		public static readonly Field<double?> SALES_COMMISSION=new Field<double?>("Sales_Commission");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> PO_NUMBER=new Field<string>("PO_Number");
		public static readonly Field<DateTime?> DUE_DATE=new Field<DateTime?>("Due_Date");
		public static readonly Field<string> BILLING_STREET=new Field<string>("Billing_Street");
		public static readonly Field<double?> ADJUSTMENT=new Field<double?>("Adjustment");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> TERMS_AND_CONDITIONS=new Field<string>("Terms_and_Conditions");
		public static readonly Field<double?> SUB_TOTAL=new Field<double?>("Sub_Total");
		public static readonly Field<string> BILLING_CODE=new Field<string>("Billing_Code");
		public static readonly Field<List<InventoryLineItems>> PRODUCT_DETAILS=new Field<List<InventoryLineItems>>("Product_Details");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<string> TRACKING_NUMBER=new Field<string>("Tracking_Number");
		public static readonly Field<Record> CONTACT_NAME=new Field<Record>("Contact_Name");
		public static readonly Field<double?> EXCISE_DUTY=new Field<double?>("Excise_Duty");
		public static readonly Field<string> SHIPPING_CITY=new Field<string>("Shipping_City");
		public static readonly Field<string> SHIPPING_COUNTRY=new Field<string>("Shipping_Country");
		public static readonly Field<string> SHIPPING_CODE=new Field<string>("Shipping_Code");
		public static readonly Field<string> BILLING_CITY=new Field<string>("Billing_City");
		public static readonly Field<string> REQUISITION_NO=new Field<string>("Requisition_No");
		public static readonly Field<string> BILLING_STATE=new Field<string>("Billing_State");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<string> SHIPPING_STREET=new Field<string>("Shipping_Street");
	}


	public static class Accounts
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<Choice<string>> OWNERSHIP=new Field<Choice<string>>("Ownership");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<Choice<string>> ACCOUNT_TYPE=new Field<Choice<string>>("Account_Type");
		public static readonly Field<Choice<string>> RATING=new Field<Choice<string>>("Rating");
		public static readonly Field<int?> SIC_CODE=new Field<int?>("SIC_Code");
		public static readonly Field<string> SHIPPING_STATE=new Field<string>("Shipping_State");
		public static readonly Field<string> WEBSITE=new Field<string>("Website");
		public static readonly Field<int?> EMPLOYEES=new Field<int?>("Employees");
		public static readonly Field<DateTimeOffset?> LAST_ACTIVITY_TIME=new Field<DateTimeOffset?>("Last_Activity_Time");
		public static readonly Field<Choice<string>> INDUSTRY=new Field<Choice<string>>("Industry");
		public static readonly Field<string> RECORD_IMAGE=new Field<string>("Record_Image");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<string> ACCOUNT_SITE=new Field<string>("Account_Site");
		public static readonly Field<string> PHONE=new Field<string>("Phone");
		public static readonly Field<string> BILLING_COUNTRY=new Field<string>("Billing_Country");
		public static readonly Field<string> ACCOUNT_NAME=new Field<string>("Account_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<long?> ACCOUNT_NUMBER=new Field<long?>("Account_Number");
		public static readonly Field<string> TICKER_SYMBOL=new Field<string>("Ticker_Symbol");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<string> BILLING_STREET=new Field<string>("Billing_Street");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> BILLING_CODE=new Field<string>("Billing_Code");
		public static readonly Field<string> TERRITORIES=new Field<string>("Territories");
		public static readonly Field<Record> PARENT_ACCOUNT=new Field<Record>("Parent_Account");
		public static readonly Field<string> SHIPPING_CITY=new Field<string>("Shipping_City");
		public static readonly Field<string> SHIPPING_COUNTRY=new Field<string>("Shipping_Country");
		public static readonly Field<string> SHIPPING_CODE=new Field<string>("Shipping_Code");
		public static readonly Field<string> BILLING_CITY=new Field<string>("Billing_City");
		public static readonly Field<string> BILLING_STATE=new Field<string>("Billing_State");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<string> FAX=new Field<string>("Fax");
		public static readonly Field<double?> ANNUAL_REVENUE=new Field<double?>("Annual_Revenue");
		public static readonly Field<string> SHIPPING_STREET=new Field<string>("Shipping_Street");
	}


	public static class Cases
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<string> EMAIL=new Field<string>("Email");
		public static readonly Field<string> DESCRIPTION=new Field<string>("Description");
		public static readonly Field<string> INTERNAL_COMMENTS=new Field<string>("Internal_Comments");
		public static readonly Field<int?> NO_OF_COMMENTS=new Field<int?>("No_of_comments");
		public static readonly Field<string> REPORTED_BY=new Field<string>("Reported_By");
		public static readonly Field<long?> CASE_NUMBER=new Field<long?>("Case_Number");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<Record> DEAL_NAME=new Field<Record>("Deal_Name");
		public static readonly Field<string> PHONE=new Field<string>("Phone");
		public static readonly Field<Record> ACCOUNT_NAME=new Field<Record>("Account_Name");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<string> SOLUTION=new Field<string>("Solution");
		public static readonly Field<Choice<string>> STATUS=new Field<Choice<string>>("Status");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<Choice<string>> PRIORITY=new Field<Choice<string>>("Priority");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<string> COMMENTS=new Field<string>("Comments");
		public static readonly Field<Record> PRODUCT_NAME=new Field<Record>("Product_Name");
		public static readonly Field<string> ADD_COMMENT=new Field<string>("Add_Comment");
		public static readonly Field<Choice<string>> CASE_ORIGIN=new Field<Choice<string>>("Case_Origin");
		public static readonly Field<string> SUBJECT=new Field<string>("Subject");
		public static readonly Field<Choice<string>> CASE_REASON=new Field<Choice<string>>("Case_Reason");
		public static readonly Field<Choice<string>> TYPE=new Field<Choice<string>>("Type");
		public static readonly Field<bool?> IS_RECORD_DUPLICATE=new Field<bool?>("Is_Record_Duplicate");
		public static readonly Field<List<Tag>> TAG=new Field<List<Tag>>("Tag");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<Record> RELATED_TO=new Field<Record>("Related_To");
	}


	public static class Notes
	{
		public static readonly Field<User> OWNER=new Field<User>("Owner");
		public static readonly Field<User> MODIFIED_BY=new Field<User>("Modified_By");
		public static readonly Field<DateTimeOffset?> MODIFIED_TIME=new Field<DateTimeOffset?>("Modified_Time");
		public static readonly Field<DateTimeOffset?> CREATED_TIME=new Field<DateTimeOffset?>("Created_Time");
		public static readonly Field<Record> PARENT_ID=new Field<Record>("Parent_Id");
		public static readonly Field<long?> ID=new Field<long?>("id");
		public static readonly Field<User> CREATED_BY=new Field<User>("Created_By");
		public static readonly Field<string> NOTE_TITLE=new Field<string>("Note_Title");
		public static readonly Field<string> NOTE_CONTENT=new Field<string>("Note_Content");
	}

}
