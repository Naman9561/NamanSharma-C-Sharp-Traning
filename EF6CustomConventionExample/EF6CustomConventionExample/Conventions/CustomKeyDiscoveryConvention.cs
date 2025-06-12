using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;

namespace EF6CustomConventionExample.Conventions
{
    public class CustomKeyDiscoveryConvention : KeyDiscoveryConvention
    {
        private const string Id = "Key";

        protected override IEnumerable<EdmProperty> MatchKeyProperty(
            EntityType entityType, IEnumerable<EdmProperty> primitiveProperties)
        {
            Debug.Assert(entityType != null);
            Debug.Assert(primitiveProperties != null);

            var matches = primitiveProperties
                .Where(p => Id.Equals(p.Name, StringComparison.OrdinalIgnoreCase));

            if (!matches.Any())
            {
                matches = primitiveProperties
                    .Where(p => (entityType.Name + Id).Equals(p.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (matches.Count() > 1)
            {
                throw new InvalidOperationException("Multiple properties match the key convention");
            }

            return matches;
        }
    }
}
