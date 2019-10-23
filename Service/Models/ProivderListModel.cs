using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class ProivderListModel
    {
        public string photo { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public int ID { get; set; }
        public string providerid { get; set; }
    }

    public class IenumproviderListmodel
    {
        public IEnumerable<ProivderListModel> providerlistmodel { get; set; }
    }
}