//	statusType	statusDateTime	currentStatusIndicator	primaryIndicator	type	nameType	OrganizationName	PersonGroupMember
//	
//		primaryIndicator	sequence	personID	FamilyName	GivenName	DisplayName	JobTitle	ContactInfo 	
//		nature	Email	PersonLabel 	personLabelContext	
//		primaryIndicator	sequence	personID	FamilyName	GivenName	DisplayName	JobTitle	ContactInfo 	
//		nature	Email	PersonLabel 	personLabelContext	
//		Title	TitleFormatted	SynopsisFormatted	Security	primaryIndicator	ratingAction	estimateAction	idtype	idValue	Security	primaryIndicator	ratingAction	estimateAction	idType	idValue	SecurityName	assetClass	assetType	securityType	Rating	ratingAction	priorCurrent	volatile	rating	Resource	PublisherDefinedValue	RatingEntity	ratingEntity	Description	Rating	ratingAction	priorCurrent	volatile	rating	PublisherDefinedValue	ratingEntity	Description	IssuerName	nameType	NameValue

using System;

namespace exceltorixml
{

    public class MCHNY
    {
        const int STATUS_TYPE = 0;
        const int STATUS_DATE_TIME = 1;
        const int CURRENT_STATUS_INDICATOR = 2;
        const int PRIMARY_INDICATOR = 3;
        const int TYPE = 4;
        const int NAME_TYPE = 5;
        const int ORGANIZATION_Name = 6;

        // Person Group Member #1 positions 7 - 18
        // Person Group Member #2 positions 19 - 30

        const int TITLE = 31;
        const int TITLE_FORMATTED = 32;

        public string statusType { get; set; }
        public string statusDateTime { get; set; }
        public string currentStatusIndicator { get; set; }
        public string primaryIndicator { get; set; }                
        public string type { get; set; }
        public string nameType {get;set;}
        public string OrganizationName {get;set;}
        public PersonGroupMember Person1 { get; set; }
        public PersonGroupMember Person2 { get; set; }
        public string Title { get; set; }
        public string TitleFormatted {get;set;}
        public string SynopsisFormatted {get;set;}
        public string Security { get; set; }     
        
        public string primaryIndicator2 { get; set; }
        
        public string ratingAction { get; set; }
        public string estimateAction { get; set; }
        //idtype idValue Security
        //primaryIndicator ratingAction estimateAction idType idValue SecurityName
        //assetClass assetType securityType Rating ratingAction priorCurrent
        //volatile rating Resource    PublisherDefinedValue RatingEntity    ratingEntity Description Rating ratingAction
        //priorCurrent volatile rating PublisherDefinedValue
        //ratingEntity Description
        public string IssuerName { get; set; }
        public string nameType2 { get; set; }
        public string NameValue { get; set; }



        private char delim = '"';


        //sequence	personID	FamilyName	GivenName	DisplayName	JobTitle	ContactInfo 	nature	Email	PersonLabel 	personLabelContext
		//Kunz David   David Kunz  Astronaut dkunz@mchny.com Bloomberg

        public MCHNY(string data)
        {
            string[] buffer = data.Split(delim);

            var string1 = buffer[0];
            OrganizationName = buffer[1];
            var string2 = buffer[2];
            SynopsisFormatted = buffer[3];

            string[] pieces1 = string1.Split(',');
            string[] pieces2 = string2.Split(',');

            statusType = pieces1[STATUS_TYPE];
            statusDateTime = DateTime.Now.ToString();
            currentStatusIndicator = pieces1[CURRENT_STATUS_INDICATOR];
            primaryIndicator = pieces1[PRIMARY_INDICATOR];

            Person1 = Util.parseName(2,pieces2);
            Person2 = Util.parseName(14,pieces2);


            Title = pieces2[26];
         
            

        }

    } 
}
