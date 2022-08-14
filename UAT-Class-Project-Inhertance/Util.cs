//	statusType	statusDateTime	currentStatusIndicator	primaryIndicator	type	nameType	OrganizationName	PersonGroupMember
//	
//		primaryIndicator	sequence	personID	FamilyName	GivenName	DisplayName	JobTitle	ContactInfo 	
//		nature	Email	PersonLabel 	personLabelContext	primaryIndicator	sequence	personID	FamilyName	GivenName	DisplayName	JobTitle	ContactInfo 	nature	Email	PersonLabel 	personLabelContext	Title	TitleFormatted	SynopsisFormatted	Security	primaryIndicator	ratingAction	estimateAction	idtype	idValue	Security	primaryIndicator	ratingAction	estimateAction	idType	idValue	SecurityName	assetClass	assetType	securityType	Rating	ratingAction	priorCurrent	volatile	rating	Resource	PublisherDefinedValue	RatingEntity	ratingEntity	Description	Rating	ratingAction	priorCurrent	volatile	rating	PublisherDefinedValue	ratingEntity	Description	IssuerName	nameType	NameValue

namespace exceltorixml
{
    public static class Util {
        public static PersonGroupMember parseName(int indx, string[] data)
        {
            PersonGroupMember pgm = new PersonGroupMember();

            pgm.primaryIndicator = data[indx++];
            pgm.sequence = data[indx++];
            pgm.personID = data[indx++];
            pgm.FamilyName = data[indx++];
            pgm.GivenName = data[indx++];
            pgm.DisplayName = data[indx++];
            pgm.JobTitle = data[indx++];
            pgm.ContactInfo = data[indx++];
            pgm.nature = data[indx++];
            pgm.Email = data[indx++];


            return pgm;
        }
    }
}
