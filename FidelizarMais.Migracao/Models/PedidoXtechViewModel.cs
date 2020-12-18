using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FidelizarMais.Migracao.Models
{
    public class PedidoXtechViewModel
    {
        [JsonProperty("customer_firstname")]
        public string CustomerFirstname { get; set; }

        [JsonProperty("customer_lastname")]
        public string CustomerLastname { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("customer_phone")]
        public string CustomerPhone { get; set; }

        [JsonProperty("customer_company")]
        public string CustomerCompany { get; set; }

        [JsonProperty("customer_default_billing_address")]
        public string CustomerDefaultBillingAddress { get; set; }

        [JsonProperty("customer_default_shipping_address")]
        public string CustomerDefaultShippingAddress { get; set; }

        [JsonProperty("customer_ship_to_bill_address")]
        public string CustomerShipToBillAddress { get; set; }

        [JsonProperty("customer_active")]
        public string CustomerActive { get; set; }

        [JsonProperty("customer_group_id")]
        public string CustomerGroupId { get; set; }

        [JsonProperty("customer_sex")]
        public string CustomerSex { get; set; }

        [JsonProperty("customer_cpf")]
        public string CustomerCpf { get; set; }

        [JsonProperty("customer_birthday")]
        public string CustomerBirthday { get; set; }

        [JsonProperty("customer_mobile")]
        public string CustomerMobile { get; set; }

        [JsonProperty("customer_cnpj")]
        public string CustomerCnpj { get; set; }

        [JsonProperty("customer_company_alt")]
        public string CustomerCompanyAlt { get; set; }

        [JsonProperty("customer_company_registration")]
        public string CustomerCompanyRegistration { get; set; }

        [JsonProperty("customer_company_registration_alt")]
        public string CustomerCompanyRegistrationAlt { get; set; }

        [JsonProperty("customer_job")]
        public string CustomerJob { get; set; }

        [JsonProperty("customer_company_description")]
        public string CustomerCompanyDescription { get; set; }

        [JsonProperty("customer_facebook_uid")]
        public string CustomerFacebookUid { get; set; }

        [JsonProperty("customer_additionals")]
        public string CustomerAdditionals { get; set; }

        [JsonProperty("customer_payment_method_info")]
        public string CustomerPaymentMethodInfo { get; set; }

        [JsonProperty("ship_company")]
        public string ShipCompany { get; set; }

        [JsonProperty("ship_firstname")]
        public string ShipFirstname { get; set; }

        [JsonProperty("ship_lastname")]
        public string ShipLastname { get; set; }

        [JsonProperty("ship_email")]
        public string ShipEmail { get; set; }

        [JsonProperty("ship_phone")]
        public string ShipPhone { get; set; }

        [JsonProperty("ship_address1")]
        public string ShipAddress1 { get; set; }

        [JsonProperty("ship_address2")]
        public string ShipAddress2 { get; set; }

        [JsonProperty("ship_anumber")]
        public string ShipAnumber { get; set; }

        [JsonProperty("ship_district")]
        public string ShipDistrict { get; set; }

        [JsonProperty("ship_city")]
        public string ShipCity { get; set; }

        [JsonProperty("ship_zip")]
        public string ShipZip { get; set; }

        [JsonProperty("ship_zone_id")]
        public string ShipZoneId { get; set; }

        [JsonProperty("ship_zone")]
        public string ShipZone { get; set; }

        [JsonProperty("ship_country_id")]
        public string ShipCountryId { get; set; }

        [JsonProperty("ship_country")]
        public string ShipCountry { get; set; }

        [JsonProperty("ship_country_code")]
        public string ShipCountryCode { get; set; }

        [JsonProperty("ship_reference")]
        public string ShipReference { get; set; }

        [JsonProperty("ship_extra")]
        public string ShipExtra { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_order_number")]
        public string OrderOrderNumber { get; set; }

        [JsonProperty("order_customer_id")]
        public string OrderCustomerId { get; set; }

        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }

        [JsonProperty("order_ordered_on")]
        public string OrderOrderedOn { get; set; }

        [JsonProperty("order_shipped_on")]
        public string OrderShippedOn { get; set; }

        [JsonProperty("order_tax")]
        public string OrderTax { get; set; }

        [JsonProperty("order_total")]
        public string OrderTotal { get; set; }

        [JsonProperty("order_subtotal")]
        public string OrderSubtotal { get; set; }

        [JsonProperty("order_gift_card_discount")]
        public string OrderGiftCardDiscount { get; set; }

        [JsonProperty("order_coupon_discount")]
        public string OrderCouponDiscount { get; set; }

        [JsonProperty("order_payment_discount")]
        public string OrderPaymentDiscount { get; set; }

        [JsonProperty("order_look_discount")]
        public string OrderLookDiscount { get; set; }

        [JsonProperty("order_shipping")]
        public string OrderShipping { get; set; }

        [JsonProperty("order_shipping_notes")]
        public string OrderShippingNotes { get; set; }

        [JsonProperty("order_shipping_method")]
        public string OrderShippingMethod { get; set; }

        [JsonProperty("order_notes")]
        public string OrderNotes { get; set; }

        [JsonProperty("order_payment_info")]
        public string OrderPaymentInfo { get; set; }

        [JsonProperty("order_referral")]
        public string OrderReferral { get; set; }

        [JsonProperty("order_company")]
        public string OrderCompany { get; set; }

        [JsonProperty("order_firstname")]
        public string OrderFirstname { get; set; }

        [JsonProperty("order_lastname")]
        public string OrderLastname { get; set; }

        [JsonProperty("order_phone")]
        public string OrderPhone { get; set; }

        [JsonProperty("order_email")]
        public string OrderEmail { get; set; }

        [JsonProperty("order_history")]
        public string OrderHistory { get; set; }

        [JsonProperty("order_tracking_number")]
        public string OrderTrackingNumber { get; set; }

        [JsonProperty("order_delivery_time")]
        public string OrderDeliveryTime { get; set; }

        [JsonProperty("order_production_time")]
        public string OrderProductionTime { get; set; }

        [JsonProperty("order_days_until_shipped")]
        public string OrderDaysUntilShipped { get; set; }

        [JsonProperty("order_approved_on")]
        public string OrderApprovedOn { get; set; }

        [JsonProperty("order_nota_fiscal")]
        public string OrderNotaFiscal { get; set; }

        [JsonProperty("order_shipping_method_alt")]
        public string OrderShippingMethodAlt { get; set; }

        [JsonProperty("order_extra")]
        public string OrderExtra { get; set; }

        [JsonProperty("order_payment_type")]
        public string OrderPaymentType { get; set; }

        [JsonProperty("order_delivering_on")]
        public string OrderDeliveringOn { get; set; }

        [JsonProperty("order_payment_id")]
        public string OrderPaymentId { get; set; }

        [JsonProperty("order_ship_address_id")]
        public string OrderShipAddressId { get; set; }

        [JsonProperty("order_bill_address_id")]
        public string OrderBillAddressId { get; set; }

        [JsonProperty("order_payment_options")]
        public string OrderPaymentOptions { get; set; }

        [JsonProperty("order_currency")]
        public string OrderCurrency { get; set; }

        [JsonProperty("order_coupon_ids")]
        public string OrderCouponIds { get; set; }

        [JsonProperty("order_delivered_on")]
        public string OrderDeliveredOn { get; set; }

        [JsonProperty("order_sent_testimonial")]
        public string OrderSentTestimonial { get; set; }

        [JsonProperty("order_ip_address")]
        public string OrderIpAddress { get; set; }

        [JsonProperty("order_tracking_check")]
        public string OrderTrackingCheck { get; set; }

        [JsonProperty("order_referral_id")]
        public string OrderReferralId { get; set; }

        [JsonProperty("order_referral_converted_value")]
        public string OrderReferralConvertedValue { get; set; }

        [JsonProperty("order_referral_info")]
        public string OrderReferralInfo { get; set; }

        [JsonProperty("order_referral_discount")]
        public string OrderReferralDiscount { get; set; }

        [JsonProperty("order_campaign_discount")]
        public string OrderCampaignDiscount { get; set; }

        [JsonProperty("order_referral_confirmation")]
        public string OrderReferralConfirmation { get; set; }

        [JsonProperty("order_used_device")]
        public string OrderUsedDevice { get; set; }

        [JsonProperty("order_payment_status_check")]
        public string OrderPaymentStatusCheck { get; set; }

        [JsonProperty("order_external_info")]
        public string OrderExternalInfo { get; set; }

        [JsonProperty("order_company_alt")]
        public string OrderCompanyAlt { get; set; }

        [JsonProperty("order_company_registration")]
        public string OrderCompanyRegistration { get; set; }

        [JsonProperty("order_company_registration_alt")]
        public string OrderCompanyRegistrationAlt { get; set; }

        [JsonProperty("order_deleted_on")]
        public object OrderDeletedOn { get; set; }

        [JsonProperty("order_contents")]
        public IList<OrderContentPedidoXtechViewModel> OrderContents { get; set; }

        [JsonProperty("order_coupons")]
        public IList<OrderCouponsPedidoXtechViewModel> OrderCoupons { get; set; }

        public PedidoXtechViewModel()
        {
            this.OrderContents = new List<OrderContentPedidoXtechViewModel>();
            this.OrderCoupons = new List<OrderCouponsPedidoXtechViewModel>();
        }
    }

    public class OrderCouponsPedidoXtechViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class OrderContentPedidoXtechViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("saleprice")]
        public string Saleprice { get; set; }

        [JsonProperty("free_shipping")]
        public string FreeShipping { get; set; }

        [JsonProperty("shippable")]
        public string Shippable { get; set; }

        [JsonProperty("taxable")]
        public string Taxable { get; set; }

        [JsonProperty("fixed_quantity")]
        public string FixedQuantity { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("track_stock")]
        public string TrackStock { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("video")]
        public string Video { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("depth")]
        public string Depth { get; set; }

        [JsonProperty("factory_price")]
        public string FactoryPrice { get; set; }

        [JsonProperty("installments")]
        public string Installments { get; set; }

        [JsonProperty("stared")]
        public string Stared { get; set; }

        [JsonProperty("variant_details")]
        public string VariantDetails { get; set; }

        [JsonProperty("subscription_days")]
        public string SubscriptionDays { get; set; }

        [JsonProperty("subscription_period")]
        public string SubscriptionPeriod { get; set; }

        [JsonProperty("subscription_trial")]
        public string SubscriptionTrial { get; set; }

        [JsonProperty("lookable")]
        public string Lookable { get; set; }

        [JsonProperty("reduction_type")]
        public string ReductionType { get; set; }

        [JsonProperty("reduction_amount")]
        public string ReductionAmount { get; set; }

        [JsonProperty("processing_days")]
        public string ProcessingDays { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("ncm_code")]
        public string NcmCode { get; set; }

        [JsonProperty("gtin_code")]
        public string GtinCode { get; set; }

        [JsonProperty("product_main_category")]
        public string ProductMainCategory { get; set; }

        [JsonProperty("look_products")]
        public object LookProducts { get; set; }

        [JsonProperty("available_options")]
        public object AvailableOptions { get; set; }

        [JsonProperty("product_main_category_text")]
        public string ProductMainCategoryText { get; set; }

        [JsonProperty("current_category")]
        public bool CurrentCategory { get; set; }

        [JsonProperty("variants")]
        public object Variants { get; set; }

        [JsonProperty("base_price")]
        public string BasePrice { get; set; }

        [JsonProperty("original_quantity")]
        public string OriginalQuantity { get; set; }

        [JsonProperty("file_list")]
        public object FileList { get; set; }

        [JsonProperty("discounted_price")]
        public object DiscountedPrice { get; set; }

        [JsonProperty("installment_price")]
        public double? InstallmentPrice { get; set; }

        [JsonProperty("is_gc")]
        public bool IsGc { get; set; }

        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
    }
}
