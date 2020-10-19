namespace TheDesignPatterns.ChainOfResponsibility
{
    public class LoanRequest
    {
        public string NationalId { get; set; }
        public bool PreviousRecord { get; set; }
        public int LoanAmount { get; set; }

        public bool Approved { get; set; }

        public ILoanAppover ApprovedBy { get; set; }
    }

    public class LoanExecutive
    {
        public LoanRequest RequestForLoanApprove(string nationaId, bool previousRecordGood, int loanAmount)
        {
            var loanRequest = new LoanRequest
            {
                NationalId = nationaId,
                PreviousRecord = previousRecordGood,
                LoanAmount = loanAmount
            };

            ILoanAppover loanAppover = new BranchManagerApprover("Mr. X");

            loanAppover.Approve(loanRequest);

            return loanRequest;

        }
    }

    /// <summary>
    /// Loan approve responsibility is segrigated by various Managers
    /// </summary>
    public interface ILoanAppover
    {
        public string GetApproverId();
        void Approve(LoanRequest loanRequest);
    }

    /// <summary>
    /// Limited amount Loan approver
    /// </summary>
    public class BranchManagerApprover : ILoanAppover
    {
        private const int MaxLoanApproveAmount = 1000;
        private readonly ILoanAppover nextLoanApprover = new RegionallManagerApprover("Mr. Y");
        private readonly string managerId = null;

        public BranchManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }

        public void Approve(LoanRequest loanRequest)
        {
            if (loanRequest.LoanAmount <= MaxLoanApproveAmount)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
            }

            nextLoanApprover.Approve(loanRequest);
        }

        public string GetApproverId()
        {
            return managerId;
        }
    }

    /// <summary>
    /// Limited amount Loan approver but higher then Branch Manager
    /// </summary>
    public class RegionallManagerApprover : ILoanAppover
    {
        private const int MaxLoanApproveAmount = 10000;
        private readonly ILoanAppover nextLoanApprover = new DevisionalManagerApprover("Mr. Z");
        private readonly string managerId = null;

        public RegionallManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }

        public void Approve(LoanRequest loanRequest)
        {
            if (loanRequest.LoanAmount <= MaxLoanApproveAmount)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
                
            }

            nextLoanApprover.Approve(loanRequest);
        }
        public string GetApproverId()
        {
            return managerId;
        }
    }

    /// <summary>
    /// Maximum level loan approver who checks the previous load record of requeter.
    /// </summary>
    public class DevisionalManagerApprover : ILoanAppover
    {
        private const int MaxLoanApproveAmount = 1000000;
        private readonly string managerId = null;

        public DevisionalManagerApprover(string managerId)
        {
            this.managerId = managerId;
        }
        public void Approve(LoanRequest loanRequest)
        {
            if (loanRequest.LoanAmount <= MaxLoanApproveAmount && loanRequest.PreviousRecord)
            {
                loanRequest.Approved = true;
                loanRequest.ApprovedBy = this;
            }          
        }

        public string GetApproverId()
        {
            return managerId;
        }
    }
}
