using Bloodpressure_UI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bloodpressure_UI.Classes
{
    public partial class ApiClient
    {
        public async Task<List<Bloodpressure>> GetBloodpressureList()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Bloodpressure"));
            return await GetAsync<List<Bloodpressure>>(requestUrl);
        }
        public async Task<Bloodpressure> GetBloodpressure(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                string.Format("/api/Bloodpressure/{0}", id)));
            return await GetAsync<Bloodpressure>(requestUrl);
        }
        public async Task<Bloodpressure> UpdateUser(Bloodpressure model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
               string.Format("/api/Bloodpressure/{0}", model.Id)));
            
            return await  PutAsync<Bloodpressure>(requestUrl, model);
        }
        public async Task<Bloodpressure> SaveUser(Bloodpressure model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "/api/Bloodpressure"));
            return await PostAsync<Bloodpressure>(requestUrl, model);
        }

    
    }
}
