using Com.Zoho.Crm.API.CustomViews;
using Com.Zoho.Crm.API.Profiles;
using Com.Zoho.Crm.API.Users;
using Com.Zoho.Crm.API.Util;
using System;
using System.Collections.Generic;

namespace Com.Zoho.Crm.API.Modules
{

	public class Module : Model
	{
		private string name;
		private bool? globalSearchSupported;
		private bool? kanbanView;
		private bool? deletable;
		private string description;
		private bool? creatable;
		private bool? filterStatus;
		private bool? inventoryTemplateSupported;
		private DateTimeOffset? modifiedTime;
		private string pluralLabel;
		private bool? presenceSubMenu;
		private bool? triggersSupported;
		private long? id;
		private RelatedListProperties relatedListProperties;
		private List<string> properties;
		private int? perPage;
		private int? visibility;
		private bool? convertable;
		private bool? editable;
		private bool? emailtemplateSupport;
		private List<Profile> profiles;
		private bool? filterSupported;
		private string displayField;
		private List<string> searchLayoutFields;
		private bool? kanbanViewSupported;
		private bool? showAsTab;
		private string webLink;
		private int? sequenceNumber;
		private string singularLabel;
		private bool? viewable;
		private bool? apiSupported;
		private string apiName;
		private bool? quickCreate;
		private User modifiedBy;
		private Choice<string> generatedType;
		private bool? feedsRequired;
		private bool? scoringSupported;
		private bool? webformSupported;
		private List<Argument> arguments;
		private string moduleName;
		private int? businessCardFieldLimit;
		private CustomView customView;
		private Module parentModule;
		private Territory territory;
		private Dictionary<string, int?> keyModified=new Dictionary<string, int?>();

		public string Name
		{
			/// <summary>The method to get the name</summary>
			/// <returns>string representing the name</returns>
			get
			{
				return  this.name;

			}
			/// <summary>The method to set the value to name</summary>
			/// <param name="name">string</param>
			set
			{
				 this.name=value;

				 this.keyModified["name"] = 1;

			}
		}

		public bool? GlobalSearchSupported
		{
			/// <summary>The method to get the globalSearchSupported</summary>
			/// <returns>bool? representing the globalSearchSupported</returns>
			get
			{
				return  this.globalSearchSupported;

			}
			/// <summary>The method to set the value to globalSearchSupported</summary>
			/// <param name="globalSearchSupported">bool?</param>
			set
			{
				 this.globalSearchSupported=value;

				 this.keyModified["global_search_supported"] = 1;

			}
		}

		public bool? KanbanView
		{
			/// <summary>The method to get the kanbanView</summary>
			/// <returns>bool? representing the kanbanView</returns>
			get
			{
				return  this.kanbanView;

			}
			/// <summary>The method to set the value to kanbanView</summary>
			/// <param name="kanbanView">bool?</param>
			set
			{
				 this.kanbanView=value;

				 this.keyModified["kanban_view"] = 1;

			}
		}

		public bool? Deletable
		{
			/// <summary>The method to get the deletable</summary>
			/// <returns>bool? representing the deletable</returns>
			get
			{
				return  this.deletable;

			}
			/// <summary>The method to set the value to deletable</summary>
			/// <param name="deletable">bool?</param>
			set
			{
				 this.deletable=value;

				 this.keyModified["deletable"] = 1;

			}
		}

		public string Description
		{
			/// <summary>The method to get the description</summary>
			/// <returns>string representing the description</returns>
			get
			{
				return  this.description;

			}
			/// <summary>The method to set the value to description</summary>
			/// <param name="description">string</param>
			set
			{
				 this.description=value;

				 this.keyModified["description"] = 1;

			}
		}

		public bool? Creatable
		{
			/// <summary>The method to get the creatable</summary>
			/// <returns>bool? representing the creatable</returns>
			get
			{
				return  this.creatable;

			}
			/// <summary>The method to set the value to creatable</summary>
			/// <param name="creatable">bool?</param>
			set
			{
				 this.creatable=value;

				 this.keyModified["creatable"] = 1;

			}
		}

		public bool? FilterStatus
		{
			/// <summary>The method to get the filterStatus</summary>
			/// <returns>bool? representing the filterStatus</returns>
			get
			{
				return  this.filterStatus;

			}
			/// <summary>The method to set the value to filterStatus</summary>
			/// <param name="filterStatus">bool?</param>
			set
			{
				 this.filterStatus=value;

				 this.keyModified["filter_status"] = 1;

			}
		}

		public bool? InventoryTemplateSupported
		{
			/// <summary>The method to get the inventoryTemplateSupported</summary>
			/// <returns>bool? representing the inventoryTemplateSupported</returns>
			get
			{
				return  this.inventoryTemplateSupported;

			}
			/// <summary>The method to set the value to inventoryTemplateSupported</summary>
			/// <param name="inventoryTemplateSupported">bool?</param>
			set
			{
				 this.inventoryTemplateSupported=value;

				 this.keyModified["inventory_template_supported"] = 1;

			}
		}

		public DateTimeOffset? ModifiedTime
		{
			/// <summary>The method to get the modifiedTime</summary>
			/// <returns>DateTimeOffset? representing the modifiedTime</returns>
			get
			{
				return  this.modifiedTime;

			}
			/// <summary>The method to set the value to modifiedTime</summary>
			/// <param name="modifiedTime">DateTimeOffset?</param>
			set
			{
				 this.modifiedTime=value;

				 this.keyModified["modified_time"] = 1;

			}
		}

		public string PluralLabel
		{
			/// <summary>The method to get the pluralLabel</summary>
			/// <returns>string representing the pluralLabel</returns>
			get
			{
				return  this.pluralLabel;

			}
			/// <summary>The method to set the value to pluralLabel</summary>
			/// <param name="pluralLabel">string</param>
			set
			{
				 this.pluralLabel=value;

				 this.keyModified["plural_label"] = 1;

			}
		}

		public bool? PresenceSubMenu
		{
			/// <summary>The method to get the presenceSubMenu</summary>
			/// <returns>bool? representing the presenceSubMenu</returns>
			get
			{
				return  this.presenceSubMenu;

			}
			/// <summary>The method to set the value to presenceSubMenu</summary>
			/// <param name="presenceSubMenu">bool?</param>
			set
			{
				 this.presenceSubMenu=value;

				 this.keyModified["presence_sub_menu"] = 1;

			}
		}

		public bool? TriggersSupported
		{
			/// <summary>The method to get the triggersSupported</summary>
			/// <returns>bool? representing the triggersSupported</returns>
			get
			{
				return  this.triggersSupported;

			}
			/// <summary>The method to set the value to triggersSupported</summary>
			/// <param name="triggersSupported">bool?</param>
			set
			{
				 this.triggersSupported=value;

				 this.keyModified["triggers_supported"] = 1;

			}
		}

		public long? Id
		{
			/// <summary>The method to get the id</summary>
			/// <returns>long? representing the id</returns>
			get
			{
				return  this.id;

			}
			/// <summary>The method to set the value to id</summary>
			/// <param name="id">long?</param>
			set
			{
				 this.id=value;

				 this.keyModified["id"] = 1;

			}
		}

		public RelatedListProperties RelatedListProperties
		{
			/// <summary>The method to get the relatedListProperties</summary>
			/// <returns>Instance of RelatedListProperties</returns>
			get
			{
				return  this.relatedListProperties;

			}
			/// <summary>The method to set the value to relatedListProperties</summary>
			/// <param name="relatedListProperties">Instance of RelatedListProperties</param>
			set
			{
				 this.relatedListProperties=value;

				 this.keyModified["related_list_properties"] = 1;

			}
		}

		public List<string> Properties
		{
			/// <summary>The method to get the properties</summary>
			/// <returns>Instance of List<String></returns>
			get
			{
				return  this.properties;

			}
			/// <summary>The method to set the value to properties</summary>
			/// <param name="properties">Instance of List<string></param>
			set
			{
				 this.properties=value;

				 this.keyModified["$properties"] = 1;

			}
		}

		public int? PerPage
		{
			/// <summary>The method to get the perPage</summary>
			/// <returns>int? representing the perPage</returns>
			get
			{
				return  this.perPage;

			}
			/// <summary>The method to set the value to perPage</summary>
			/// <param name="perPage">int?</param>
			set
			{
				 this.perPage=value;

				 this.keyModified["per_page"] = 1;

			}
		}

		public int? Visibility
		{
			/// <summary>The method to get the visibility</summary>
			/// <returns>int? representing the visibility</returns>
			get
			{
				return  this.visibility;

			}
			/// <summary>The method to set the value to visibility</summary>
			/// <param name="visibility">int?</param>
			set
			{
				 this.visibility=value;

				 this.keyModified["visibility"] = 1;

			}
		}

		public bool? Convertable
		{
			/// <summary>The method to get the convertable</summary>
			/// <returns>bool? representing the convertable</returns>
			get
			{
				return  this.convertable;

			}
			/// <summary>The method to set the value to convertable</summary>
			/// <param name="convertable">bool?</param>
			set
			{
				 this.convertable=value;

				 this.keyModified["convertable"] = 1;

			}
		}

		public bool? Editable
		{
			/// <summary>The method to get the editable</summary>
			/// <returns>bool? representing the editable</returns>
			get
			{
				return  this.editable;

			}
			/// <summary>The method to set the value to editable</summary>
			/// <param name="editable">bool?</param>
			set
			{
				 this.editable=value;

				 this.keyModified["editable"] = 1;

			}
		}

		public bool? EmailtemplateSupport
		{
			/// <summary>The method to get the emailtemplateSupport</summary>
			/// <returns>bool? representing the emailtemplateSupport</returns>
			get
			{
				return  this.emailtemplateSupport;

			}
			/// <summary>The method to set the value to emailtemplateSupport</summary>
			/// <param name="emailtemplateSupport">bool?</param>
			set
			{
				 this.emailtemplateSupport=value;

				 this.keyModified["emailTemplate_support"] = 1;

			}
		}

		public List<Profile> Profiles
		{
			/// <summary>The method to get the profiles</summary>
			/// <returns>Instance of List<Profile></returns>
			get
			{
				return  this.profiles;

			}
			/// <summary>The method to set the value to profiles</summary>
			/// <param name="profiles">Instance of List<Profile></param>
			set
			{
				 this.profiles=value;

				 this.keyModified["profiles"] = 1;

			}
		}

		public bool? FilterSupported
		{
			/// <summary>The method to get the filterSupported</summary>
			/// <returns>bool? representing the filterSupported</returns>
			get
			{
				return  this.filterSupported;

			}
			/// <summary>The method to set the value to filterSupported</summary>
			/// <param name="filterSupported">bool?</param>
			set
			{
				 this.filterSupported=value;

				 this.keyModified["filter_supported"] = 1;

			}
		}

		public string DisplayField
		{
			/// <summary>The method to get the displayField</summary>
			/// <returns>string representing the displayField</returns>
			get
			{
				return  this.displayField;

			}
			/// <summary>The method to set the value to displayField</summary>
			/// <param name="displayField">string</param>
			set
			{
				 this.displayField=value;

				 this.keyModified["display_field"] = 1;

			}
		}

		public List<string> SearchLayoutFields
		{
			/// <summary>The method to get the searchLayoutFields</summary>
			/// <returns>Instance of List<String></returns>
			get
			{
				return  this.searchLayoutFields;

			}
			/// <summary>The method to set the value to searchLayoutFields</summary>
			/// <param name="searchLayoutFields">Instance of List<string></param>
			set
			{
				 this.searchLayoutFields=value;

				 this.keyModified["search_layout_fields"] = 1;

			}
		}

		public bool? KanbanViewSupported
		{
			/// <summary>The method to get the kanbanViewSupported</summary>
			/// <returns>bool? representing the kanbanViewSupported</returns>
			get
			{
				return  this.kanbanViewSupported;

			}
			/// <summary>The method to set the value to kanbanViewSupported</summary>
			/// <param name="kanbanViewSupported">bool?</param>
			set
			{
				 this.kanbanViewSupported=value;

				 this.keyModified["kanban_view_supported"] = 1;

			}
		}

		public bool? ShowAsTab
		{
			/// <summary>The method to get the showAsTab</summary>
			/// <returns>bool? representing the showAsTab</returns>
			get
			{
				return  this.showAsTab;

			}
			/// <summary>The method to set the value to showAsTab</summary>
			/// <param name="showAsTab">bool?</param>
			set
			{
				 this.showAsTab=value;

				 this.keyModified["show_as_tab"] = 1;

			}
		}

		public string WebLink
		{
			/// <summary>The method to get the webLink</summary>
			/// <returns>string representing the webLink</returns>
			get
			{
				return  this.webLink;

			}
			/// <summary>The method to set the value to webLink</summary>
			/// <param name="webLink">string</param>
			set
			{
				 this.webLink=value;

				 this.keyModified["web_link"] = 1;

			}
		}

		public int? SequenceNumber
		{
			/// <summary>The method to get the sequenceNumber</summary>
			/// <returns>int? representing the sequenceNumber</returns>
			get
			{
				return  this.sequenceNumber;

			}
			/// <summary>The method to set the value to sequenceNumber</summary>
			/// <param name="sequenceNumber">int?</param>
			set
			{
				 this.sequenceNumber=value;

				 this.keyModified["sequence_number"] = 1;

			}
		}

		public string SingularLabel
		{
			/// <summary>The method to get the singularLabel</summary>
			/// <returns>string representing the singularLabel</returns>
			get
			{
				return  this.singularLabel;

			}
			/// <summary>The method to set the value to singularLabel</summary>
			/// <param name="singularLabel">string</param>
			set
			{
				 this.singularLabel=value;

				 this.keyModified["singular_label"] = 1;

			}
		}

		public bool? Viewable
		{
			/// <summary>The method to get the viewable</summary>
			/// <returns>bool? representing the viewable</returns>
			get
			{
				return  this.viewable;

			}
			/// <summary>The method to set the value to viewable</summary>
			/// <param name="viewable">bool?</param>
			set
			{
				 this.viewable=value;

				 this.keyModified["viewable"] = 1;

			}
		}

		public bool? APISupported
		{
			/// <summary>The method to get the aPISupported</summary>
			/// <returns>bool? representing the apiSupported</returns>
			get
			{
				return  this.apiSupported;

			}
			/// <summary>The method to set the value to aPISupported</summary>
			/// <param name="apiSupported">bool?</param>
			set
			{
				 this.apiSupported=value;

				 this.keyModified["api_supported"] = 1;

			}
		}

		public string APIName
		{
			/// <summary>The method to get the aPIName</summary>
			/// <returns>string representing the apiName</returns>
			get
			{
				return  this.apiName;

			}
			/// <summary>The method to set the value to aPIName</summary>
			/// <param name="apiName">string</param>
			set
			{
				 this.apiName=value;

				 this.keyModified["api_name"] = 1;

			}
		}

		public bool? QuickCreate
		{
			/// <summary>The method to get the quickCreate</summary>
			/// <returns>bool? representing the quickCreate</returns>
			get
			{
				return  this.quickCreate;

			}
			/// <summary>The method to set the value to quickCreate</summary>
			/// <param name="quickCreate">bool?</param>
			set
			{
				 this.quickCreate=value;

				 this.keyModified["quick_create"] = 1;

			}
		}

		public User ModifiedBy
		{
			/// <summary>The method to get the modifiedBy</summary>
			/// <returns>Instance of User</returns>
			get
			{
				return  this.modifiedBy;

			}
			/// <summary>The method to set the value to modifiedBy</summary>
			/// <param name="modifiedBy">Instance of User</param>
			set
			{
				 this.modifiedBy=value;

				 this.keyModified["modified_by"] = 1;

			}
		}

		public Choice<string> GeneratedType
		{
			/// <summary>The method to get the generatedType</summary>
			/// <returns>Instance of Choice<String></returns>
			get
			{
				return  this.generatedType;

			}
			/// <summary>The method to set the value to generatedType</summary>
			/// <param name="generatedType">Instance of Choice<string></param>
			set
			{
				 this.generatedType=value;

				 this.keyModified["generated_type"] = 1;

			}
		}

		public bool? FeedsRequired
		{
			/// <summary>The method to get the feedsRequired</summary>
			/// <returns>bool? representing the feedsRequired</returns>
			get
			{
				return  this.feedsRequired;

			}
			/// <summary>The method to set the value to feedsRequired</summary>
			/// <param name="feedsRequired">bool?</param>
			set
			{
				 this.feedsRequired=value;

				 this.keyModified["feeds_required"] = 1;

			}
		}

		public bool? ScoringSupported
		{
			/// <summary>The method to get the scoringSupported</summary>
			/// <returns>bool? representing the scoringSupported</returns>
			get
			{
				return  this.scoringSupported;

			}
			/// <summary>The method to set the value to scoringSupported</summary>
			/// <param name="scoringSupported">bool?</param>
			set
			{
				 this.scoringSupported=value;

				 this.keyModified["scoring_supported"] = 1;

			}
		}

		public bool? WebformSupported
		{
			/// <summary>The method to get the webformSupported</summary>
			/// <returns>bool? representing the webformSupported</returns>
			get
			{
				return  this.webformSupported;

			}
			/// <summary>The method to set the value to webformSupported</summary>
			/// <param name="webformSupported">bool?</param>
			set
			{
				 this.webformSupported=value;

				 this.keyModified["webform_supported"] = 1;

			}
		}

		public List<Argument> Arguments
		{
			/// <summary>The method to get the arguments</summary>
			/// <returns>Instance of List<Argument></returns>
			get
			{
				return  this.arguments;

			}
			/// <summary>The method to set the value to arguments</summary>
			/// <param name="arguments">Instance of List<Argument></param>
			set
			{
				 this.arguments=value;

				 this.keyModified["arguments"] = 1;

			}
		}

		public string ModuleName
		{
			/// <summary>The method to get the moduleName</summary>
			/// <returns>string representing the moduleName</returns>
			get
			{
				return  this.moduleName;

			}
			/// <summary>The method to set the value to moduleName</summary>
			/// <param name="moduleName">string</param>
			set
			{
				 this.moduleName=value;

				 this.keyModified["module_name"] = 1;

			}
		}

		public int? BusinessCardFieldLimit
		{
			/// <summary>The method to get the businessCardFieldLimit</summary>
			/// <returns>int? representing the businessCardFieldLimit</returns>
			get
			{
				return  this.businessCardFieldLimit;

			}
			/// <summary>The method to set the value to businessCardFieldLimit</summary>
			/// <param name="businessCardFieldLimit">int?</param>
			set
			{
				 this.businessCardFieldLimit=value;

				 this.keyModified["business_card_field_limit"] = 1;

			}
		}

		public CustomView CustomView
		{
			/// <summary>The method to get the customView</summary>
			/// <returns>Instance of CustomView</returns>
			get
			{
				return  this.customView;

			}
			/// <summary>The method to set the value to customView</summary>
			/// <param name="customView">Instance of CustomView</param>
			set
			{
				 this.customView=value;

				 this.keyModified["custom_view"] = 1;

			}
		}

		public Module ParentModule
		{
			/// <summary>The method to get the parentModule</summary>
			/// <returns>Instance of Module</returns>
			get
			{
				return  this.parentModule;

			}
			/// <summary>The method to set the value to parentModule</summary>
			/// <param name="parentModule">Instance of Module</param>
			set
			{
				 this.parentModule=value;

				 this.keyModified["parent_module"] = 1;

			}
		}

		public Territory Territory
		{
			/// <summary>The method to get the territory</summary>
			/// <returns>Instance of Territory</returns>
			get
			{
				return  this.territory;

			}
			/// <summary>The method to set the value to territory</summary>
			/// <param name="territory">Instance of Territory</param>
			set
			{
				 this.territory=value;

				 this.keyModified["territory"] = 1;

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