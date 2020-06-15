using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;

using CluedIn.Crawling.ModulusAPI.Vocabularies;
using CluedIn.Crawling.ModulusAPI.Core.Models;
using System.Data;
using CluedIn.Crawling.ModulusAPI.Infrastructure;
using System.Linq;

namespace CluedIn.Crawling.ModulusAPI.ClueProducers
{
    public class ModulusAPIProducer : BaseClueProducer<ModulusAPIResponse>
    {
        private readonly IClueFactory _factory;

        public ModulusAPIProducer([NotNull] IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }

        protected override Clue MakeClueImpl([NotNull] ModulusAPIResponse input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create(EntityType.Infrastructure.User, input.Data.Individ_id.ToString(), accountId);

            var data = clue.Data.EntityData;

            if (!string.IsNullOrWhiteSpace(input.Data.First_name) && !string.IsNullOrWhiteSpace(input.Data.Surname))
            {
                data.Name = input.Data.First_name.ToString() + ' ' + input.Data.Surname.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(input.Data.First_name))
            {
                data.Name = input.Data.First_name.ToString();
            }
            else if (!string.IsNullOrWhiteSpace(input.Data.Surname))
            {
                data.Name = input.Data.Surname.ToString();
            }
            var vocab = new ModulusAPIVocabulary();

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            data.Properties[vocab.Individ_id] = input.Data.Individ_id.PrintIfAvailable();
            data.Properties[vocab.Cpr_no] = input.Data.Cpr_no.PrintIfAvailable();
            data.Properties[vocab.Surname] = input.Data.Surname.PrintIfAvailable();
            data.Properties[vocab.First_name] = input.Data.First_name.PrintIfAvailable();
            data.Properties[vocab.Username] = input.Data.Username.PrintIfAvailable();
            data.Properties[vocab.Membership_no] = input.Data.Membership_no.PrintIfAvailable();
            data.Properties[vocab.Has_akasse_membership] = input.Data.Has_akasse_membership.PrintIfAvailable();
            data.Properties[vocab.Has_forbund_memberhip] = input.Data.Has_forbund_memberhip.PrintIfAvailable();

            return clue;
        }
    }
}
