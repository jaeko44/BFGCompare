using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BFGCompare.Models
{
    public class Models
    {
    }

    public class Lender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string LenderName { get; set; }
        public string LenderAddress { get; set; }
        public string LenderRating { get; set; }
        public LenderType LenderType { get; set; }
        public ICollection<LoanOffer> LoanOffers { get; set; }
    }

    public class LoanOffer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public float PrincipalInterest { get; set; }
        public float FixedInterest { get; set; }
        public ICollection<LoanOfferFeatures> LoanOfferFeatures { get; set; }
        public ICollection<LoanOfferFees> LoanOfferFees { get; set; }
        public LoanSecurity LoanSecurity { get; set; }
        public LoanType LoanType { get; set; }
        public InterestRateType InterestRateType { get; set; }

        public Guid LenderId { get; set; }
        public Lender Lender { get; set; }
    }

    public enum LoanOfferFeatures
    {
        Redraw,
        Offset,
        ExtraRepayment,
        Construction,
        LowDoc,
        IntroRate
    }

    public enum LoanOfferFees
    {
        NoOngoingFees,
        NoApplicationFees
    }

    public class CustomerRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string PropertyValue { get; set; }
        public string LoanAmount { get; set; }
        //string suburbInfo { get; set; }
        public PropertyPurpose PropertyPurpose { get; set; }
        public LoanSecurity LoanSecurity { get; set; }
        public State State { get; set; }
        public Guid CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public int LoanTerm { get; set; }
    }
    public class CustomerInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<CustomerRequest> CustomerRequests;

    }


    public enum InterestRateType
    {
        PrincipalAndInterest,
        InterestOnly,
        Both
    }
    public enum LoanType
    {
        FixedRate,
        VariableRate,
        LineOfCredit
    }

    public enum PropertyPurpose
    {
        OwnerOccupied,
        Investment
    }
    public enum LoanSecurity
    {
        Unsecured,
        Secured
    }
    public enum State
    {
        NSW,
        VIC,
        QLD,
        TAS,
        WA,
        NT,
        SA
    }
    public enum LenderType
    {
        Bank,
        BuildingSocieties,
        CreditUnions,
        P2PLender
    }

}
