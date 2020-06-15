using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.ModulusAPI.Vocabularies
{
    public class ModulusAPIVocabulary : SimpleVocabulary
    {
        public ModulusAPIVocabulary()
        {
            VocabularyName = "ModulusAPI ModulusAPI"; // TODO: Set value
            KeyPrefix = "modulusapi.modulusapi"; // TODO: Set value
            KeySeparator = ".";
            Grouping = EntityType.Infrastructure.User; // TODO: Set value

            AddGroup("ModulusAPI ModulusAPI Details", group =>
            {
                Individ_id = group.Add(new VocabularyKey("Individ_id", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Cpr_no = group.Add(new VocabularyKey("Cpr_no", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Surname = group.Add(new VocabularyKey("Surname", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                First_name = group.Add(new VocabularyKey("First_name", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Username = group.Add(new VocabularyKey("Username", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Membership_no = group.Add(new VocabularyKey("Membership_no", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Has_akasse_membership = group.Add(new VocabularyKey("Has_akasse_membership", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Has_forbund_memberhip = group.Add(new VocabularyKey("Has_forbund_memberhip", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));

            });

            AddMapping(Individ_id, CluedIn.Lederne.Common.Vocabularies.LederneVocabularies.Person.Individ_id);
            AddMapping(Cpr_no, CluedIn.Lederne.Common.Vocabularies.LederneVocabularies.Person.CPRnummer);
            AddMapping(Surname, CluedIn.Lederne.Common.Vocabularies.LederneVocabularies.Person.Efternavn);
            AddMapping(First_name, CluedIn.Lederne.Common.Vocabularies.LederneVocabularies.Person.Fornavn);
            AddMapping(Membership_no, CluedIn.Lederne.Common.Vocabularies.LederneVocabularies.Person.Medlemsnummer);
        }

        public VocabularyKey Individ_id { get; internal set; }
        public VocabularyKey Cpr_no { get; internal set; }
        public VocabularyKey Surname { get; internal set; }
        public VocabularyKey First_name { get; internal set; }
        public VocabularyKey Username { get; internal set; }
        public VocabularyKey Membership_no { get; internal set; }
        public VocabularyKey Has_akasse_membership { get; internal set; }
        public VocabularyKey Has_forbund_memberhip { get; internal set; }
    }
}
