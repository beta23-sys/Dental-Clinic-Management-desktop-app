using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic
{
    public class Insurance
    {
        private string _id;
        private string _providerName;
        private string _policyNumber;

        public Insurance(string id, string providerName, string policyNumber)
        {
            _id = id;
            _providerName = providerName.ToUpper();
            _policyNumber = policyNumber;
        }

        public string Id
        {
            get { return _id; }
        }

        public string ProviderName
        {
            get { return _providerName; }
        }

        public string PolicyNumber
        {
            get { return _policyNumber; }
        }
    }
}
