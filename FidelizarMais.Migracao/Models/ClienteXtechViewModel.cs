using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FidelizarMais.Migracao.Models
{
    public class ClienteXtechViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("newsletter_subscription")]
        public string NewsletterSubscription { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("active")]
        public string Active { get; set; }

        [JsonProperty("confirmed")]
        public string Confirmed { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("company_alt")]
        public string CompanyAlt { get; set; }

        [JsonProperty("company_registration")]
        public string CompanyRegistration { get; set; }

        [JsonProperty("company_registration_alt")]
        public string CompanyRegistrationAlt { get; set; }

        [JsonProperty("company_description")]
        public string CompanyDescription { get; set; }

        [JsonProperty("facebook_uid")]
        public string FacebookUid { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }
    }
}
