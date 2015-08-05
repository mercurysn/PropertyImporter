using System.Collections.Generic;
using AutoMapper;
using PropertyImporter.Common.Matcher;
using PropertyImporter.Common.Models;
using PropertyImporter.Data.Ioc;
using PropertyImporter.Data.Repositories;
using PropertyImporter.FileAccess;

namespace PropertyImporter.Service
{
    public class PropertyImportController
    {
        private readonly IPropertyRepository _repository;
        private readonly IPropertyFileReader _fileReader = new PropertyXmlFileReader();

        public PropertyImportController()
        {
            _repository = IocContainer.Instance.Get<IPropertyRepository>();
        }

        public PropertyImportController(IPropertyRepository repository, IPropertyFileReader fileReader)
        {
            _repository = repository;
            _fileReader = fileReader;
        }

        public void ProcessFileImport(string fileName)
        {
            IEnumerable<Property> agencyProperties = ReadPropertiesFromFile(fileName);

            var databaseProperties =_repository.GetAllProperties();

            foreach (var agencyProperty in agencyProperties)
            {
                bool existInDb = false;
                int updatePropertyId = 0;

                foreach (var databasePropertyDto in databaseProperties)
                {
                    existInDb = CheckAgencyPropertyExists(agencyProperty, databasePropertyDto);

                    if (existInDb)
                    {
                        updatePropertyId = databasePropertyDto.PropertyId;
                        break;
                    }
                }

                if (existInDb)
                {
                    _repository.UpdateProperty(updatePropertyId, Mapper.Map<Data.Models.Property>(agencyProperty));
                }
                else
                {
                    _repository.CreateNewProperty(Mapper.Map<Data.Models.Property>(agencyProperty));
                }
            }
        }

        private static bool CheckAgencyPropertyExists(Property agencyProperty, Data.Models.Property databasePropertyDto)
        {
            IPropertyMatcherFactory factory = new PropertyMatcherFactory();
            IPropertyMatcher propertyMatcher = factory.GetPropertyMatcher(agencyProperty.AgencyCode);

            return propertyMatcher.IsMatch(agencyProperty, Mapper.Map<Property>(databasePropertyDto));
        }

        private IEnumerable<Property> ReadPropertiesFromFile(string fileName)
        {
            return _fileReader.ExtractAllProperties(fileName);
        }
    }
}
