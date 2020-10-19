using FluentAssertions;
using Xunit;

namespace TheDesignPatterns.ChainOfResponsibility
{
    public class ChainOfResponsibilityTest
    {
        [Fact]
        public void ShouldApproveLoadAmount()
        {
            var loanExecutive = new LoanExecutive();

            LoanRequest loanRequest1 = loanExecutive.RequestForLoanApprove("123", false, 100);

            LoanRequest loanRequest2 = loanExecutive.RequestForLoanApprove("123", true, 100000);

            loanRequest1.Approved.Should().BeTrue();
            loanRequest1.ApprovedBy.GetApproverId().Should().NotBeNullOrEmpty();

            loanRequest2.Approved.Should().BeTrue();
            loanRequest2.ApprovedBy.GetApproverId().Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ShouldNotApproveLoadAmount()
        {
            var loanExecutive = new LoanExecutive();

            LoanRequest loanRequest1 = loanExecutive.RequestForLoanApprove("123", false, 100000);

            loanRequest1.Approved.Should().BeFalse();
            loanRequest1.ApprovedBy.Should().BeNull();
        }

    }
}
